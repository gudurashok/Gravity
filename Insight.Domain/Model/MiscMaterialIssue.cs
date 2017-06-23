using System;

namespace Insight.Domain.Model
{
    public class MiscMaterialIssue
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public int LineNr { get; set; }
        public Item Item { get; set; }
        public double Quantity1 { get; set; }
        public double Quantity2 { get; set; }
        public double Quantity3 { get; private set; }
    }
}
