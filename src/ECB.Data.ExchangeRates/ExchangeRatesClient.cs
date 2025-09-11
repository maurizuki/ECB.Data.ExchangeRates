// Copyright (c) 2023+ Maurizio Basaglia
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

namespace ECB.Data.ExchangeRates;

/// <summary>
///     Provides access to the EXR Dataflow (currency exchange rates) of ECB Data
///     Portal web services (https://data.ecb.europa.eu).
/// </summary>
public class ExchangeRatesClient : HttpClient
{
	private static readonly Uri DefaultBaseAddress = new("https://data-api.ecb.europa.eu/service/data/EXR/");

	private readonly IExchangeRatesParser _parser;

	/// <summary>
	///     Initializes a new instance of the ExchangeRatesClient class using a
	///     HttpClientHandler that is disposed when this instance is disposed.
	/// </summary>
	public ExchangeRatesClient() : this(new HttpClientHandler(), true)
	{
	}

	/// <summary>
	///     Initializes a new instance of the ExchangeRatesClient class with the
	///     specified handler. The handler is disposed when this instance is disposed.
	/// </summary>
	/// <param name="handler">
	///     The HttpMessageHandler responsible for processing the HTTP response
	///     messages.
	/// </param>
	/// <exception cref="ArgumentNullException">handler is null.</exception>
	public ExchangeRatesClient(HttpMessageHandler handler) : this(handler, true)
	{
	}

	/// <summary>
	///     Initializes a new instance of the ExchangeRatesClient class with the
	///     provided handler, and specifies whether that handler should be disposed
	///     when this instance is disposed.
	/// </summary>
	/// <param name="handler">
	///     The HttpMessageHandler responsible for processing the HTTP response
	///     messages.
	/// </param>
	/// <param name="disposeHandler">
	///     true if the inner handler should be disposed of by
	///     ExchangeRatesClient.Dispose; false if you intend to reuse the inner
	///     handler.
	/// </param>
	/// <exception cref="ArgumentNullException">handler is null.</exception>
	public ExchangeRatesClient(HttpMessageHandler handler, bool disposeHandler)
		: this(handler, disposeHandler, new ExchangeRatesParser())
	{
	}

	/// <summary>
	///     Initializes a new instance of the ExchangeRatesClient class with the
	///     provided handler, and specifies whether that handler should be disposed
	///     when this instance is disposed.
	/// </summary>
	/// <param name="handler">
	///     The HttpMessageHandler responsible for processing the HTTP response
	///     messages.
	/// </param>
	/// <param name="disposeHandler">
	///     true if the inner handler should be disposed of by
	///     ExchangeRatesClient.Dispose; false if you intend to reuse the inner
	///     handler.
	/// </param>
	/// <param name="parser">
	///		A custom parser for the HTTP response content.
	/// </param>
	/// <exception cref="ArgumentNullException">handler is null or parser is null.</exception>
	public ExchangeRatesClient(
		HttpMessageHandler handler,
		bool disposeHandler,
		IExchangeRatesParser parser)
		: base(handler, disposeHandler)
	{
		_parser = parser ?? throw new ArgumentNullException(nameof(parser));
		BaseAddress = DefaultBaseAddress;
	}

	/// <summary>
	///     Returns the latest available daily average exchange rates of a list of
	///     currencies.
	/// </summary>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the latest available daily average exchange rates of a list of currencies.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(params string[] currencies)
	{
		return await GetExchangeRatesAsync(MEASUREMENT_FREQUENCY_DAILY, currencies, "&lastNObservations=1");
	}

	/// <summary>
	///     Returns the daily average exchange rates of a list of currencies for a
	///     specific date.
	/// </summary>
	/// <param name="date">The reference date for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the daily average exchange rates of a list of currencies for a specific
	///     date.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime date, params string[] currencies)
	{
		return await GetDailyAverageRatesAsync(date, date, currencies);
	}

