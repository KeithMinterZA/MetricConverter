using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricConverter.Library.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MetricConverter.Services.Library
{
    public class ConverterService : IConverterService
    {
        public IConfiguration Configuration { get; }
        public ConverterService(IConfiguration config)
        {
            Configuration = config;
        }

        public IEnumerable<string> GetFromUnits()
        {
            var convers = GetConversions();
            return from conversion in convers
                select conversion.FromUnit;
        }

        public IEnumerable<string> GetToUnits(string fromUnit)
        {
            var convers = GetConversions();
            return from conversion in convers
                   where conversion.FromUnit == fromUnit
                   select conversion.ToUnit;
        }

        public IEnumerable<ConversionModel> GetConversions()
        {
            var convs = Configuration.GetValue<string>("AppConfig:Conversions");
            var arr = JsonConvert.DeserializeObject<IEnumerable<ConversionModel>>(convs);
            //var convs = Configuration.GetSection("AppConfig");
            //return convs;
            return arr;
        }

        public ConversionModel Convert(string fromUnit, string toUnit, double value)
        {
            var convers = GetConversions();
            var conversions = from conv in convers
                             where conv.FromUnit == fromUnit && conv.ToUnit == toUnit
                             select conv;
            var conversion = conversions.First();
            conversion.FromValue = value;
            conversion.ToValue = conversion.FromValue * conversion.Rate;
            return conversion;
        }
    }
}
