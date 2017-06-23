namespace Insight.Domain.Model
{
    public class ItemSaleProp
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public decimal Packing { get; set; }
        public decimal PricePer { get; set; }
        public decimal Price { get; set; }
        public decimal MinPrice { get; set; }
        public bool BlockOnMinPriceViolation { get; set; }
        public Account Account { get; set; }
    }
}
