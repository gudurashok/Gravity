using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class CompanyPeriodValue
    {
        public CompanyPeriod CompanyPeriod { get; set; }
        public decimal? Value { get; set; }
        public decimal? DifferencePct { get; set; }
    }
}
