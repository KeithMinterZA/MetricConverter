using MetricConverter.Library;
using MetricConverter.Services.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MetricConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private IConverterService Converter { get; }
        private IConfiguration Configuration { get; }
        public ConversionController(IConfiguration config, IConverterService converterService)
        {
            Configuration = config;
            Converter = converterService;
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult FromUnits()
        {
            var response = Converter.GetFromUnits();
            return new JsonContent(response);
        }

        [Route("[action]/{fromunit}")]
        [HttpGet]
        public ActionResult ToUnits([FromRoute] string fromUnit)
        {
            var response = Converter.GetToUnits(fromUnit);
            return new JsonContent(response);
        }

        [Route("[action]/{fromunit}/{tounit}/{value}")]
        [HttpGet]
        public ActionResult Convert([FromRoute] string fromUnit, [FromRoute] string toUnit, [FromRoute] double value)
        {
            var response = Converter.Convert(fromUnit, toUnit, value);
            return new JsonContent(response.ToValue);
        }
    }
}