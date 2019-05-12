using System.Collections.Generic;
using MetricConverter.Library.Models;
using Microsoft.Extensions.Configuration;

namespace MetricConverter.Library.Integrations
{
    public class AuditApi : HttpBase, IAuditApi
    {
        public AuditApi(IConfiguration configuration) : base(
            configuration.GetValue<string>("AppConfig:webApiBaseUrl"), "audit")
        {}
        public void Audit(ActionAuditModel model)
        {
            Post(model);
        }
    }
}
