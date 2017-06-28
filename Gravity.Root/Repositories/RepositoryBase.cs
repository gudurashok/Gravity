using System;
using System.Linq;
using System.Threading;
using Gravity.Root.Common;
using Gravity.Root.Properties;
using Scalable.RavenDb.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Gravity.Root.Repositories
{
    public class RepositoryBase
    {
        public DocumentStorageBase Store { get; private set; }

        public RepositoryBase()
            : this(GravitySession.StoreManager)
        {
        }

        public RepositoryBase(StorageManagerBase storeManager)
        {
            Store = storeManager.Store;
        }

        public virtual void Delete(dynamic entity)
        {
            using (var session = Store.OpenSession())
            {
                dynamic entityLocal = entity;

                //if (session.Advanced.IsLoaded(entity.Id))
                //    entityLocal = session.Load<dynamic>(entity.Id);

                session.Delete(entityLocal);
                session.SaveChanges();
                Thread.Sleep(100);
            }
        }

        public virtual void DeleteById(string id)
        {
            using (var session = Store.OpenSession())
            {
                //session.Advanced.DatabaseCommands.Delete(id, null);
                session.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
                session.SaveChanges();
                Thread.Sleep(100);
            }
        }

        public virtual void Insert(dynamic entity)
        {
            using (var session = Store.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public virtual string Save(dynamic entity)
        {
            using (var session = Store.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
                Thread.Sleep(100);
                return entity.Id;
            }
        }

        public dynamic Query(Func<dynamic, bool> predicate)
        {
            using (var s = Store.OpenSession())
                return s.Query<dynamic>().Where(predicate).First();
        }

        public virtual T Read<T>(string id) where T : class
        {
            return Read<T>(id, false);
        }

        public virtual T Read<T>(string id, bool throwExceptionIfNotFound) where T : class
        {
            T result;

            using (var s = Store.OpenSession())
                result = s.Load<T>(id);

            if (result == null && throwExceptionIfNotFound)
                throw new ValidationException(string.Format(Resources.DocumentOfIdNotFound, id));

            return result;
        }

        public virtual dynamic Read(string id)
        {
            return Read(id, false);
        }

        public virtual dynamic Read(string id, bool throwExceptionIfNotFound)
        {
            dynamic result;

            using (var s = Store.OpenSession())
                result = s.Load<dynamic>(id);

            if (result == null && throwExceptionIfNotFound)
                throw new ValidationException(string.Format(Resources.DocumentOfIdNotFound, id));

            return result;
        }
    }
}
