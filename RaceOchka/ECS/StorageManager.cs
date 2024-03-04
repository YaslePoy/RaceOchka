using System.Runtime.InteropServices;

namespace RaceOchka.ECS;

public unsafe class StorageManager
{
    private unsafe Chunk* _chunks;
    private int _chunkCount;
    public unsafe EntityLocation* EntityNotes;
    private int _storaged;
    private int _allocated;
    private int _allocSpeed;
    
    public unsafe StorageManager(int startLength, int speed = 32)
    {
        _allocated = startLength;
        _storaged = 0;
        fixed (EntityLocation* temp = new EntityLocation[_allocated])
            EntityNotes = temp;
        _allocSpeed = speed;
    }

    public unsafe void Register(Entity entity, SuperType chunk)
    {
        if(_storaged == _allocated)
            Extend();
        var local = chunk;
        EntityNotes[_storaged++] = new EntityLocation { EntityIndex = entity.Index, ChunkIndex = Utils.IndexOf(,) };
    }

    int FindAvalibleChunk(SuperType type)
    {
        for (int i = 0; i < _chunkCount; i++)
        {
            if (_chunks[i].StoreType.Id == type.Id && _chunks[i].StoredCount < Chunk.MaxLength)
                return i;
        }
        return default;
    }
    
    void Extend()
    {
        
    }
}

public struct EntityLocation
{
    public int  ChunkIndex;
    public uint EntityIndex;

}