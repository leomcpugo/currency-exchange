using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyExchangeResponse : BaseViewModel
    {
        private string code;
        public string Code
        {
            get => code;
            set => Set(ref code, value);
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set => Set(ref date, value);
        }

        private ObservableCollection<CurrencyExchangeRateResponse> rates;
        public ObservableCollection<CurrencyExchangeRateResponse> Rates
        {
            get => rates;
            set => Set(ref rates, value);
        }
    }

    public class CurrencyExchangeRateResponse : BaseViewModel
    {
        private string code;
        public string Code
        {
            get => code;
            set => Set(ref code, value);
        }

        private decimal rate;
        public decimal Rate
        {
            get => rate;
            set => Set(ref rate, value);
        }

        private decimal convertedAmount;
        public decimal ConvertedAmount
        {
            get => convertedAmount;
            set => Set(ref convertedAmount, value);
        }
    }
}
