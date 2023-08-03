# ExchangeRatesClient constructor (1 of 3)

Initializes a new instance of the ExchangeRatesClient class using a HttpClientHandler that is disposed when this instance is disposed.

```csharp
public ExchangeRatesClient()
```

## See Also

* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient constructor (2 of 3)

Initializes a new instance of the ExchangeRatesClient class with the specified handler. The handler is disposed when this instance is disposed.

```csharp
public ExchangeRatesClient(HttpMessageHandler handler)
```

| parameter | description |
| --- | --- |
| handler | The HttpMessageHandler responsible for processing the HTTP response messages. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | handler is null. |

## See Also

* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

---

# ExchangeRatesClient constructor (3 of 3)

Initializes a new instance of the ExchangeRatesClient class with the provided handler, and specifies whether that handler should be disposed when this instance is disposed.

```csharp
public ExchangeRatesClient(HttpMessageHandler handler, bool disposeHandler)
```

| parameter | description |
| --- | --- |
| handler | The HttpMessageHandler responsible for processing the HTTP response messages. |
| disposeHandler | true if the inner handler should be disposed of by ExchangeRatesClient.Dispose; false if you intend to reuse the inner handler. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | handler is null. |

## See Also

* class [ExchangeRatesClient](../ExchangeRatesClient.md)
* namespace [ECB.Data.ExchangeRates](../../ECB.Data.ExchangeRates.md)

<!-- DO NOT EDIT: generated by xmldocmd for ECB.Data.ExchangeRates.dll -->