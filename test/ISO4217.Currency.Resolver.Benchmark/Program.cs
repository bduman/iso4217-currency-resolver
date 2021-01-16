using BenchmarkDotNet.Running;

namespace ISO4217.Currency.Resolver.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}
