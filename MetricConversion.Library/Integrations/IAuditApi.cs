using MetricConverter.Library.Models;

namespace MetricConverter.Library.Integrations
{
    public interface IAuditApi
    {
        void Audit(ActionAuditModel model);
    }
}
