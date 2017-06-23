namespace Insight.Domain.Model
{
    public class ItemQuantity
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Format { get; set; }
        public string Label { get; set; }
    }
}
