using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MetricConverter.Library
{
    public class JsonContent : ContentResult
    {
        public JsonContent(object obj)
        {
            Content = JsonConvert.SerializeObject(obj);
            ContentType = "application/json";            
        }
    }
}
