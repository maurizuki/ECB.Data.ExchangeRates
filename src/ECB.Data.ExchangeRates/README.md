# ECB.Data.ExchangeRates

Provides access to the EXR Dataflow (currency exchange rates) of [ECB Data Portal](https://data.ecb.europa.eu) web services.

## Getting started

To add ECB.Data.ExchangeRates to your project, you can use the following NuGet Package Manager command:

```PowerShell
Install-Package ECB.Data.ExchangeRates
```

More options are available on the [ECB.Data.ExchangeRates page](https://www.nuget.org/packages/ECB.Data.ExchangeRates) of the NuGet Gallery website.

The console application [ECB.Data.ExchangeRates.ConsoleApp](https://github.com/maurizuki/ECB.Data.ExchangeRates/tree/v2.1.0-rc.1/src/ECB.Data.ExchangeRates.ConsoleApp) (ECBEXR.exe) is intended as an example on how to use the web services client in a real scenario.

## Remarks

The class ExchangeRatesClient is derived from [HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient) that is intended to be instantiated once and re-used throughout the life of an application. Instantiating an ExchangeRatesClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors. Below is an example using ExchangeRatesClient correctly.

```C#
public class GoodController : ApiController
{
    private static readonly ExchangeRatesClient ExchangeRatesClient;

    static GoodController()
    {
        ExchangeRatesClient = new ExchangeRatesClient();
    }
}
```

## Documentation

* [ECB.Data.ExchangeRates API reference](https://github.com/maurizuki/ECB.Data.ExchangeRates/blob/v2.1.0-rc.1/docs/ECB.Data.ExchangeRates.md)
* [Official ECB Data Portal web services documentation](https://data.ecb.europa.eu/help/api)
