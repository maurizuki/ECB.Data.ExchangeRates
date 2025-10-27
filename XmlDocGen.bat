dotnet build src\XmlDocGen\XmlDocGen.csproj -c Release -o bin
bin\XmlDocGen.exe bin\ECB.Data.ExchangeRates.dll docs --clean
