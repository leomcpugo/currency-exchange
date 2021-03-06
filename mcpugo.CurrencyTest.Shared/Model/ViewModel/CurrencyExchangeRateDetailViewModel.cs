﻿using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.ViewModel
{
    /// <summary>
    /// View Model for the Currency Exchange Rate Detail
    /// </summary>
    public class CurrencyExchangeRateDetailViewModel : BaseViewModel
    {
        string amount;
        public string Amount
        {
            get => amount;
            set => Set(ref amount, value);
        }

        CurrencyExchangeModel currencyExchange;
        public CurrencyExchangeModel CurrencyExchange
        {
            get => currencyExchange;
            set => Set(ref currencyExchange, value);
        }
    }
}
