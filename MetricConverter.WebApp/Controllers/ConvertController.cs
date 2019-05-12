using System.Collections.Generic;
using MetricConverter.Library.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace MetricConverter.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        private IWebApi WebApi { get; }
        public ConvertController(IWebApi webApi)
        {
            WebApi = webApi;
        }

        [HttpGet("[action]")]
        public IEnumerable<string> FromUnits()
        {
            return WebApi.GetFromUnits();
        }

        [HttpGet("[action]/{fromUnit}")]
        public IEnumerable<string> ToUnits(string fromUnit)
        {
            return WebApi.GetToUnits(fromUnit);
        }

        [HttpGet("[action]/{fromUnit}/{tounit}/{fromvalue}")]
        public double Convert(string fromUnit, string toUnit, double fromValue)
        {
            return WebApi.GetConversion(fromUnit, toUnit, fromValue);
        }
    }
}
