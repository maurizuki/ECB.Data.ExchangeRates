# ECB.Data.ExchangeRates

[![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/maurizuki/ECB.Data.ExchangeRates/build.yml)](https://github.com/maurizuki/ECB.Data.ExchangeRates/actions/workflows/build.yml)
[![Nuget](https://img.shields.io/nuget/v/ECB.Data.ExchangeRates)](https://www.nuget.org/packages/ECB.Data.ExchangeRates)
[![Nuget](https://img.shields.io/nuget/dt/ECB.Data.ExchangeRates)](https://www.nuget.org/packages/ECB.Data.ExchangeRates)

Provides access to the EXR Dataflow (currency exchange rates) of [ECB Data Portal](https://data.ecb.europa.eu) web services.

## Getting started

Use the following command to add the package to a .NET project:

```PowerShell
dotnet add package ECB.Data.ExchangeRates
```

More options are available on the [package page](https://www.nuget.org/packages/ECB.Data.ExchangeRates) of the NuGet Gallery website.

The console application [ECB.Data.ExchangeRates.ConsoleApp](./src/ECB.Data.ExchangeRates.ConsoleApp) (ECBEXR.exe) is intended as an example on how to use the web services client in a real scenario.

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
## Build and pack

Use the following command to build the source code and create the package to be released:

```PowerShell
dotnet pack -c Release --include-symbols --include-source
```

## Documentation

* [ECB.Data.ExchangeRates API reference](./docs/ECB.Data.ExchangeRates.md)
* [Official ECB Data Portal web services documentation](https://data.ecb.europa.eu/help/api)

## Contributors

<a href="https://github.com/maurizuki/ECB.Data.ExchangeRates/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=maurizuki/ECB.Data.ExchangeRates" />
</a>

Made with [contrib.rocks](https://contrib.rocks).
