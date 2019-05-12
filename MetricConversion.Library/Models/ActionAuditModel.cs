using System;

namespace MetricConverter.Library.Models
{
    public class ActionAuditModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Component { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDatetime { get; set; }
    }
}
