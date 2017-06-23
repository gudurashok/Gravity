using System.Collections.Generic;
using Scalable.Shared.Model;

namespace Scalable.Shared.Repositories
{
    public interface IListRepository
    {
        IList<dynamic> SearchItems(PicklistSearchCriteria criteria);
    }
}
