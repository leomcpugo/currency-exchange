﻿using mcpugo.CurrencyTest.Shared.Model;
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
        public async Task<CurrencyExchangeModel> GetExchangeRates(string code)
        {
            var requestUrl = $"https://api.frankfurter.app/latest?base={code}";
            var typedResponse = await HttpGetRequest<ApiCurrencyExchangeResponse>(requestUrl);

            return new CurrencyExchangeModel
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
