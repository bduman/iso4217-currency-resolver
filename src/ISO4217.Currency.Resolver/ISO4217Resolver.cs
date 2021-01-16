using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ISO4217.Currency.Resolver
{
    public class ISO4217Resolver
    {
        private readonly string[] _excludedCountries = new string[] {
            "ANTARCTICA",
            "PALESTINE, STATE OF",
            "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS"
        };

        private List<CountryCurrency> _countryCurrencies;

        public List<CountryCurrency> CountryCurrencies => _countryCurrencies;

        private ILookup<string, CountryCurrency> LookupByCountry;
        private ILookup<string, CountryCurrency> LookupByCurrency;
        private ILookup<short, CountryCurrency> LookupByNumber;

        public ISO4217Resolver()
        {
            var doc = XDocument.Load("list_one.xml");

            _countryCurrencies = doc.Descendants("CcyNtry").Select(c =>
            {
                var countryName = c.Element("CtryNm").Value;

                if (_excludedCountries.Contains(countryName))
                {
                    return null;
                }

                short.TryParse(c.Element("CcyMnrUnts").Value, out short exponent);

                return new CountryCurrency()
                {
                    Country = countryName,
                    CurrencyName = c.Element("CcyNm").Value,
                    Currency = c.Element("Ccy").Value,
                    Number = short.Parse(c.Element("CcyNbr").Value),
                    Exponent = exponent,
                };
            })
            .Where(c => c != null)
            .ToList();

            this.Lookups();
        }

        private void Lookups()
        {
            LookupByCountry = _countryCurrencies.ToLookup(c => c.Country);
            LookupByCurrency = _countryCurrencies.ToLookup(c => c.Currency);
            LookupByNumber = _countryCurrencies.ToLookup(c => c.Number);
        }

        public IEnumerable<CountryCurrency> FindByCountry(string country)
        {
            return LookupByCountry[country.ToUpperInvariant()];
        }

        public IEnumerable<CountryCurrency> FindByCurrency(string currency)
        {
            return LookupByCurrency[currency.ToUpperInvariant()];
        }

        public IEnumerable<CountryCurrency> FindByNumber(short number)
        {
            return LookupByNumber[number];
        }
    }
}
