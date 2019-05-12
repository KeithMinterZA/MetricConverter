using System;

namespace MetricConverter.Library.Exceptions
{
    public class ConversionNotFoundException : Exception
    {
        public ConversionNotFoundException() : base("The conversion could not be found with the given from and to units.")
        { }
        public ConversionNotFoundException(string fromUnit, string toUnit) : base($"The conversion could not be found with the given from [{fromUnit}] and to [{toUnit}] units.")
        { }
    }
}
