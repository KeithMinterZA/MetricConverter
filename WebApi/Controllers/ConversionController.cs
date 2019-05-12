using MetricConverter.Library;
using MetricConverter.Services.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace MetricConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private IConverterService Converter { get; }
        private IHttpContextAccessor ContextAccessor { get; set; }
        private string RequestUser { get; set; }
        public ConversionController(IConverterService converterService, IHttpContextAccessor httpContextAccessor)
        {
            Converter = converterService;
            ContextAccessor = httpContextAccessor;
            RequestUser = ContextAccessor.HttpContext != null && ContextAccessor.HttpContext.User.Identity.IsAuthenticated ? 
                ContextAccessor.HttpContext.User.Identity.Name : "Unauthenticated";
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

        [Route("[action]/{fromunit}/{tounit}")]
        [HttpGet]
        public ActionResult Convert([FromRoute] string fromUnit, [FromRoute] string toUnit, [FromQuery] string fromValue)
        {
            var response = Converter.Convert(fromUnit, toUnit, double.Parse(fromValue));
            return new JsonContent(response.ToValue);
        }
    }
}