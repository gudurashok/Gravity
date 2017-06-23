namespace Insight.Domain.Model
{
    public class ItemStockProp
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public decimal Packing { get; set; }
        public decimal RatePer { get; set; }
        public decimal Rate { get; set; }
        public decimal MinStockQty { get; set; }
    }
}
