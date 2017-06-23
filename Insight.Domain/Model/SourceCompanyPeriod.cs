using System;

namespace Insight.Domain.Model
{
    public class SourceCompanyPeriod
    {
        public string CoCode { get; set; }
        public string CoName { get; set; }
        public string GroupCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
