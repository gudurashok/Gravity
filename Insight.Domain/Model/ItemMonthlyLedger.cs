namespace Insight.Domain.Model
{
    public class ItemMonthlyLedger
    {
        public string Id { private get; set; }
        public string ItemId { get; set; }
        public string AccountId { get; set; }
        public string ChartOfAccountId { get; set; }
        public int Month { get; set; }
        public decimal Sale { get; private set; }
        public decimal Purchase { get; private set; }
        public CompanyPeriod CompanyPeriod { get; set; }
    }
}
