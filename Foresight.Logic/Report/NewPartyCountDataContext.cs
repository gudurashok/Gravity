using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class NewPartyCountDataContext : PartyCountBaseDataContext
    {
        protected override IEnumerable<string> getDistinctPeriods(IEnumerable<CompanyPeriod> coPeriods)
        {
            return coPeriods.Select(cp => cp.Period.Entity.Id).Distinct().OrderBy(p => p);
        }
    }
}
