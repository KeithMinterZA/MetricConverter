using System.Collections.Generic;
using MetricConverter.Library.Models;
using Microsoft.Extensions.Configuration;

namespace MetricConverter.Library.Integrations
{
    public class WebApi : HttpBase, IWebApi
    {
        public WebApi(IConfiguration configuration) : base(
            configuration.GetValue<string>("AppConfig:webApiBaseUrl"), "conversion")
        {}

        public IEnumerable<string> GetFromUnits()
        {
            return Get<IEnumerable<string>>("fromunits").Result;
        }

        public IEnumerable<string> GetToUnits(string fromUnit)
        {
            return Get<IEnumerable<string>>($"tounits/{fromUnit}").Result;
        }

        public double GetConversion(string fromUnit, string toUnit, double fromValue)
        {
            return Get<double>($"convert/{fromUnit}/{toUnit}/{fromValue}").Result;
        }
    }
}
