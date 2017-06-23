using System;

namespace Insight.Domain.Model
{
    public class StockAdjustment
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
        public decimal Quantity1 { get; set; }
        public decimal Packing { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
