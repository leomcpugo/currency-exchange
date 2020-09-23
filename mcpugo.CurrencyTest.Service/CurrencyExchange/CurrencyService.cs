using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    public class CurrencyService : ICurrencyService
    {
        public ICollection<CurrencyResponse> GetCurrencyList()
        {
            return new List<CurrencyResponse>
            {
                new CurrencyResponse("EUR")
            };
        }
    }
}
