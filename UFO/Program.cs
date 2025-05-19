using BenchmarkDotNet.Running;
using UFO;

// var dict = KeyHackImpl.Run();
//
// foreach (var (key, value) in dict.OrderByDescending(p => p.Value))
// {
//     Console.WriteLine($"{key}: {value}");
// }

BenchmarkSwitcher
    .FromAssembly(typeof(FewerStringsImpl).Assembly)
    .Run();
