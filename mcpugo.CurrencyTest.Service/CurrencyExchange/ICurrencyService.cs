using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    /// <summary>
    /// Service that handles the Currency
    /// </summary>
    interface ICurrencyService
    {
        /// <summary>
        /// Gets the Currency list
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CurrencyResponse>> GetCurrencyList();
    }
}
