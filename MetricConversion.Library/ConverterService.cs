using System.Collections.Generic;
using MetricConverter.Library.Models;
using Microsoft.Extensions.Configuration;

namespace MetricConverter.Library
{
    public class ConverterService : IConverterService
    {
        public IConfiguration Configuration { get; }
        public ConverterService(IConfiguration config)
        {
            Configuration = config;
        }

        public List<string> GetFromUnits()
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetToUnits()
        {
            throw new System.NotImplementedException();
        }

        public List<ConversionModel> GetConversions()
        {
            throw new System.NotImplementedException();
        }

        public double Convert(string fromUnit, string toUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
