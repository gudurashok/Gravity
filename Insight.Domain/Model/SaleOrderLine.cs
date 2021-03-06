﻿namespace Insight.Domain.Model
{
    public class SaleOrderLine
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public string ItemDescription { get; set; }
        public decimal Quantity1 { get; set; }
        public decimal Packing { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPct { get; set; }
        public decimal Amount { get; set; }
    }
}
