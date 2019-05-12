using MetricConverter.Library.Models;

namespace MetricConverter.Library.Repositories
{
    public interface IAuditRepository
    {
        void AuditAction(ActionAuditModel model);
    }
}
