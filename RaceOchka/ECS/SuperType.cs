using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace RaceOchka.ECS;

public struct SuperType
{
    public BigInteger Id;
    private unsafe int* _offsets;
    private unsafe Guid* _ids;
    private int _power;
    public int TotalLength;
    
    public unsafe int GetOffset<T>() where T : IComponent
    {
        return Utils.IndexOf(_ids, typeof(T).GUID, _power);
    }

    public SuperType()
    {
        _power = 0;
        Id = 1;
    }
    
    public unsafe SuperType Extend<T>() where T: unmanaged, IComponent
    {
        var next = this;
        next.Id *= ComponentTypesId.GetId<T>();

        var nextPower = _power + 1;
        fixed (Guid* nextGuids = new Guid[nextPower])
        {
            Buffer.MemoryCopy(_ids, nextGuids, _power, _power);
            nextGuids[_power] = typeof(T).GUID;
            next._ids = nextGuids;
        }
        
        fixed (int* nextOffsets = new int[nextPower])
        {
            Buffer.MemoryCopy(_offsets, nextOffsets, _power, _power);
            nextOffsets[_power] = nextOffsets[_power - 1] + sizeof(T);
            next._offsets = nextOffsets;
        }
        
        next._power = nextPower;
        next.TotalLength = next._offsets[_power];
        return next;
    }
}