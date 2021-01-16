# ISO4217.Currency.Resolver

![Nuget Push](https://github.com/bduman/iso4217-currency-resolver/workflows/Nuget%20Push/badge.svg) [![Nuget](https://img.shields.io/nuget/v/ISO4217.Currency.Resolver)](https://www.nuget.org/packages/ISO4217.Currency.Resolver/)

A library provides ISO 4217 standards that includes currency, code, country and more.

## Install with NuGet package

```
Install-Package ISO4217.Currency.Resolver
```

## What is ISO-4217 ?

ISO 4217 is a standard published by International Organization for Standardization (ISO) that defines alpha codes and numeric codes for the representation of currencies and provides information about the relationships between individual currencies and their minor units. - [wikipedia.org](https://en.wikipedia.org/wiki/ISO_4217)

## Where did list_one.xml file come from ?

list_one.xml file in source provided by [currency-iso.org](https://www.currency-iso.org/dam/downloads/lists/list_one.xml) 

## How to use a library ?

``` csharp
ISO4217Resolver resolver = new ISO4217Resolver();

// Get currency info by country name
var countryCurrency = resolver.FindByCountry("Turkey"); 

// Get country list that uses USD currency
var countryCurrencyList = resolver.FindByCurrency("USD");

// Get country list that uses 840 numeric code which is representation of USD
var countryCurrencyList = resolver.FindByNumber(840);

// or inquiry without method - result of currencyNameOfTurkey is "Turkish Lira"
var currencyNameOfTurkey = resolver.CountryCurrencies
        .FirstOrDefault(c => c.Country == "TURKEY").CurrencyName;
```
