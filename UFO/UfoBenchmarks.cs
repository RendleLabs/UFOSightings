using BenchmarkDotNet.Attributes;

namespace UFO;

[MemoryDiagnoser]
public class UfoBenchmarks
{
    [Benchmark(Baseline = true)]
    public Dictionary<string, int> Basic() => BasicImpl.Run();
    
    [Benchmark]
    public Dictionary<string, int> FewerStrings() => FewerStringsImpl.Run();
    
    [Benchmark]
    public Dictionary<string, int> DictionaryHack() => DictionaryHackImpl.Run();
    
}