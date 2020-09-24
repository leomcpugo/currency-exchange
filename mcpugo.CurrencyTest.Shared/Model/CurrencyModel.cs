using System;
using System.Collections.Generic;
using System.Text;

namespace mcpugo.CurrencyTest.Shared.Model
{
    /// <summary>
    /// Response for a Currency Request
    /// </summary>
    public class CurrencyModel : BaseViewModel
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
