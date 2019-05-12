using MetricConverter.Library.Models;
using MetricConverter.Library.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetricConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {

        private IAuditRepository Repo { get; set; }
        private IHttpContextAccessor ContextAccessor { get; set; }
        private string RequestUser { get; set; }
        public AuditController(IAuditRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            Repo = repo;
            ContextAccessor = httpContextAccessor;
            RequestUser = ContextAccessor.HttpContext.User.Identity.IsAuthenticated ? ContextAccessor.HttpContext.User.Identity.Name : "Unauthenticated";
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] ActionAuditModel model)
        {
            Repo.AuditAction(model);
        }

        [HttpGet("[action]")]
        public string Ping()
        {
            return "Pong";
        }
    }
}
