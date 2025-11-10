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

namespace ECB.Data.ExchangeRates.Tests;

public class TestResults
{
	[Fact]
	public async Task Empty()
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				_ => new HttpResponseMessage
				{
					Content = new StringContent(string.Empty),
				}
			)
		);

		var rates = await client.GetDailyAverageRatesAsync();

		Assert.Empty(rates);
	}

	[Fact]
	public async Task SingleSeriesSingleObs()
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				_ => new HttpResponseMessage
				{
					Content = new StringContent(
						@"<?xml version=""1.0"" encoding=""UTF-8""?>
<message:GenericData xmlns:message=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message"" xmlns:generic=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic"">
	<message:DataSet>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""USD""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.9038""/>
			</generic:Obs>
		</generic:Series>
	</message:DataSet>
</message:GenericData>"
					),
				}
			)
		);

		var rates = await client.GetDailyAverageRatesAsync();

		var rate = Assert.Single(rates);
		Assert.Equal("D", rate.Frequency);
		Assert.Equal("USD", rate.Currency);
		Assert.Equal("EUR", rate.CurrencyDenominator);
		Assert.Equal("SP00", rate.ExchangeRateType);
		Assert.Equal("A", rate.SeriesVariation);
		Assert.Equal("2002-01-02", rate.TimePeriod);
		Assert.Equal(0.9038m, rate.Value);
	}

	[Fact]
	public async Task SingleSeriesMultipleObs()
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				_ => new HttpResponseMessage
				{
					Content = new StringContent(
						@"<?xml version=""1.0"" encoding=""UTF-8""?>
<message:GenericData xmlns:message=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message"" xmlns:generic=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic"">
	<message:DataSet>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""USD""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.9038""/>
			</generic:Obs>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-03""/>
				<generic:ObsValue value=""0.9036""/>
			</generic:Obs>
		</generic:Series>
	</message:DataSet>
</message:GenericData>"
					),
				}
			)
		);

		var rates = await client.GetDailyAverageRatesAsync();

		Assert.Collection(
			rates,
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("USD", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-02", rate.TimePeriod);
				Assert.Equal(0.9038m, rate.Value);
			},
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("USD", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-03", rate.TimePeriod);
				Assert.Equal(0.9036m, rate.Value);
			}
		);
	}

	[Fact]
	public async Task MultipleSeriesSingleObs()
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				_ => new HttpResponseMessage
				{
					Content = new StringContent(
						@"<?xml version=""1.0"" encoding=""UTF-8""?>
<message:GenericData xmlns:message=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message"" xmlns:generic=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic"">
	<message:DataSet>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""GBP""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.6262""/>
			</generic:Obs>
		</generic:Series>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""USD""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.9038""/>
			</generic:Obs>
		</generic:Series>
	</message:DataSet>
</message:GenericData>"
					),
				}
			)
		);

		var rates = await client.GetDailyAverageRatesAsync();

		Assert.Collection(
			rates,
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("GBP", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-02", rate.TimePeriod);
				Assert.Equal(0.6262m, rate.Value);
			},
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("USD", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-02", rate.TimePeriod);
				Assert.Equal(0.9038m, rate.Value);
			}
		);
	}

	[Fact]
	public async Task MultipleSeriesMultipleObs()
	{
		var client = new ExchangeRatesClient(
			new CustomHttpMessageHandler(
				_ => new HttpResponseMessage
				{
					Content = new StringContent(
						@"<?xml version=""1.0"" encoding=""UTF-8""?>
<message:GenericData xmlns:message=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message"" xmlns:generic=""http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic"">
	<message:DataSet>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""GBP""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.6262""/>
			</generic:Obs>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-03""/>
				<generic:ObsValue value=""0.6254""/>
			</generic:Obs>
		</generic:Series>
		<generic:Series>
			<generic:SeriesKey>
				<generic:Value id=""FREQ"" value=""D""/>
				<generic:Value id=""CURRENCY"" value=""USD""/>
				<generic:Value id=""CURRENCY_DENOM"" value=""EUR""/>
				<generic:Value id=""EXR_TYPE"" value=""SP00""/>
				<generic:Value id=""EXR_SUFFIX"" value=""A""/>
			</generic:SeriesKey>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-02""/>
				<generic:ObsValue value=""0.9038""/>
			</generic:Obs>
			<generic:Obs>
				<generic:ObsDimension value=""2002-01-03""/>
				<generic:ObsValue value=""0.9036""/>
			</generic:Obs>
		</generic:Series>
	</message:DataSet>
</message:GenericData>"
					),
				}
			)
		);

		var rates = await client.GetDailyAverageRatesAsync();

		Assert.Collection(
			rates,
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("GBP", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-02", rate.TimePeriod);
				Assert.Equal(0.6262m, rate.Value);
			},
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("GBP", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-03", rate.TimePeriod);
				Assert.Equal(0.6254m, rate.Value);
			},
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("USD", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-02", rate.TimePeriod);
				Assert.Equal(0.9038m, rate.Value);
			},
			rate =>
			{
				Assert.Equal("D", rate.Frequency);
				Assert.Equal("USD", rate.Currency);
				Assert.Equal("EUR", rate.CurrencyDenominator);
				Assert.Equal("SP00", rate.ExchangeRateType);
				Assert.Equal("A", rate.SeriesVariation);
				Assert.Equal("2002-01-03", rate.TimePeriod);
				Assert.Equal(0.9036m, rate.Value);
			}
		);
	}
}
