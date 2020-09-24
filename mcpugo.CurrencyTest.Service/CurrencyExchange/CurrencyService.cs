using mcpugo.CurrencyTest.Shared.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    public class CurrencyService : ServiceBase, ICurrencyService
    {
        public async Task<ICollection<CurrencyModel>> GetCurrencyList()
        {
            var requestUrl = $"https://api.frankfurter.app/currencies";
            var typedResponse = await HttpGetRequest<IDictionary<string, string>>(requestUrl);

            return typedResponse.Select(x => new CurrencyModel
            {
                Code = x.Key,
                Description = x.Value
            }).ToList();
        }
    }
}
