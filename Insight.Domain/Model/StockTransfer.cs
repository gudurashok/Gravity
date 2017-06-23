using System;

namespace Insight.Domain.Model
{
    public class StockTransfer
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Warehouse FromWareHouse { get; set; }
        public Warehouse ToWarehouse { get; set; }
        public Item Item { get; set; }
        public decimal Quantity1 { get; set; }
        public decimal Packing { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
    }
}
