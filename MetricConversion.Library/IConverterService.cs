using System.Collections.Generic;

namespace MetricConverter.Library
{
    public interface IConverterService
    {
        List<string> GetFromUnits();
        List<string> GetToUnits();
        List<Models.ConversionModel> GetConversions();
        double Convert(string fromUnit, string toUnit);
    }
}
