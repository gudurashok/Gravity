namespace Insight.Domain.Model
{
    public class DiscountPolicy
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public decimal Percentage { get; set; }
    }
}
