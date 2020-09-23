using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Request
{
    public class CurrencyExchangeRequest
    {
        public string Base { get; set; }
        public DateTime? Date { get; set; }
        public List<string> Rates { get; set; }
    }
}
