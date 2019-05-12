using MetricConverter.Library.PluginFormulas;
using NUnit.Framework;

namespace MetricConverter.Library.Test
{
    class TestPlugins
    {
        [Test]
        public void Test1CelciusToFahrenheit()
        {
            var service = new FahrenheitFormulaService();
            var far = service.FromCelciusToFahrenheit(0);
            Assert.IsTrue(far == 32);
        }

        [Test]
        public void Test2FahrenheitToCelcius()
        {
            var service = new FahrenheitFormulaService();
            var far = service.FromFahrenheitToCelcius(32);
            Assert.IsTrue(far == 0);
        }
    }
}
