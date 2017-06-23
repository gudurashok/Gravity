namespace Insight.Domain.Model
{
    public class CreditPolicy
    {
        public string Id { get; set; }
        public int CreditDays { get; set; }
        public int CreditLevel { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal InterestRate { get; set; }
    }
}
