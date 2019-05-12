using MetricConverter.Library.Models;
using MetricConverter.Library.Repositories;
using MetricConverter.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace MetricConverter.WebApi.Test
{
    public class TestAuditController
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1Audit()
        {
            // Arrange
            var actionModel = new ActionAuditModel();
            var mockrepo = new Mock<IAuditRepository>();
            var mockhttp = new Mock<IHttpContextAccessor>();
            mockrepo.Setup(serv => serv.AuditAction(actionModel));
            var controller = new AuditController(mockrepo.Object, mockhttp.Object);

            // Act
            controller.Post(actionModel);
        }
    }
}