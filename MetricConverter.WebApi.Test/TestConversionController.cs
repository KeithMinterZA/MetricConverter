using MetricConverter.Services.Library;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using MetricConverter.WebApi.Controllers;
using MetricConverter.Library;

namespace MetricConverter.WebApi.Test
{
    public class TestConversionController
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1FromUnits()
        {
            // Arrange
            var mockservice = new Mock<IConverterService>();
            var mockhttp = new Mock<IHttpContextAccessor>();
            mockservice.Setup(serv => serv.GetFromUnits()).Returns(GetUnits());
            var controller = new ConversionController(mockservice.Object, mockhttp.Object);

            // Act
            var result = (JsonContent)controller.FromUnits();

            // Assert
            Assert.IsTrue(result.Content.Equals("[\"Centimeters\",\"Meters\"]"));
        }

        [Test]
        public void Test2ToUnits()
        {
            // Arrange
            var mockservice = new Mock<IConverterService>();
            var mockhttp = new Mock<IHttpContextAccessor>();
            mockservice.Setup(serv => serv.GetToUnits("Inch")).Returns(GetUnits());
            var controller = new ConversionController(mockservice.Object, mockhttp.Object);

            // Act
            var result = (JsonContent)controller.ToUnits("Inch");

            // Assert
            Assert.IsTrue(result.Content.Equals("[\"Centimeters\",\"Meters\"]"));
        }

        [Test]
        public void Test3ConvertUnits()
        {
            // Arrange
            var mockservice = new Mock<IConverterService>();
            var mockhttp = new Mock<IHttpContextAccessor>();
            mockservice.Setup(serv => serv.Convert("Inch", "Centimeter", 8)).Returns(new Library.Models.ConversionModel
            {
                FromUnit = "Inch",
                ToUnit = "Centimeter",
                Rate = 0.4,
                FromValue = 10,
                Type = "Length",
                ToValue = 4
            });
            var controller = new ConversionController(mockservice.Object, mockhttp.Object);

            // Act
            var result = (JsonContent)controller.Convert("Inch", "Centimeter", "8");

            // Assert
            Assert.IsTrue(result.Content.Equals("4.0"));
        }

        private IEnumerable<string> GetUnits()
        {
            return new[] { "Centimeters", "Meters" };
        }
    }
}
