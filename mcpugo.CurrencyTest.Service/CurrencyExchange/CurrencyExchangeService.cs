using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service.CurrencyExchange
{
    public class CurrencyExchangeService : ServiceBase, ICurrencyExchangeService
    {
        public async Task<CurrencyExchangeResponse> GetExchangeRates(CurrencyExchangeRequest request)
        {
            var requestUrl = $"https://api.frankfurter.app/latest?base={request.Base}";
            var typedResponse = await HttpGetRequest<ApiCurrencyExchangeResponse>(requestUrl);

            return new CurrencyExchangeResponse
            {
                Code = typedResponse.Base,
                Date = typedResponse.Date,
                Rates = new ObservableCollection<CurrencyExchangeRateResponse>(
                    typedResponse.Rates.Select(x => new CurrencyExchangeRateResponse
                    {
                        Code = x.Key,
                        Rate = x.Value,
                        ConvertedAmount = x.Value
                    }))
            };
        }

        private class ApiCurrencyExchangeResponse
        {
            public string Base { get; set; }
            public DateTime Date { get; set; }
            public IDictionary<string, decimal> Rates { get; set; }
        }
    }
}
