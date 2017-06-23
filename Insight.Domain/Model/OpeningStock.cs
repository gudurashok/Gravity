using System;

namespace Insight.Domain.Model
{
    public class OpeningStock
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public Warehouse WareHouse { get; set; }
        public Item Item { get; set; }
        public decimal Quantity1 { get; set; }
        public decimal Packing { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
    }
}
