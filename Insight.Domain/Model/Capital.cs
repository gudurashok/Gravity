namespace Insight.Domain.Model
{
    public class Capital
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public decimal SharePct { get; set; }
    }
}
