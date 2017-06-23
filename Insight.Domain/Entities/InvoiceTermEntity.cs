namespace Insight.Domain.Entities
{
    public abstract class InvoiceTermEntity
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string TermId { get; set; }
        public char Code { get; set; }
        public string Description { get; set; }
        public double Percentage { get; set; }
        public decimal Amount { get; set; }
        public string AccountId { get; set; }
    }
}
