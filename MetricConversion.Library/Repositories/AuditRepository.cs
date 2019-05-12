using MetricConverter.Library.Models;
using MetricConverter.Library.Services;

namespace MetricConverter.Library.Repositories
{
    public class AuditRepository : DapperRepositoryBase, IAuditRepository
    {
        public readonly static string AuditActionCommand = @"INSERT INTO tblActionAudit([User], Component, Action, Value, CreatedDatetime)"
                            + " VALUES(@User, @Component, @Action, @Value, GETDATE())";
        public AuditRepository(IAppConfiguration config) : base(config.GetString("ConnectionStrings:ActionAudit"))
        {

        }

        public void AuditAction(ActionAuditModel model)
        {
            Add(model, AuditActionCommand);
        }
    }
}