	/// <summary>
	///     Returns the daily average exchange rates of a list of currencies for a
	///     specific date range.
	/// </summary>
	/// <param name="startDate">
	///     The start date of the range for the exchange rates.
	/// </param>
	/// <param name="endDate">The end date of the range for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the daily average exchange rates of a list of currencies for a specific date
	///     range.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetDailyAverageRatesAsync(DateTime startDate, DateTime endDate, params string[] currencies)
	{
		return await GetExchangeRatesAsync(MEASUREMENT_FREQUENCY_DAILY, currencies, $"&startPeriod={startDate:yyyy-MM-dd}&endPeriod={endDate:yyyy-MM-dd}");
	}

	/// <summary>
	///     Returns the monthly average exchange rates of a list of currencies for a
	///     specific month.
	/// </summary>
	/// <param name="month">The reference month for the exchange rates (1-12).</param>
	/// <param name="year">The reference year for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the monthly average exchange rates of a list of currencies for a specific
	///     month.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int month, int year, params string[] currencies)
	{
		return await GetMonthlyAverageRatesAsync(month, year, month, year, currencies);
	}

	/// <summary>
	///     Returns the monthly average exchange rates of a list of currencies for a
	///     specific month range.
	/// </summary>
	/// <param name="startMonth">
	///     The start month of the range for the exchange rates (1-12).
	/// </param>
	/// <param name="startYear">
	///     The start year of the range for the exchange rates.
	/// </param>
	/// <param name="endMonth">
	///     The end month of the range for the exchange rates (1-12).
	/// </param>
	/// <param name="endYear">The end year of the range for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the monthly average exchange rates of a list of currencies for a specific
	///     month range.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetMonthlyAverageRatesAsync(int startMonth, int startYear, int endMonth, int endYear, params string[] currencies)
	{
		return await GetExchangeRatesAsync(MEASUREMENT_FREQUENCY_MONTHLY, currencies, $"&startPeriod={startYear:D4}-{startMonth:D2}&endPeriod={endYear:D4}-{endMonth:D2}");
	}

	/// <summary>
	///     Returns the annual average exchange rates of a list of currencies for a
	///     specific year.
	/// </summary>
	/// <param name="year">The reference year for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the annual average exchange rates of a list of currencies for a specific
	///     year.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetAnnualAverageRatesAsync(int year, params string[] currencies)
	{
		return await GetAnnualAverageRatesAsync(year, year, currencies);
	}

	/// <summary>
	///     Returns the annual average exchange rates of a list of currencies for a
	///     specific year range.
	/// </summary>
	/// <param name="startYear">
	///     The start year of the range for the exchange rates.
	/// </param>
	/// <param name="endYear">The end year of the range for the exchange rates.</param>
	/// <param name="currencies">
	///     The list of the required currencies. Leave empty to get all the
	///     available currencies.
	/// </param>
	/// <returns>
	///     A task that represents the asynchronous operation. The task result contains
	///     the annual average exchange rates of a list of currencies for a specific
	///     year range.
	/// </returns>
	/// <exception cref="HttpRequestException">
	///     The response status code does not indicate success.
	/// </exception>
	public async Task<IEnumerable<ExchangeRate>> GetAnnualAverageRatesAsync(int startYear, int endYear, params string[] currencies)
	{
		return await GetExchangeRatesAsync(MEASUREMENT_FREQUENCY_ANNUAL, currencies, $"&startPeriod={startYear:D4}&endPeriod={endYear:D4}");
	}

	private const string MEASUREMENT_FREQUENCY_DAILY = "D";
	private const string MEASUREMENT_FREQUENCY_MONTHLY = "M";
	private const string MEASUREMENT_FREQUENCY_ANNUAL = "A";

	private async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync(string frequency, string[] currencies, string parameters)
	{
		var response = await GetAsync($"{frequency}.{string.Join('+', currencies)}.EUR.SP00.A?detail=dataOnly{parameters}");

		if (!response.IsSuccessStatusCode)
		{
			throw new HttpRequestException(
				$"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase})",
				null,
				response.StatusCode
			);
		}

		return _parser.Parse(await response.Content.ReadAsStringAsync());
	}
}
