using OpenTK.Mathematics;

namespace RaceOchka.Video;

public struct RenderSurface(Vector3[] vertices, Vector2[] texture, Vector3 move, Vector3 normal, int tx)
{
    // (Vector3, Vector2)[] _vts;
    Vector3 move = move;

    Vertex v1 = new() { pos = vertices[0], uv = texture[0] },
        v2 = new() { pos = vertices[1], uv = texture[1] },
        v3 = new() { pos = vertices[2], uv = texture[2] },
        v4 = new() { pos = vertices[3], uv = texture[3] };

    public readonly Vector3 Normal = normal;

    // public readonly int TextureID = tx;

    public unsafe void GetRawPolygon(Span<float> span)
    {
        System.Numerics.Vector3 fastMove = move.ToFastVector();

        var current = v1;
        var added = fastMove + new System.Numerics.Vector3(current.pos.X, current.pos.Y, current.pos.Z);
        span[0] = added.X;
        span[1] = added.Y;
        span[2] = added.Z;
        span[3] = current.uv.X;
        span[4] = current.uv.Y;
        span[5] = Normal.X;
        span[6] = Normal.Y;
        span[7] = Normal.Z;

        current = v2;
        added = fastMove + new System.Numerics.Vector3(current.pos.X, current.pos.Y, current.pos.Z);
        span[8] = added.X;
        span[9] = added.Y;
        span[10] = added.Z;
        span[11] = current.uv.X;
        span[12] = current.uv.Y;
        span[13] = Normal.X;
        span[14] = Normal.Y;
        span[15] = Normal.Z;

        current = v3;
        added = fastMove + new System.Numerics.Vector3(current.pos.X, current.pos.Y, current.pos.Z);

        span[16] = added.X;
        span[17] = added.Y;
        span[18] = added.Z;
        span[19] = current.uv.X;
        span[20] = current.uv.Y;
        span[21] = Normal.X;
        span[22] = Normal.Y;
        span[23] = Normal.Z;

        current = v4;
        added = fastMove + new System.Numerics.Vector3(current.pos.X, current.pos.Y, current.pos.Z);

        span[24] = added.X;
        span[25] = added.Y;
        span[26] = added.Z;
        span[27] = current.uv.X;
        span[28] = current.uv.Y;
        span[29] = Normal.X;
        span[30] = Normal.Y;
        span[31] = Normal.Z;
    }

    public float[] GetRawEdges()
    {
        var ret = new float[4 * 3];
        int offset = 0;

        ret[offset++] = v1.pos.X + move.X;
        ret[offset++] = v1.pos.Y + move.Y;
        ret[offset++] = v1.pos.Z + move.Z;

        ret[offset++] = v2.pos.X + move.X;
        ret[offset++] = v2.pos.Y + move.Y;
        ret[offset++] = v2.pos.Z + move.Z;

        ret[offset++] = v3.pos.X + move.X;
        ret[offset++] = v3.pos.Y + move.Y;
        ret[offset++] = v3.pos.Z + move.Z;

        ret[offset++] = v4.pos.X + move.X;
        ret[offset++] = v4.pos.Y + move.Y;
        ret[offset++] = v4.pos.Z + move.Z;
        return ret;
    }

    public void Apply()
    {
        // var verticesVector = Vector256.Create(v1.pos.X, v1.pos.Y, v1.pos.Z, v2.pos.X, v2.pos.Y, v2.pos.Z, 0f, 0f);
        // var adding = Vector256.Create(move.X, move.Y, move.Z, move.X, move.Y, move.Z, 0f, 0f);
        // var result = Vector256.Add(verticesVector, adding);
        // v1.pos.X = result[0];
        // v1.pos.Y = result[1];
        // v1.pos.Z = result[2];
        //
        // v2.pos.X = result[3];
        // v2.pos.Y = result[4];
        // v2.pos.Z = result[5];
        //
        // verticesVector = Vector256.Create(v3.pos.X, v3.pos.Y, v3.pos.Z, v4.pos.X, v4.pos.Y, v4.pos.Z, 0f, 0f);
        // result = Vector256.Add(verticesVector, adding);
        // v3.pos.X = result[0];
        // v3.pos.Y = result[1];
        // v3.pos.Z = result[2];
        //                    
        // v4.pos.X = result[3];
        // v4.pos.Y = result[4];
        // v4.pos.Z = result[5];

        v1.pos += move;
        v2.pos += move;
        v3.pos += move;
        v4.pos += move;
    }
}