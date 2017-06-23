using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public abstract class PeriodTopperBaseDataContext : TopperBaseDataContext
    {
        protected override IEnumerable<string> getDistinctIds(IEnumerable<CompanyPeriod> coPeriods)
        {
            return coPeriods.Select(cp => cp.Period.Entity.Id).Distinct();
        }

        protected override CompanyPeriod getCompanyPeriodOf(IEnumerable<CompanyPeriod> coPeriods, string periodId)
        {
            return coPeriods.First(cp => cp.Period.Entity.Id == periodId);
        }

        protected override string getCompanyPeriodFilter(string id)
        {
            return string.Format(" AND PeriodId={0}", id);
        }
    }
}
