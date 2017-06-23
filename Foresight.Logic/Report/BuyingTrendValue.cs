using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class BuyingTrendValue
    {
        public FiscalDatePeriod Period { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
    }
}
