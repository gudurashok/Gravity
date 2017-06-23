using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Mingle.Domain.Repositories;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class Companies : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            var repo = new PartyRepository();
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyEntity>()
                        .Where(c => c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name)
                        .ToList()
                        .Select(c => new CompanyListItem
                            {
                                Company = new Company(c)
                                {
                                    Party = repo.GetById(c.PartyId, false)
                                }
                            })
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
