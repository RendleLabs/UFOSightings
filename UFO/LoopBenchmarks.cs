using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace UFO;

[MemoryDiagnoser]
public class LoopBenchmarks
{
    private static readonly List<int> NumberList = Enumerable.Range(0, 1000).ToList();
    private static readonly int[] NumberArray = Enumerable.Range(0, 1000).ToArray();
    
    [Benchmark(Baseline = true)]
    public int ListForeach()
    {
        int acc = 0;
        
        foreach (var n in NumberList)
        {
            acc += n;
        }

        return acc;
    }
    
    [Benchmark]
    public int ListFor()
    {
        int acc = 0;
        
        for (int i = 0; i < 1000; i++)
        {
            acc += NumberList[i];
        }

        return acc;
    }

    [Benchmark]
    public int ListAsSpan()
    {
        int acc = 0;
        var span = CollectionsMarshal.AsSpan(NumberList);
        foreach (var n in span)
        {
            acc += n;
        }

        return acc;
    }

    [Benchmark]
    public int Linq() => NumberList.Sum();
}