using OpenTK.Mathematics;

namespace RaceOchka.Video;

public struct Vertex
{
    public Vector2 uv;
    public Vector3 pos;

    public override string ToString()
    {
        return $"{pos}:{uv}";
    }
}