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

using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace ECB.Data.ExchangeRates;

/// <summary>
///     Provides a method to parse the response of an HTTP request
///     to ECB Data Portal web services.
/// </summary>
public class ExchangeRatesParser : IExchangeRatesParser
{
	/// <summary>
	///     Parses the response of an HTTP request to ECB Data
	///     Portal web services.
	/// </summary>
	/// <param name="source">The XML response to parse.</param>
	/// <returns>The currency exchange rates.</returns>
	/// <exception cref="XmlException">
	///     The response content does not contain a root element or
	///     does not contain the namespace of prefix 'generic'.
	/// </exception>
	public IEnumerable<ExchangeRate> Parse(string source)
	{
		var document = XDocument.Parse(source);

		var genericNamespace = document.Root!.GetNamespaceOfPrefix("generic")
			?? throw new XmlException("Namespace of prefix 'generic' is missing.");

		var seriesKeyValueName = XName.Get("Value", genericNamespace.NamespaceName);
		var obsName = XName.Get("Obs", genericNamespace.NamespaceName);
		var obsDimensionName = XName.Get("ObsDimension", genericNamespace.NamespaceName);
		var obsValueName = XName.Get("ObsValue", genericNamespace.NamespaceName);

		return document.Descendants(XName.Get("Series", genericNamespace.NamespaceName))
			.Select(
				a =>
				{
					var seriesKeyValues = a.Descendants(seriesKeyValueName)
						.ToDictionary(
							b => b.Attribute("id")!.Value,
							b => b.Attribute("value")?.Value
						);
					return new
					{
						Frequency =
							seriesKeyValues.GetValueOrDefault("FREQ"),
						Currency =
							seriesKeyValues.GetValueOrDefault("CURRENCY"),
						CurrencyDenominator =
							seriesKeyValues.GetValueOrDefault("CURRENCY_DENOM"),
						ExchangeRateType =
							seriesKeyValues.GetValueOrDefault("EXR_TYPE"),
						SeriesVariation =
							seriesKeyValues.GetValueOrDefault("EXR_SUFFIX"),
						Obs = a.Descendants(obsName),
					};
				}
			)
			.SelectMany(
				a => a.Obs,
				(a, b) => new ExchangeRate
				{
					Frequency = a.Frequency,
					Currency = a.Currency,
					CurrencyDenominator = a.CurrencyDenominator,
					ExchangeRateType = a.ExchangeRateType,
					SeriesVariation = a.SeriesVariation,
					TimePeriod = b.Descendants(obsDimensionName)
						.FirstOrDefault()?.Attribute("value")?.Value,
					Value = decimal.TryParse(
						b.Descendants(obsValueName)
							.FirstOrDefault()?.Attribute("value")?.Value ?? "0",
						NumberStyles.Number,
						CultureInfo.InvariantCulture,
						out var value
					)
						? value
						: 0,
				}
			);
	}
}
