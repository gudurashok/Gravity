using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Raven.Client;
using System;

namespace Gravity.Root.Repositories
{
    public class Users : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                var query = s.Query<UserEntity>()
                            .Where(u => u.Name.StartsWith(criteria.SearchText))
                            .OrderBy(u => u.Name);

                var result = criteria.Count > 0 ? query.Take(criteria.Count).ToList() : query.ToList();
                return result.Cast<dynamic>().ToList();
            }
        }

        public User GetById(string id)
        {
            using (var s = Store.OpenSession())
                return GetById(s, id);
        }

        private User GetById(IDocumentSession s, string id)
        {
            var user = new User(s.Load<UserEntity>(id));

            //TODO: this method GetById() cna have an optional param to 
            //      loadParents instead of allways recursively loading the parents.
            loadParentUser(s, user);
            return user;
        }

        private void loadParentUser(IDocumentSession s, User user)
        {
            if (!string.IsNullOrEmpty(user.Entity.ParentId))
                user.Parent = GetById(s, user.Entity.ParentId);
        }

        public User GetByLoginName(string loginName)
        {
            using (var s = Store.OpenSession())
            {
                var entity = s.Query<UserEntity>()
                    .Where(u => u.Credentials.LoginName == loginName)
                    .SingleOrDefault();

                return entity == null ? null : new User(entity);
            }
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            using (var s = Store.OpenSession())
                return s.Query<UserEntity>().ToList();
        }

        public IList<User> GetAllUsers()
        {
            using (var s = Store.OpenSession())
                return s.Query<UserEntity>().ToList()
                        .Select(u => new User(u)
                                    {
                                        Parent = string.IsNullOrWhiteSpace(u.ParentId)
                                                    ? null
                                                    : new User(s.Load<UserEntity>(u.ParentId))
                                    }).ToList();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
