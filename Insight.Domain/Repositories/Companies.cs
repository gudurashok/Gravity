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
        private enum CoSourceDataProvider
        {
            Insight = 0,
            NonInsight = 1,
            Both = 2
        }

        public static Companies NewLoadAllDataSourceCompanies()
        {
            return new Companies(CoSourceDataProvider.Both);
        }

        public static Companies NewLoadAllNonInsightDataSourceCompanies()
        {
            return new Companies(CoSourceDataProvider.NonInsight);
        }

        public static Companies NewLoadOnlyInsightDataSourceCompanies()
        {
            return new Companies(CoSourceDataProvider.Insight);
        }

        private CoSourceDataProvider _coSourceDataProvider;

        private Companies(CoSourceDataProvider coSourceDataProvider)
        {
            _coSourceDataProvider = coSourceDataProvider;
        }

        private bool shouldIncludeThisCompany(CompanyEntity entity)
        {
            if (_coSourceDataProvider == CoSourceDataProvider.Insight)
                return string.IsNullOrWhiteSpace(entity.Code);
            else if (_coSourceDataProvider == CoSourceDataProvider.NonInsight)
                return !string.IsNullOrWhiteSpace(entity.Code);
            else
                return true;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            var repo = new PartyRepository();
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyEntity>()
                        .ToList()
                        .Where(c => shouldIncludeThisCompany(c) && c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name)
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
