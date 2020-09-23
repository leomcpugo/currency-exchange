using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    public class CurrencyExchangeService : ServiceBase, ICurrencyExchangeService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<CurrencyExchangeResponse> GetExchangeRates(CurrencyExchangeRequest request)
        {
            var requestUrl = $"https://api.ratesapi.io/api/latest?base{request.Base}";
            var responseString = await client.GetStringAsync(requestUrl);
            var typedResponse = JsonConvert.DeserializeObject<ApiCurrencyExchangeResponse>(responseString);

            return new CurrencyExchangeResponse
            {
                Base = typedResponse.Base,
                Date = typedResponse.Date,
                Rates = typedResponse.Rates.Select(x => new CurrencyExchangeRateResponse
                {
                    Code = x.Key,
                    Rate = x.Value
                }).ToList()
            };
        }

        private class ApiCurrencyExchangeResponse
        {
            public string Base { get; set; }
            public DateTime Date { get; set; }
            public IDictionary<string, float> Rates { get; set; }
        }
    }
}
