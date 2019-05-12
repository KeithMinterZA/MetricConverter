using System.Collections.Generic;

namespace MetricConverter.Library.Models
{
    public class ConversionModel
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public double FromValue { get; set;}
        public double ToValue { get; set; }
        public string Formula { get; set; }
    }

    //TODO Remove
    //public class AppConfig
    //{
    //    public List<ConversionModel> Conversions { get; set; }
    //}
}
