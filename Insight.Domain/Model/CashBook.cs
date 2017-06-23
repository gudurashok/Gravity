namespace Insight.Domain.Model
{
    public class CashBook
    {
        public string Id { get; set; }
        public string ContactId { get; set; } //TODO: Contact from Mingle
        public Account Account { get; set; }
    }
}
