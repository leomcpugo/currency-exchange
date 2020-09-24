using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private CurrencyExchangeModel currencyExchangeSelected;
        public CurrencyExchangeModel CurrencyExchangeSelected
        {
            get => currencyExchangeSelected;
            set => Set(ref currencyExchangeSelected, value);
        }

        private ObservableCollection<CurrencyModel> currencyList = new ObservableCollection<CurrencyModel>();
        public ObservableCollection<CurrencyModel> CurrencyList
        {
            get => currencyList;
            set => Set(ref currencyList, value);
        }

        // CHILDS
        private CurrencyExchangeRateDetailViewModel currencyExchangeRateDetail = new CurrencyExchangeRateDetailViewModel();
        public CurrencyExchangeRateDetailViewModel CurrencyExchangeRateDetail
        {
            get => currencyExchangeRateDetail;
            set => Set(ref currencyExchangeRateDetail, value);
        }
    }
}
