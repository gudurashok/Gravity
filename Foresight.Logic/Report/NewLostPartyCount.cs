using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class NewLostPartyCount
    {
        public CompanyPeriod CompanyPeriod { get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
    }
}
