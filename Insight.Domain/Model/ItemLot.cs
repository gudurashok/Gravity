using System;

namespace Insight.Domain.Model
{
    public class ItemLot
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string LotNr { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public int LineNr { get; set; }
        public Item Item { get; set; }
        public double Quantity1 { get; set; }
        public double Packing { get; set; }
        public double Quantity2 { get; set; }
        public double Quantity3 { get; set; }
        public bool IsClosed { private get; set; }
    }
}
