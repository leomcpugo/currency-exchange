using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    interface ICurrencyService
    {
        Task<ICollection<CurrencyResponse>> GetCurrencyList();
    }
}
