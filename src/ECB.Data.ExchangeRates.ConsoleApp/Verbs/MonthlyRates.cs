﻿// Copyright (c) 2023+ Maurizio Basaglia
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

using CommandLine;

namespace ECB.Data.ExchangeRates.ConsoleApp.Verbs;

[Verb("monthly", HelpText = "Monthly average exchange rates for specific month and year.")]
public class MonthlyRates
{
	[Value(0, Required = true, HelpText = "Reference month for the exchange rates (1-12).")]
	public int Month { get; set; }

	[Value(1, Required = true, HelpText = "Reference year for the exchange rates.")]
	public int Year { get; set; }

	[Value(2, HelpText = "List the required currencies. Leave empty to get all the valid currencies.")]
	public IEnumerable<string> Currencies { get; set; } = new List<string>();

	public static void Execute(ExchangeRatesClient client, MonthlyRates options)
	{
		var rates = client.GetMonthlyAverageRatesAsync(
			options.Month,
			options.Year,
			options.Currencies.ToArray()
		).Result;

		Console.WriteLine("Month    Currency  Currency den.  Exchange rate");
		foreach (var rate in rates)
		{
			Console.WriteLine(
				$"{rate.TimePeriod}  {rate.Currency,-3}       {rate.CurrencyDenominator,-3}         {rate.Value,16:N6}"
			);
		}
	}
}
