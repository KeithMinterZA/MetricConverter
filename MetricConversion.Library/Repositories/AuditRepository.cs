using MetricConverter.Library.Models;
using MetricConverter.Library.Services;

namespace MetricConverter.Library.Repositories
{
    public class AuditRepository : DapperRepositoryBase, IAuditRepository
    {
        public readonly static string AuditActionCommand = @"INSERT INTO tblActionAudit([User], Component, Action, Value, CreatedDatetime)"
                            + " VALUES(@User, @Component, @Action, @Value, GETDATE())";
        public readonly static string FindAuditCommand = "SELECT TOP(1) * FROM tblActionAudit WITH (NOLOCK)"
                            + " WHERE [User] = '{0}' AND Component = '{1}' AND Action = '{2}' AND Value = '{3}'";
        public AuditRepository(IAppConfiguration config) : base(config.GetString("ConnectionStrings:ActionAudit"))
        {

        }

        public void AuditAction(ActionAuditModel model)
        {
            Add(model, AuditActionCommand);
        }

        public ActionAuditModel GetAction(ActionAuditModel model)
        {
            var cmd = string.Format(FindAuditCommand, model.User, model.Component, model.Action, model.Value);
            return Find< ActionAuditModel>(cmd);
        }
    }
}
