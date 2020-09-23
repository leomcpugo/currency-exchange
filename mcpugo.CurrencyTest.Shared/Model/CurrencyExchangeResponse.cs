using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyExchangeResponse
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public ICollection<CurrencyExchangeRate> RateList { get; set; }
    }
    public class CurrencyExchangeRate
    {
        public string To { get; set; }
        public float Rate { get; set; }
    }
}
