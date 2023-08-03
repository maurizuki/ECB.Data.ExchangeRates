// Copyright (c) 2023 Maurizio Basaglia
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

namespace ECB.Data.ExchangeRates.Tests;

public class TestRequests
{
	private const string BaseAddress = "https://data-api.ecb.europa.eu/service/data/EXR/";

	[Theory]
	[InlineData(new string[0], BaseAddress + "D..EUR.SP00.A?detail=dataOnly&lastNObservations=1")]
	[InlineData(new[] {"USD"}, BaseAddress + "D.USD.EUR.SP00.A?detail=dataOnly&lastNObservations=1")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "D.USD+GBP.EUR.SP00.A?detail=dataOnly&lastNObservations=1")]
	public async Task GetDailyAverageRatesAsync1(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetDailyAverageRatesAsync(currencies);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "D..EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2002-01-02")]
	[InlineData(new[] {"USD"}, BaseAddress + "D.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2002-01-02")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "D.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2002-01-02")]
	public async Task GetDailyAverageRatesAsync2(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetDailyAverageRatesAsync(new DateTime(2002, 1, 2), currencies);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "D..EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2003-12-31")]
	[InlineData(new[] {"USD"}, BaseAddress + "D.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2003-12-31")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "D.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01-02&endPeriod=2003-12-31")]
	public async Task GetDailyAverageRatesAsync3(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetDailyAverageRatesAsync(
			new DateTime(2002, 1, 2),
			new DateTime(2003, 12, 31),
			currencies
		);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "M..EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2002-01")]
	[InlineData(new[] {"USD"}, BaseAddress + "M.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2002-01")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "M.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2002-01")]
	public async Task GetMonthlyAverageRatesAsync1(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetMonthlyAverageRatesAsync(1, 2002, currencies);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "M..EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2003-12")]
	[InlineData(new[] {"USD"}, BaseAddress + "M.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2003-12")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "M.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002-01&endPeriod=2003-12")]
	public async Task GetMonthlyAverageRatesAsync2(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetMonthlyAverageRatesAsync(1, 2002, 12, 2003, currencies);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "A..EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2002")]
	[InlineData(new[] {"USD"}, BaseAddress + "A.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2002")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "A.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2002")]
	public async Task GetAnnualAverageRatesAsync1(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetAnnualAverageRatesAsync(2002, currencies);
	}

	[Theory]
	[InlineData(new string[0], BaseAddress + "A..EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2003")]
	[InlineData(new[] {"USD"}, BaseAddress + "A.USD.EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2003")]
	[InlineData(new[] {"USD", "GBP"}, BaseAddress + "A.USD+GBP.EUR.SP00.A?detail=dataOnly&startPeriod=2002&endPeriod=2003")]
	public async Task GetAnnualAverageRatesAsync2(string[] currencies, string expectedRequestUri)
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				request =>
				{
					Assert.Equal(HttpMethod.Get, request.Method);

					Assert.Equal(expectedRequestUri, request.RequestUri?.ToString());

					return new HttpResponseMessage();
				}
			)
		);

		await client.GetAnnualAverageRatesAsync(2002, 2003, currencies);
	}
}
