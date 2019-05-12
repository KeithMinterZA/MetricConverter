using System.Collections.Generic;
using MetricConverter.Library.Integrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricConverter.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        private IWebApi WebApi { get; }
        private IAuditApi AuditApi { get; }
        private IHttpContextAccessor ContextAccessor { get; set; }
        private string RequestUser { get; set; }
        public ConvertController(IAuditApi auditApi, IWebApi webApi, IHttpContextAccessor httpContextAccessor)
        {
            WebApi = webApi;
            AuditApi = auditApi;
            ContextAccessor = httpContextAccessor;
            RequestUser = ContextAccessor.HttpContext.User.Identity.IsAuthenticated ? ContextAccessor.HttpContext.User.Identity.Name : "Unauthenticated";
        }

        [HttpGet("[action]")]
        public IEnumerable<string> FromUnits()
        {
            AuditApi.Audit(new Library.Models.ActionAuditModel
            {
                Action = "FromUnits",
                Component = "ConvertController",
                User = RequestUser
            });
            return WebApi.GetFromUnits();
        }

        [HttpGet("[action]/{fromUnit}")]
        public IEnumerable<string> ToUnits(string fromUnit)
        {
            AuditApi.Audit(new Library.Models.ActionAuditModel
            {
                Action = "ToUnits",
                Component = "ConvertController",
                User = RequestUser,
                Value = "fromUnit " + fromUnit
            });
            return WebApi.GetToUnits(fromUnit);
        }

        [HttpGet("[action]/{fromUnit}/{tounit}/{fromvalue}")]
        public double Convert(string fromUnit, string toUnit, double fromValue)
        {
            AuditApi.Audit(new Library.Models.ActionAuditModel
            {
                Action = "Convert",
                Component = "ConvertController",
                User = RequestUser,
                Value = $"fromUnit: '{fromUnit}', toUnit: '{toUnit}', value: '{fromValue}'"
            });
            return WebApi.GetConversion(fromUnit, toUnit, fromValue);
        }
    }
}
