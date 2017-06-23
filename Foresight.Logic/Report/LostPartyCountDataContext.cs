using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class LostPartyCountDataContext : PartyCountBaseDataContext
    {
        protected override IEnumerable<string> getDistinctPeriods(IEnumerable<CompanyPeriod> coPeriods)
        {
            return coPeriods.Select(cp => cp.Period.Entity.Id).Distinct().OrderByDescending(p => p);
        }
    }
}
