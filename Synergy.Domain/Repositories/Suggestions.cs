using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Model;

namespace Synergy.Domain.Repositories
{
    public class Suggestions : IListRepository
    {
        private readonly IList<string> _sugesstions;

        public Suggestions(IList<string> sugesstions)
        {
            _sugesstions = sugesstions;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            return _sugesstions
                    .Where(s => s.StartsWith(criteria.SearchText))
                    .Select(s => new Suggestion { SuggestionItem = s })
                    .Cast<dynamic>().ToList();
        }
    }
}
