// See https://aka.ms/new-console-template for more information

using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var sumamry = BenchmarkRunner.Run<Tests>();

public unsafe class Tests
{
    private const int N = 1000;
    private Memory<int> Mem;
    private int[] Arr;
    private int* Pt;
    FrozenDictionary<int, int> Dict;
    public Tests()
    {
        Arr = Enumerable.Range(0, N).ToArray();
        fixed (int* p = Arr)
            Pt = p;
        Dict = new Dictionary<int, int>(Arr.Select(i => new KeyValuePair<int, int>(i, i))).ToFrozenDictionary();
        Mem = Arr.AsMemory();
    }
    
    [Benchmark]
    public int Pointer()
    {
        var sp = Pt;
        int index = 0;
        for (int i = 0; i < N; i++)
        {
            if (sp[i] == N - 2)
                return index;
        }
        return index;
    }
    
    
    [Benchmark]
    public int Memory()
    {
        var sp = Mem.Span;
        int index = 0;
        for (int i = 0; i < N; i++)
        {
            if (sp[i] == N - 2)
                return index;
        }
        return index;
    }
    [Benchmark]
    public int Array()
    {
        var sp = Arr;
        int index = 0;
        for (int i = 0; i < N; i++)
        {
            if (sp[i] == N - 2)
                return index;
        }
        return index;
    }
}