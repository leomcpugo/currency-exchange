using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyResponse
    {
        public CurrencyResponse(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
