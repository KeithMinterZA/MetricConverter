using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricConverter.Library.Models
{
    public class ConversionModel
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
    }
}
