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
            set
            {
                if (currencyExchangeSelected != value)
                {
                    currencyExchangeSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<CurrencyResponse> currencyList = new ObservableCollection<CurrencyResponse>();
        public ObservableCollection<CurrencyResponse> CurrencyList
        {
            get => currencyList;
            set
            {
                if (currencyList != value)
                {
                    currencyList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CurrencyExchangeResponse> currencyExchangeList = new ObservableCollection<CurrencyExchangeResponse>();
        public ObservableCollection<CurrencyExchangeResponse> CurrencyExchangeList
        {
            get
            {
                return currencyExchangeList;
            }
            set
            {
                if (currencyExchangeList != value)
                {
                    currencyExchangeList = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
