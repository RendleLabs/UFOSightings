using BenchmarkDotNet.Running;
using UFO;

// var x = "foo,bar,quux"u8;
// Span<Range> ranges = stackalloc Range[3];
// MemoryExtensions.Split(x, (byte)',');
// var dict = Utf8Impl.Run();
//
// foreach (var (key, value) in dict.OrderByDescending(p => p.Value))
// {
//     Console.WriteLine($"{key}: {value}");
// }

BenchmarkSwitcher
    .FromAssembly(typeof(FewerStringsImpl).Assembly)
    .Run();
