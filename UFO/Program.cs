using BenchmarkDotNet.Running;
using UFO;

BenchmarkSwitcher
    .FromAssembly(typeof(FewerStringsImpl).Assembly)
    .Run();
