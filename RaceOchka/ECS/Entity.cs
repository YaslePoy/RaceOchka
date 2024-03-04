namespace RaceOchka.ECS;

public struct Entity : IEquatable<Entity>
{
    public uint Index;
    public override int GetHashCode()
    {
        return (int)Index;
    }

    public static bool operator ==(Entity e1, Entity e2) => e1.Index == e2.Index;

    public static bool operator !=(Entity e1, Entity e2) => !(e1 == e2);

    public override string ToString()
    {
        return $"Entity:{Index}";
    }

    public bool Equals(Entity other)
    {
        return Index == other.Index;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity other && Equals(other);
    }
}