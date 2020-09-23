using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    public class CurrencyResponse : BaseViewModel
    {
        private string code;
        public string Code
        {
            get => code;
            set => Set(ref code, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => Set(ref description, value);
        }
    }
}
