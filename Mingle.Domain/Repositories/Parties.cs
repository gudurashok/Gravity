using System.Collections.Generic;
using Gravity.Root.Repositories;
using Mingle.Domain.Entities;
using System.Linq;
using Mingle.Domain.Model;
using Mingle.Domain.ViewModel;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Mingle.Domain.Repositories
{
    public class Parties : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                var query = s.Query<PartyEntity>()
                    .Where(p => p.Name.StartsWith(criteria.SearchText))
                    .OrderBy(p => p.Name);

                var result = criteria.Count > 0 ? query.Take(criteria.Count).ToList() : query.ToList();

                if (criteria.PopulateFullDetails)
                    return result
                        .Select(e => new PartyListItem { Party = PartyRepository.GetPartyWithPartialDetails(e, s) })
                        .Cast<dynamic>().ToList();

                return result
                        .Select(e => new PartyListItem { Party = new Party(e) })
                        .Cast<dynamic>().ToList();
            }
        }

        //public IEnumerable<PartyListItem> GetPartyListItems()
        //{
        //    using (var s = Store.OpenSession())
        //    {
        //        return s.Query<PartyEntity>()
        //            .ToList()
        //            .Select(e => new PartyListItem { Party = PartyRepository.GetPartyWithPartialDetails(e, s) })
        //            .OrderBy(pl => pl.Name)
        //            .ThenBy(pl => pl.Location)
        //            .ToList();
        //    }
        //}
    }
}
