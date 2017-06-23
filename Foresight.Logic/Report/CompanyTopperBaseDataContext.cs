using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public abstract class CompanyTopperBaseDataContext : TopperBaseDataContext
    {
        protected override IEnumerable<string> getDistinctIds(IEnumerable<CompanyPeriod> coPeriods)
        {
            return coPeriods.Select(cp => cp.Company.Entity.Id).Distinct();
        }

        protected override CompanyPeriod getCompanyPeriodOf(IEnumerable<CompanyPeriod> coPeriods, string companyId)
        {
            return coPeriods.First(cp => cp.Company.Entity.Id == companyId);
        }

        protected override string getCompanyPeriodFilter(string id)
        {
            return string.Format(" AND CompanyId={0}", id);
        }
    }
}
