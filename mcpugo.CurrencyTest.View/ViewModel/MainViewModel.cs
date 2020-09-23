using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace mcpugo.CurrencyTest.View.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private CurrencyExchangeResponse currencyExchangeSelected;
        public CurrencyExchangeResponse CurrencyExchangeSelected
        {
            get => currencyExchangeSelected;
            set => Set(ref currencyExchangeSelected, value);
        }

        private ObservableCollection<CurrencyResponse> currencyList = new ObservableCollection<CurrencyResponse>();
        public ObservableCollection<CurrencyResponse> CurrencyList
        {
            get => currencyList;
            set => Set(ref currencyList, value);
        }

        public ObservableCollection<CurrencyExchangeResponse> currencyExchangeList = new ObservableCollection<CurrencyExchangeResponse>();
        public ObservableCollection<CurrencyExchangeResponse> CurrencyExchangeList
        {
            get => currencyExchangeList;
            set => Set(ref currencyExchangeList, value);
        }
    }
}
