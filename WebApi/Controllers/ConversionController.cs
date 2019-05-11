using MetricConverter.Library;
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

        [Route("/fromunits")]
        [HttpGet]
        public ActionResult GetFromUnits()
        {
            return new ContentResult();
        }

        [Route("/tounit/{fromunit}")]
        [HttpGet]
        public ActionResult GetToUnits([FromRoute] string fromUnit)
        {
            return new ContentResult();
        }

        [Route("/convert/{fromunit}/{tounit}/{value}")]
        [HttpGet]
        public ActionResult GetConversion([FromRoute] string fromUnit, [FromRoute] string toUnit, [FromRoute] double value)
        {
            return new ContentResult();
        }
    }
}