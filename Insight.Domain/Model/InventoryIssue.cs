using System;

namespace Insight.Domain.Model
{
    public class InventoryIssue
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public string LotId { get; set; }
        public Account Account { get; set; }
        public double Quantity1 { get; set; }
        public double Quantity2 { get; set; }
        public double Quantity3 { get; set; }
    }
}
