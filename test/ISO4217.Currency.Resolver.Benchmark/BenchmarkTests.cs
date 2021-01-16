using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ISO4217.Currency.Resolver.Benchmark
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    [MemoryDiagnoser]
    public class BenchmarkTests
    {
        private ISO4217Resolver _iso4217 = new ISO4217Resolver();

        [Benchmark]
        public string ByLookupCountryTest()
        {
            return _iso4217.FindByCountry("TURKEY")
                .First().CurrencyName;
        }

        [Benchmark]
        public string ByLinqCountryTest()
        {
            return _iso4217.CountryCurrencies
                .FirstOrDefault(c => c.Country == "TURKEY").CurrencyName;
        }
    }
}
