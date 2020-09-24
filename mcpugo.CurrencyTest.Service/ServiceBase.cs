using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mcpugo.CurrencyTest.Service
{
    public class ServiceBase
    {
        private static readonly HttpClient client = new HttpClient();

        protected async Task<T> HttpGetRequest<T>(string requestUrl)
        {
            var responseString = await client.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
