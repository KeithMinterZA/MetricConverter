namespace MetricConverter.Library.PluginFormulas
{
    public class FahrenheitFormulaService
    {
        public double FromFahrenheitToCelcius(double value)
        {
            return (value - 32) / 1.8;
        }

        public double FromCelciusToFahrenheit(double value)
        {
            return value * 1.8 + 32.00;
        }
    }
}
