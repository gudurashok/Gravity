namespace Insight.Domain.Model
{
    public class BrokeragePolicy
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public decimal Percentage { get; set; }
    }
}
