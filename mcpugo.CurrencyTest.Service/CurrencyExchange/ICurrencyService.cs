using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    interface ICurrencyService
    {
        ICollection<CurrencyResponse> GetCurrencyList();
    }
}
