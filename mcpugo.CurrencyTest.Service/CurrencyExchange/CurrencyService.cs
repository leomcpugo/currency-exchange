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
    public class CurrencyService : ICurrencyService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ICollection<CurrencyResponse>> GetCurrencyList()
        {
            var requestUrl = $"https://openexchangerates.org/api/currencies.json";
            var responseString = await client.GetStringAsync(requestUrl);
            var typedResponse = JsonConvert.DeserializeObject<IDictionary<string, string>>(responseString);

            return typedResponse.Select(x => new CurrencyResponse
            {
                Code = x.Key,
                Description = x.Value
            }).ToList();
        }
    }
}
