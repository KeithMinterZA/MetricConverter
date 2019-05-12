using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            return arr;
        }

        public ConversionModel Convert(string fromUnit, string toUnit, double value)
        {
            //Get the conversion for the from and to unit specified in config
            var convers = GetConversions();
            var conversions = from conv in convers
                             where conv.FromUnit == fromUnit && conv.ToUnit == toUnit
                             select conv;
            var conversion = conversions.First();
            conversion.FromValue = value;
            //if it is a rate based conversion
            if (string.IsNullOrEmpty(conversion.Formula))
                conversion.ToValue = conversion.FromValue * conversion.Rate;             
            else //otherwise if we need to run a formula, use reflection to get the formula and run it
                ReflectionCalculate(conversion);

            return conversion;
        }

        private static void ReflectionCalculate(ConversionModel conversion)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var refType = conversion.Formula.Split('|')[0];
            var refMethod = conversion.Formula.Split('|')[1];
            Type type = assembly.GetType(refType);

            var obj = Activator.CreateInstance(type);

            // Alternately you could get the MethodInfo for the TestRunner.Run method
            var args = new object[] { conversion.FromValue};
            conversion.ToValue = (double)type.InvokeMember(refMethod,
                              BindingFlags.Default | BindingFlags.InvokeMethod,
                              null,
                              obj,
                              args);
        }
    }
}
