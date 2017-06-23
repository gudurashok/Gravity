namespace Insight.Domain.Model
{
    public class ItemPurchaseProp
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public decimal Packing { get; set; }
        public decimal CostPer { get; set; }
        public decimal Cost { get; set; }
        public decimal MaxCost { get; set; }
        public bool BlockOnMaxCostViolation { get; set; }
        public Account Account { get; set; }
    }
}
