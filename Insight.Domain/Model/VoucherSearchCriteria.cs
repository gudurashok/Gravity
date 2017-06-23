using Insight.Domain.Common;
using Scalable.Shared.Model;

namespace Insight.Domain.Model
{
    public class VoucherSearchCriteria
    {
        public string DocumentNr { get; set; }
        public string DaybookId { get; set; }
        public string DaybookName { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public DatePeriod Period { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }

        public VoucherSearchCriteria()
        {
            Period = new DatePeriod
                    {
                        From = InsightSession.CompanyPeriod.Period.Entity.Financial.From,
                        To = InsightSession.CompanyPeriod.Period.Entity.Financial.To
                    };
        }
    }
}
