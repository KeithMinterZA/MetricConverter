using NUnit.Framework;
using Moq;
using MetricConverter.Library.Services;
using MetricConverter.Library.Repositories;
using MetricConverter.Library.Models;

namespace MetricConverter.Library.Test
{
    public class TestAuditRepository
    {
        private IAuditRepository repository;
        [SetUp]
        public void Setup()
        {
            var mockConfig = new Mock<IAppConfiguration>();
            mockConfig.Setup<string>(p => p.GetString("ConnectionStrings:ActionAudit"))
                .Returns("Server=(localdb)\\mssqllocaldb;Database=dbActionAudit;Trusted_Connection=True;MultipleActiveResultSets=true");
            repository = new AuditRepository(mockConfig.Object);
        }

        [Test]
        public void Test1AuditInsert()
        {
            var model = new ActionAuditModel
            {
                Action = "Test1Auditinsert",
                Component = "TestAuditRepository",
                User = "testUser",
                Value = "test"
            };
            repository.AuditAction(model);

            var newModel = repository.GetAction(model);

            Assert.IsTrue(model.User.Equals(newModel.User));
            Assert.IsTrue(model.Action.Equals(newModel.Action));
            Assert.IsTrue(model.Component.Equals(newModel.Component));
            Assert.IsTrue(model.Value.Equals(newModel.Value));
        }
    }
}
