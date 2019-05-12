using System;
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
            var uri = $"{BaseUrl}/{UrlSegment}/{endpoint}";
            
            var client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
            var response = await client.GetAsync("");
            var stream = await response.Content.ReadAsStreamAsync();
            var serializer = new DataContractJsonSerializer(typeof(T));
            var obj = serializer.ReadObject(stream);
            return (T)obj;
        }

        public async void Post<T>(T model, string endpoint = "")
        {
            var uri = $"{BaseUrl}/{UrlSegment}/{endpoint}";

            var client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
            var response = await client.PostAsJsonAsync(endpoint, model);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Could not connect to endpoint [{BaseUrl}/{UrlSegment}/{endpoint}]");
        }
    }
}
