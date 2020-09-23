using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    interface ICurrencyExchangeService
    {
        public Task<CurrencyExchangeResponse> GetExchangeRates(CurrencyExchangeRequest request);
    }
}
