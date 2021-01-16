using System.Linq;
using Xunit;

namespace ISO4217.Currency.Resolver.Tests
{
    public class FindByTests
    {
        private readonly ISO4217Resolver _iso4217Resolver = new ISO4217Resolver();

        [Theory]
        [InlineData("TURKEY", "Turkish Lira", 949, "TRY")]
        [InlineData("UNITED STATES OF AMERICA (THE)", "US Dollar", 840, "USD")]
        [InlineData("CANADA", "Canadian Dollar", 124, "CAD")]
        [InlineData("GERMANY", "Euro", 978, "EUR")]
        public void FindByCountry_ReturnExpectedCurrencyName(string expectedCountry,
            string expectedCurrencyName, short expectedNumber,
            string expectedCurrency)
        {
            var countryCurrency = _iso4217Resolver.FindByCountry(expectedCountry).First();

            var actualCountryName = countryCurrency.Country;
            var actualCurrencyName = countryCurrency.CurrencyName;
            var actualNumber = countryCurrency.Number;
            var actualCurrency = countryCurrency.Currency;

            Assert.Equal(expectedCountry, actualCountryName);
            Assert.Equal(expectedCurrencyName, actualCurrencyName);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrency, actualCurrency);
        }

        [Theory]
        [InlineData("TURKEY", "Turkish Lira", 949, "TRY")]
        [InlineData("UNITED STATES OF AMERICA (THE)", "US Dollar", 840, "USD")]
        [InlineData("CANADA", "Canadian Dollar", 124, "CAD")]
        [InlineData("GERMANY", "Euro", 978, "EUR")]
        public void FindByCurrency_ReturnExpectedCurrencyName(string expectedCountry,
            string expectedCurrencyName, short expectedNumber,
            string expectedCurrency)
        {
            var countryCurrency = _iso4217Resolver.FindByCurrency(expectedCurrency)
                .Where(c => c.Country == expectedCountry).First();

            var actualCountryName = countryCurrency.Country;
            var actualCurrencyName = countryCurrency.CurrencyName;
            var actualNumber = countryCurrency.Number;
            var actualCurrency = countryCurrency.Currency;

            Assert.Equal(expectedCountry, actualCountryName);
            Assert.Equal(expectedCurrencyName, actualCurrencyName);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrency, actualCurrency);
        }

        [Theory]
        [InlineData("TURKEY", "Turkish Lira", 949, "TRY")]
        [InlineData("UNITED STATES OF AMERICA (THE)", "US Dollar", 840, "USD")]
        [InlineData("CANADA", "Canadian Dollar", 124, "CAD")]
        [InlineData("GERMANY", "Euro", 978, "EUR")]
        public void FindByNumber_ReturnExpectedCurrencyName(string expectedCountry,
            string expectedCurrencyName, short expectedNumber,
            string expectedCurrency)
        {
            var countryCurrency = _iso4217Resolver.FindByNumber(expectedNumber)
                .Where(c => c.Country == expectedCountry).First();

            var actualCountryName = countryCurrency.Country;
            var actualCurrencyName = countryCurrency.CurrencyName;
            var actualNumber = countryCurrency.Number;
            var actualCurrency = countryCurrency.Currency;

            Assert.Equal(expectedCountry, actualCountryName);
            Assert.Equal(expectedCurrencyName, actualCurrencyName);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrency, actualCurrency);
        }
    }
}
