using BenchmarkDotNet.Attributes;

namespace UFO;

[MemoryDiagnoser]
public class SplitBenchmarks
{
    private static readonly string Source = "foo,bar,quux";
    
    [Benchmark(Baseline = true)]
    public string StringSplit() => Source.Split(',').First();
    
    [Benchmark]
    public string SpanSplit()
    {
        var fields = Source.AsSpan().Split(',');
        if (fields.MoveNext()) return fields.Current.ToString();
        return "";
    }

    [Benchmark]
    public string SpanSplit8()
    {
        Span<Range> ranges = stackalloc Range[3];
        Source.AsSpan().Split(ranges, ',');
        return Source[ranges[0]];
    }
}