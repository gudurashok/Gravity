using System.Linq;
using System.Collections.Generic;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Scalable.Shared.Common;

namespace Gravity.Root.Repositories
{
    //TODO: error handling: enclose all operations (save, delete, update etc) 
    //      in an exception handler try/catch
    //      and throw appropriate validation exception
    public class CoGroupRepository : RepositoryBase
    {
        public UserConfigEntity GetUserConfig(string userId, string keyName)
        {
            using (var s = Store.OpenSession())
            {
                var userConfigs = s.Query<UserConfigEntity>()
                                    .Where(c => c.UserId == userId && c.Name == keyName)
                                    .OrderBy(c => c.Id).ToList();

                var result = userConfigs.FirstOrDefault();

                if (userConfigs.Count > 1)
                    foreach (var config in userConfigs.Where(c => c.Id != result.Id))
                        s.Delete(config);

                return result;
            }
        }

        public IEnumerable<UserConfigEntity> GetUserConfigs(string keyName, object value)
        {
            if (value == null)
                return null;

            using (var s = Store.OpenSession())
            {
                return s.Query<UserConfigEntity>()
                        .Where(c => c.Name == keyName && c.Value != null && c.Value == value)
                        .ToList();
            }
        }

        public void SaveUserConfig(UserConfigEntity entity)
        {
            base.Save(entity);
        }

        public SysConfigEntity GetSysConfig(string keyName)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<SysConfigEntity>()
                                .Where(i => i.Name == keyName)
                                .FirstOrDefault();
            }
        }

        public void SaveSysConfig(SysConfigEntity entity)
        {
            base.Save(entity);
        }

        #region Test Data Creation

        public CompanyGroup GetTestCoGroup()
        {
            var coGroup = CompanyGroup.CreateTestCoGroup();
            if (coGroupExist(coGroup))
                GravitySession.StoreManager.OpenCoGroupDatabase(coGroup);
            else
            {
                createCoGroup(coGroup);
                new DefaultDataRepository().Insert();
            }

            return coGroup;
        }

        private bool coGroupExist(CompanyGroup coGroup)
        {
            return Store.IsDatabaseExists(coGroup.DatabaseName);
        }

        #endregion

        public CompanyGroup GetById(string id, bool throwExceptionIfNotFound = false)
        {
            var entity = Read<CoGroupEntity>(id, throwExceptionIfNotFound);
            return entity == null ? null : new CompanyGroup(entity);
        }

        public IEnumerable<CompanyGroup> GetAll()
        {
            using (var s = Store.OpenSession())
                return s.Query<CoGroupEntity>().Select(entity => new CompanyGroup(entity));
        }

        public IEnumerable<CoGroupListItem> GetCoGroupListItems()
        {
            using (var s = Store.OpenSession())
                return s.Query<CoGroupEntity>().Select(entity => new CoGroupListItem { Id = entity.Id, Name = entity.Name });
        }

        public string[] GetAllDatabaseNames()
        {
            //TODO gets CoGroup database names. check each database and see if it is cogroup database and add to the list
            return Store.GetDatabaseNames();
        }

        public void DeleteGroup(CompanyGroup coGroup, bool deleteDataDirOptional = false)
        {
            //TODO: delete in one session???
            Store.DeleteDatabase(coGroup.DatabaseName, deleteDataDirOptional); //deletes the associated database instance/tenant/dir
            DeleteById(coGroup.Entity.Id); // deletes the document/entry from root db
        }

        public void SaveGroup(CompanyGroup coGroup)
        {
            if (coGroup.IsNew())
                create(coGroup);
            else
                update(coGroup);
        }

        private void create(CompanyGroup coGroup)
        {
            EntityValidator.Validate(coGroup.Entity);

            ////TODO: if exists then attach??
            //if (Store.IsDatabaseExists(coGroup.DatabaseName))
            //    Store.AttachDatabase(coGroup.DatabaseName);

            createCoGroup(coGroup);
            new DefaultDataRepository().Insert();
            GravitySession.ReInitialize();
        }

        private void createCoGroup(CompanyGroup coGroup)
        {
            GravitySession.StoreManager.CreateCoGroupDatabase(coGroup);
            Save(coGroup.Entity);
        }

        private void update(CompanyGroup coGroup)
        {
            Save(coGroup.Entity);
        }

        //public static CompanyGroup GetCoGroupFromAttachingDb(string databaseName)
        //{
        //    var coGroupEntity = CoGroupEntity.New();
        //    coGroupEntity.DatabaseName = databaseName;
        //    var coGroup = new CompanyGroup(coGroupEntity);

        //    //using (var store = new CoGroupStoreManager(coGroup))
        //    //{
        //    //    var repo = new RepositoryBase(store);
        //    //    coGroup = repo.Read(CompanyGroup.DefaultId);
        //    //    coGroup.Entity.DatabaseName = databaseName;
        //    //}

        //    return coGroup;
        //}
    }
}
