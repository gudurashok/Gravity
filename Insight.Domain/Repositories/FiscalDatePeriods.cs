using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class FiscalDatePeriods : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<FiscalDatePeriodEntity>()
                        .Where(c => c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name)
                        .ToList()
                        .Select(c => new FiscalDatePeriodListItem { FiscalDatePeriod = new FiscalDatePeriod(c) })
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
