using MetricConverter.Library.Models;
using MetricConverter.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MetricConverter.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private IAuditRepository Repo { get; set; }
        public AuditController(IAuditRepository repo)
        {
            Repo = repo;
        }
 
        // POST api/
        [HttpPost]
        public void Post([FromBody] ActionAuditModel model)
        {
            Repo.AuditAction(model);
        }
    }
}
