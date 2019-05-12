using NUnit.Framework;
using Moq;
using MetricConverter.Services.Library;
using MetricConverter.Library.Services;
using MetricConverter.Library.Exceptions;
using System.Linq;

namespace MetricConverter.Library.Tests
{
    public class TestConverterService
    {
        private IConverterService service;

        public TestConverterService()
        {
        }

        [SetUp]
        public void Setup()
        {
            var mockConfig = new Mock<IAppConfiguration>();
            mockConfig.Setup<string>(p => p.GetString("AppConfig:Conversions")).Returns("[{ 'FromUnit': 'Centimeter', 'ToUnit': 'Inch', 'Rate': 0.4, 'Type': 'Length'}, { 'FromUnit': 'Inch', 'ToUnit': 'Centimeter', 'Rate': 2.4, 'Type': 'Length'}, { 'FromUnit': 'Fahrenheit', 'ToUnit': 'Celcius', 'Formula': 'MetricConverter.Library.PluginFormulas.FahrenheitFormulaService|FromFahrenheitToCelcius', 'Type': 'Temperature'}, { 'FromUnit': 'Celcius', 'ToUnit': 'Fahrenheit', 'Formula': 'MetricConverter.Library.PluginFormulas.FahrenheitFormulaService|FromCelciusToFahrenheit', 'Type': 'Temperature'}]");
            service = new ConverterService(mockConfig.Object);
        }

        [Test]
        public void Test1CelciusToFahrenheit()
        {
            var far = service.Convert("Celcius", "Fahrenheit", 10);
            Assert.IsTrue(far.ToValue == 50);
        }
        [Test]
        public void Test2FahrenheitToCelcius()
        {
            var far = service.Convert("Fahrenheit", "Celcius", 50);
            Assert.IsTrue(far.ToValue.Equals(10));
        }

        [Test]
        public void Test3ConversionNotFoundException()
        {
            Assert.Throws<ConversionNotFoundException>(() => service.Convert("blah bla blah", "I don't say blah bla blah!", 0));
        }

        [Test]
        public void Test4GetFromUnits1()
        {
            var far = service.GetFromUnits();

            var hasCent = from unit in far
                        where unit == "Centimeter"
                        select unit;

            Assert.IsTrue(hasCent.Contains("Centimeter"));
        }

        [Test]
        public void Test5GetFromUnits2()
        {
            var far = service.GetFromUnits();

            var hasInch = from unit in far
                          where unit == "Inch"
                          select unit;
            Assert.IsTrue(hasInch.Contains("Inch"));
        }

        [Test]
        public void Test6GetToUnits()
        {
            var far = service.GetToUnits("Inch");

            var hasInch = from unit in far
                          where unit == "Centimeter"
                          select unit;
            Assert.IsTrue(hasInch.Contains("Centimeter"));
        }
    }
}