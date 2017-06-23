using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class FiscalDatePeriodListItem
    {
        public FiscalDatePeriod FiscalDatePeriod { get; set; }

        public string Name
        {
            get { return FiscalDatePeriod.Entity.Name; }
        }

        public string FinancialYear
        {
            get { return FiscalDatePeriod.Entity.Financial.ToYearString(); }
        }

        public string AssessmentYear
        {
            get { return FiscalDatePeriod.Entity.Assessment.ToYearString(); }
        }
    }
}
