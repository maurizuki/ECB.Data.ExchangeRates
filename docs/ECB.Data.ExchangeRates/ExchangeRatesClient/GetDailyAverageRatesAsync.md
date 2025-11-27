# ExchangeRatesClient.GetDailyAverageRatesAsync method (1 of 6)

Returns the latest available daily average exchange rates of a list of currencies.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(params string[] currencies)
```

| parameter | description |
| --- | --- |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |

## Return Value

A task that represents the asynchronous operation. The task result contains the latest available daily average exchange rates of a list of currencies.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetDailyAverageRatesAsync method (2 of 6)

Returns the daily average exchange rates of a list of currencies for a specific date.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime date, 
    params string[] currencies)
```

| parameter | description |
| --- | --- |
| date | The reference date for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |

## Return Value

A task that represents the asynchronous operation. The task result contains the daily average exchange rates of a list of currencies for a specific date.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetDailyAverageRatesAsync method (3 of 6)

Returns the latest available daily average exchange rates of a list of currencies.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(string[] currencies, 
    CancellationToken cancellationToken)
```

| parameter | description |
| --- | --- |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |
| cancellationToken | A cancellation token that can be used to receive notice of cancellation. |

## Return Value

A task that represents the asynchronous operation. The task result contains the latest available daily average exchange rates of a list of currencies.

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

# ExchangeRatesClient.GetDailyAverageRatesAsync method (4 of 6)

Returns the daily average exchange rates of a list of currencies for a specific date range.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime startDate, 
    DateTime endDate, params string[] currencies)
```

| parameter | description |
| --- | --- |
| startDate | The start date of the range for the exchange rates. |
| endDate | The end date of the range for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |

## Return Value

A task that represents the asynchronous operation. The task result contains the daily average exchange rates of a list of currencies for a specific date range.

## Exceptions

| exception | condition |
| --- | --- |
| HttpRequestException | The response status code does not indicate success. |

## See Also

* class [ExchangeRate](../ExchangeRate.md)
* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient.GetDailyAverageRatesAsync method (5 of 6)

Returns the daily average exchange rates of a list of currencies for a specific date.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime date, 
    string[] currencies, CancellationToken cancellationToken)
```

| parameter | description |
| --- | --- |
| date | The reference date for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |
| cancellationToken | A cancellation token that can be used to receive notice of cancellation. |

## Return Value

A task that represents the asynchronous operation. The task result contains the daily average exchange rates of a list of currencies for a specific date.

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

# ExchangeRatesClient.GetDailyAverageRatesAsync method (6 of 6)

Returns the daily average exchange rates of a list of currencies for a specific date range.

```csharp
public Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime startDate, 
    DateTime endDate, string[] currencies, CancellationToken cancellationToken)
```

| parameter | description |
| --- | --- |
| startDate | The start date of the range for the exchange rates. |
| endDate | The end date of the range for the exchange rates. |
| currencies | The list of the required currencies. Leave empty to get all the available currencies. |
| cancellationToken | A cancellation token that can be used to receive notice of cancellation. |

## Return Value

A task that represents the asynchronous operation. The task result contains the daily average exchange rates of a list of currencies for a specific date range.

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
