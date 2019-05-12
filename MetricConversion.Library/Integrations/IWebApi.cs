using MetricConverter.Library.Models;
using System.Collections.Generic;

namespace MetricConverter.Library.Integrations
{
    public interface IWebApi
    {
        IEnumerable<string> GetFromUnits();
        IEnumerable<string> GetToUnits(string fromUnit);
        double GetConversion(string fromUnit, string toUnit, double fromValue);
    }
}
