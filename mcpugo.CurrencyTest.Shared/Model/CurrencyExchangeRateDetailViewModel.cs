using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    /// <summary>
    /// View Model for the Currency Exchange Rate Detail
    /// </summary>
    public class CurrencyExchangeRateDetailViewModel : BaseViewModel
    {
        CurrencyExchangeResponse currencyExchange;
        public CurrencyExchangeResponse CurrencyExchange
        {
            get => currencyExchange;
            set => Set(ref currencyExchange, value);
        }
    }
}
