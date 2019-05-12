using MetricConverter.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetricConverter.Services.Library
{
    public interface IConverterService
    {
        IEnumerable<string> GetFromUnits();
        IEnumerable<string> GetToUnits(string fromUnit);
        IEnumerable<ConversionModel> GetConversions();
        ConversionModel Convert(string fromUnit, string toUnit, double value);
    }
}
