using System.Runtime.Intrinsics;
using OpenTK.Mathematics;
using Sys = System.Numerics;

namespace RaceOchka;

public static class Utils
{
    public static bool IsNegative(this Vector3i vec) => vec.X < 0 || vec.Y < 0 || vec.Z < 0;
    public static bool IsLessThan(this Vector3i vec, int n) => vec.X < n && vec.Y < n && vec.Z < n;

    public static bool IsInRange(this Vector3i vec, int s, int e) =>
        vec.X >= s && vec.X < e && vec.Y >= s && vec.Y < e && vec.Z >= s && vec.Z < e;

    public static bool IsInRange(this Vector3 vec, Vector3 s, Vector3 e) => vec.X >= s.X && vec.X <= e.X &&
                                                                            vec.Y >= s.Y && vec.Y <= e.Y &&
                                                                            vec.Z >= s.Z && vec.Z <= e.Z;

    public static Vector3i Round(this Vector3 vec) => new Vector3i((int)vec.X, (int)vec.Y, (int)vec.Z);

    public static Vector3 Round(this Vector3 vec, int digit = 0) => new Vector3(MathF.Round(vec.X, digit),
        MathF.Round(vec.Y, digit), MathF.Round(vec.Z, digit));

    public static T[] SumList<T>(this IEnumerable<IEnumerable<T>> lists)
    {
        var len = lists.Sum(i => i.Count());
        var temp = lists.ToArray();
        var ret = new T[len];
        int offset = 0;
        for (int i = 0; i < lists.Count(); i++)
        {
            temp[i].ToArray().CopyTo(ret, offset);
            offset += temp[i].Count();
        }

        return ret;
    }

    public static T[] ReplaceNulls<T>(this IEnumerable<T> list, T replace)
    {
        var enumerable = list.ToArray();
        for (int i = 0; i < enumerable.Count(); i++)
        {
            if (enumerable[i] is null)
                enumerable[i] = replace;
        }

        return enumerable;
    }

    public const float G = 9.8f;

    public static Sys.Vector3 ToSys(this Vector3 otk) => new Sys.Vector3(otk.X, otk.Y, otk.Z);

    public static float Sum(this Vector3 vector) => vector.X + vector.Y + vector.Z;
    public static float Sum(this Vector4 vector) => vector.X + vector.Y + vector.Z + vector.W;

    public static Sys.Vector3 ToFastVector(this Vector3 vector)
    {
        return new Sys.Vector3(vector.X, vector.Y, vector.Z);
    }

    public static Vector128<int> ToFastVector(this Vector3i vector)
    {
        return Vector128.Create(vector.X, vector.Y, vector.Z, 0);
    }

    public static Vector3i FastAdd(Vector3i otk, Vector128<int> fast)
    {
        var sum = otk.ToFastVector() + fast;
        return new Vector3i(sum[0], sum[1], sum[2]);
    }

    public static Vector3 FastAdd(Vector3 otk, Sys.Vector3 fast)
    {
        var sum = otk.ToFastVector() + fast;
        return new Vector3(sum.X, sum.Y, sum.Z);
    }

    public static Vector3 FastMul(Vector3 otk, Sys.Vector3 fast)
    {
        var sum = otk.ToFastVector() * fast;
        return new Vector3(sum.X, sum.Y, sum.Z);
    }

    public static unsafe int IndexOf<T>(T* pointer, T value, int length) where T : unmanaged, IEquatable<T>
    {
        for (int i = 0; i < length; i++)
        {
            if (pointer[i].Equals(value))
                return i;
        }
        return -1;
    }
}