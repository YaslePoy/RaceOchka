using System.Collections.Frozen;
using System.Numerics;
using System.Reflection;

namespace RaceOchka.ECS;

public unsafe struct Chunk
{
    public readonly SuperType StoreType;
    public const int MaxLength = 128;

    public const int StartCount = 32;
    
    public int StoredCount;

    private uint* Indexes;
    private byte* _table;

    private int _caret;

    public Chunk(SuperType storeType)
    {
        this.StoreType = storeType;
        fixed (uint* tempIndexes = new uint[StartCount])
            Indexes = tempIndexes;
        fixed (byte* tempTable = new byte[StartCount * storeType.TotalLength])
            _table = tempTable;
    }
    
    public void SetCaretTo(Entity entity)
    {
        _caret = Utils.IndexOf(Indexes, entity.Index, StoredCount);
    }
    
    public IComponent Get<T>(Entity entity) where T : unmanaged, IComponent
    {
        int typeIndex = StoreType.GetOffset<T>();
        return ((T*)(_table + typeIndex + Utils.IndexOf(Indexes, entity.Index, StoredCount) * StoreType.TotalLength))[0];
    }

    public T GetComponentByCaret<T>()  where T : unmanaged, IComponent
    {
        int typeIndex = StoreType.GetOffset<T>();
        T* ret = (T*)(_table + typeIndex + _caret * StoreType.TotalLength);
        return ret[0];
    }
    
    public void Add(Entity entity, IComponent component)
    {
        
    }
}

public static class ComponentTypesId
{
    public static int GetId<T>() where T : IComponent
    {
        return ids[typeof(T)];
    }
    private static FrozenDictionary<Type, int> ids;

    public static void LoadIds()
    {
        var cd = typeof(IComponent);
        var total = new List<Type>();
        var assms = AppDomain.CurrentDomain.GetAssemblies();
        for (int i = 0; i < assms.Length; i++)
        {
            foreach (var t in assms[i].GetTypes())
            {
                if(cd.IsAssignableTo(t))
                    total.Add(t);
            }
        }
        total.Sort();
        var primeGenerator = new PrimeNumbers().GetEnumerator();
        var temperalDict = new Dictionary<Type, int>();
        foreach (var type in total)
        {
            temperalDict.Add(type, primeGenerator.Current);
            primeGenerator.MoveNext();
        }

        ids = temperalDict.ToFrozenDictionary();
    }
} 