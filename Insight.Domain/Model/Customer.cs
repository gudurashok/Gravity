namespace Insight.Domain.Model
{
    public class Customer
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public string ContactId { get; set; } //TODO: Contact from Mingle
        public CreditPolicy CreditPolicy { get; set; }
        public DiscountPolicy DiscountPolicy { get; set; }
        public BrokeragePolicy BrokeragePolicy { get; set; }
    }
}
