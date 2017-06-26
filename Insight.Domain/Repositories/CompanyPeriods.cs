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
using Insight.Domain.Enums;

namespace Insight.Domain.Repositories
{
    public class CompanyPeriods : RepositoryBase, IListRepository
    {
        private enum CoSourceDataProvider
        {
            Insight = 0,
            NonInsight = 1,
            Both = 2
        }

        public static CompanyPeriods NewLoadAllDataSourceCompanies()
        {
            return new CompanyPeriods(CoSourceDataProvider.Both);
        }

        public static CompanyPeriods NewLoadAllNonInsightDataSourceCompanies()
        {
            return new CompanyPeriods(CoSourceDataProvider.NonInsight);
        }

        public static CompanyPeriods NewLoadOnlyInsightDataSourceCompanies()
        {
            return new CompanyPeriods(CoSourceDataProvider.Insight);
        }

        private CoSourceDataProvider _coSourceDataProvider;

        private CompanyPeriods(CoSourceDataProvider coSourceDataProvider)
        {
            _coSourceDataProvider = coSourceDataProvider;
        }

        private int[] getSourceDataProviderToInclude()
        {
            if (_coSourceDataProvider == CoSourceDataProvider.Insight)
                return new int[] { (int)SourceDataProvider.Insight };
            else if (_coSourceDataProvider == CoSourceDataProvider.NonInsight)
                return new int[]
                {
                    (int)SourceDataProvider.Easy,
                    (int)SourceDataProvider.Mcs,
                    (int)SourceDataProvider.Tcs
                };
            else
                return new int[]
                {
                    (int)SourceDataProvider.Easy,
                    (int)SourceDataProvider.Mcs,
                    (int)SourceDataProvider.Tcs,
                    (int)SourceDataProvider.Insight
                };
        }

        public IList<CompanyPeriod> GetAllCompanyPeriods()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyPeriodEntity>()
                        .ToList()
                        .Where(c => getSourceDataProviderToInclude().Contains((int)c.SourceDataProvider))
                        .Select(c => new CompanyPeriod(c)
                        {
                            Company = new Company(getCompanyEntity(c, s)),
                            Period = new FiscalDatePeriod(s.Load<FiscalDatePeriodEntity>(c.PeriodId))
                        })
                        .ToList();
            }
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyPeriodEntity>()
                        .ToList()
                        .Where(c => getSourceDataProviderToInclude().Contains((int)c.SourceDataProvider))
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
