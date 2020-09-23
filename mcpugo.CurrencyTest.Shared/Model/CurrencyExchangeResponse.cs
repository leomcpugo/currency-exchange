using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyExchangeResponse
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public ICollection<CurrencyExchangeRateResponse> Rates { get; set; }
    }

    public class CurrencyExchangeRateResponse
    {
        public string Code { get; set; }
        public decimal Rate { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
