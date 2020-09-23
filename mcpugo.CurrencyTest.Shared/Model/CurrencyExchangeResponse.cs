using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyExchangeResponse
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public IDictionary<string, float> Rates { get; set; }
    }
}
