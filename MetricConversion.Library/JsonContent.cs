using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MetricConverter.Library
{
    public class JsonContent : ContentResult
    {
        public JsonContent(object obj)
            //: base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        {
            Content = JsonConvert.SerializeObject(obj);
            ContentType = "application/json";
        }
    }
}
