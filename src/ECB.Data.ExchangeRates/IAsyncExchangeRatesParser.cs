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
///     Defines an asynchronous method to parse the response of an HTTP request to
///     ECB Data Portal web services.
/// </summary>
public interface IAsyncExchangeRatesParser
{
	/// <summary>
	///     Parses asynchronously the response of an HTTP request to ECB Data
	///     Portal web services.
	/// </summary>
	/// <param name="stream">The stream that contains the XML response to
	///		parse.</param>
	/// <param name="cancellationToken">A cancellation token that can be
	///		used to receive notice of cancellation.</param>
	/// <returns>A task that represents the asynchronous operation.
	///		The task result contains the currency exchange rates.</returns>
	Task<IEnumerable<ExchangeRate>> ParseAsync(Stream stream, CancellationToken cancellationToken);
}
