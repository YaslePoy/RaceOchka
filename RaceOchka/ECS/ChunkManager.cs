namespace RaceOchka.ECS;

public unsafe struct ChunkManager
{
    private Chunk* _chunks;
    private int _chunkCount;

    public int FindAvailableChunk(SuperType storeSet)
    {
        for (int i = 0; i < _chunkCount; i++)
        {
            if (_chunks[i].StoreType.Id == storeSet.Id && _chunks[i].StoredCount < Chunk.MaxLength)
                return i;
        }

        var created = new Chunk();
        return _chunkCount;
    }
}