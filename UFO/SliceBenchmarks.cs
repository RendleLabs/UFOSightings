using BenchmarkDotNet.Attributes;

namespace UFO;

public class SliceBenchmarks
{
    private const string Source = "abcdefghijklmnopqrstuvwxyz";
    
    [Benchmark(Baseline = true)]
    public int Slice()
    {
        ReadOnlySpan<char> span = Source.AsSpan();
        int index = span.IndexOf('m');
        return span.Slice(0, index).Length;
    }
    
    [Benchmark]
    public int Range()
    {
        ReadOnlySpan<char> span = Source.AsSpan();
        int index = span.IndexOf('m');
        return span[..index].Length;
    }
}