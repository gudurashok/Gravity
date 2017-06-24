using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Raven.Client;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Mingle.Domain.Model;
using Mingle.Domain.Repositories;

namespace Insight.Domain.Repositories
{
    public class CompanyPeriods : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyPeriodEntity>()
                        .ToList()
                        .Select(c => new CompanyPeriodListItem
                        {
                            CompanyPeriod = new CompanyPeriod(c)
                            {
                                Company = new Company(getCompanyEntity(c, s))
                                {
                                    Party = getParty(getCompanyEntity(c, s))
                                },
                                Period = new FiscalDatePeriod(s.Load<FiscalDatePeriodEntity>(c.PeriodId))
                            }
                        })
                        .Cast<dynamic>().ToList();
            }
        }

        //TODO: Not good, loading full party every time and on every search. Think alternative
        private Party getParty(CompanyEntity companyEntity)
        {
            var repo = new PartyRepository();
            return repo.GetById(companyEntity.PartyId, true);
        }

        private static CompanyEntity getCompanyEntity(CompanyPeriodEntity c, IDocumentSession s)
        {
            return s.Load<CompanyEntity>(c.CompanyId);
        }
    }
}
