﻿using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Entities;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Gravity.Root.Repositories
{
    public class RoleResponsibilities : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<RoleResponsibilityEntity>()
                        .Where(r => r.Name.StartsWith(criteria.SearchText))
                        .OrderBy(r => r.Id).ToList()
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
