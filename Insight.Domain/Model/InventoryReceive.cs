using System;

namespace Insight.Domain.Model
{
    public class InventoryReceive
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public InventoryIssue Issue { get; set; }
        public int LineNr { get; set; }
        public Item Item { get; set; }
        public double Quantity1 { get; set; }
        public double Packing { get; set; }
        public double Quantity2 { get; set; }
        public double Quantity3 { get; private set; }
        public bool IsClosed { get; set; }
    }
}
