using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    /// <summary>
    /// Service that handles the Currency Exchange
    /// </summary>
    interface ICurrencyExchangeService
    {
        /// <summary>
        /// Gets the Exchange Rates for a Currency
        /// </summary>
        /// <param name="code">Code of the Currency</param>
        /// <returns></returns>
        public Task<CurrencyExchangeResponse> GetExchangeRates(string code);
    }
}
