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

namespace ECB.Data.ExchangeRates;

/// <summary>
///     Represent the result of a currency exchange rate measurement.
/// </summary>
public sealed class ExchangeRate
{
	/// <summary>
	///     Gets or sets the frequency at which the exchange rate is measured.
	/// </summary>
	public string? Frequency { get; set; }

	/// <summary>
	///     Gets or sets the currency measured.
	/// </summary>
	public string? Currency { get; set; }

	/// <summary>
	///     Gets or sets the currency against which the exchange rate is measured.
	/// </summary>
	public string? CurrencyDenominator { get; set; }

	/// <summary>
	///     Gets or sets the type of the exchange rate.
	/// </summary>
	public string? ExchangeRateType { get; set; }

	/// <summary>
	///     Gets or sets the time series variation.
	/// </summary>
	public string? SeriesVariation { get; set; }

	/// <summary>
	///     Gets or sets the time period measured according to the frequency.
	/// </summary>
	public string? TimePeriod { get; set; }

	/// <summary>
	///     Gets or sets the exchange rate value measured.
	/// </summary>
	public decimal Value { get; set; }
}
