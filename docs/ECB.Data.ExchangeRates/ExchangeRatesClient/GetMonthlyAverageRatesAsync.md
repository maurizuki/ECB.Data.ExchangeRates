# ExchangeRatesClient.GetMonthlyAverageRatesAsync method (1 of 4)

Returns the monthly average exchange rates of a list of currencies for a specific month.

```csharp
public Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int month, int year, 
    params string[] currencies)
```

| parameter | description |
| --- | --- |
| month | The reference month for the exchange rates (1-12). |
| year | The reference year for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |

## Return Value

A task that represents the asynchronous operation. The task result contains the monthly average exchange rates of a list of currencies for a specific month.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetMonthlyAverageRatesAsync method (2 of 4)

Returns the monthly average exchange rates of a list of currencies for a specific month.

```csharp
public Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int month, int year, 
    string[] currencies, CancellationToken cancellationToken)
```

| parameter | description |
| --- | --- |
| month | The reference month for the exchange rates (1-12). |
| year | The reference year for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |
| cancellationToken | A cancellation token that can be used to receive notice of cancellation. |

## Return Value

A task that represents the asynchronous operation. The task result contains the monthly average exchange rates of a list of currencies for a specific month.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |
| OperationCanceledException | The cancellation token was canceled. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetMonthlyAverageRatesAsync method (3 of 4)

Returns the monthly average exchange rates of a list of currencies for a specific month range.

```csharp
public Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int startMonth, int startYear, 
    int endMonth, int endYear, params string[] currencies)
```

| parameter | description |
| --- | --- |
| startMonth | The start month of the range for the exchange rates (1-12). |
| startYear | The start year of the range for the exchange rates. |
| endMonth | The end month of the range for the exchange rates (1-12). |
| endYear | The end year of the range for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |

## Return Value

A task that represents the asynchronous operation. The task result contains the monthly average exchange rates of a list of currencies for a specific month range.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetMonthlyAverageRatesAsync method (4 of 4)

Returns the monthly average exchange rates of a list of currencies for a specific month range.

```csharp
public Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int startMonth, int startYear, 
    int endMonth, int endYear, string[] currencies, CancellationToken cancellationToken)
```

| parameter | description |
| --- | --- |
| startMonth | The start month of the range for the exchange rates (1-12). |
| startYear | The start year of the range for the exchange rates. |
| endMonth | The end month of the range for the exchange rates (1-12). |
| endYear | The end year of the range for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |
| cancellationToken | A cancellation token that can be used to receive notice of cancellation. |

## Return Value

A task that represents the asynchronous operation. The task result contains the monthly average exchange rates of a list of currencies for a specific month range.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |
| OperationCanceledException | The cancellation token was canceled. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

<!-- DO NOT EDIT: generated by xmldocmd for ECB.Data.ExchangeRates.dll -->
