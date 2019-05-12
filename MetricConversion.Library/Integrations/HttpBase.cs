using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MetricConverter.Library.Integrations
{
    public abstract class HttpBase
    {
        private string BaseUrl { get; }
        private string UrlSegment { get; }
        public HttpBase(string baseUrl, string urlSegment)
        {
            BaseUrl = baseUrl;
            UrlSegment = urlSegment;
        }

        public async Task<T> Get<T>(string endpoint = "")
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri($"{BaseUrl}/{UrlSegment}/{endpoint}")
            };
            //var response = await client.GetAsync("");
            var response = await client.GetAsync("");
            var stream = await response.Content.ReadAsStreamAsync();
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
