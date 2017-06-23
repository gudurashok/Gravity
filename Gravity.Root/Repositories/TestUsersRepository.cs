using System.Linq;
using Gravity.Root.Entities;
using Raven.Client;

namespace Gravity.Root.Repositories
{
    public class TestUsersRepository : RepositoryBase
    {
        #region Declarations

        private const string testDataInsertedKey = "GravityTestUsersInserted";
        private IDocumentSession _session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (testDataInserted())
                    return;

                createInternal();
                setTestDataInsertedConfigItem();
                _session.SaveChanges();
            }
        }

        private void setTestDataInsertedConfigItem()
        {
            var config = SysConfigEntity.New();
            config.Name = testDataInsertedKey;
            config.Value = true;
            _session.Store(config);
        }

        //TODO: this is been duplicated should be moved to its own class
        private bool testDataInserted()
        {
            var appAconfig = _session.Query<SysConfigEntity>()
                            .Where(item => item.Name == testDataInsertedKey)
                            .SingleOrDefault();

            return appAconfig != null && (bool)appAconfig.Value;
        }

        #endregion

        #region Test Data Creation

        private void createInternal()
        {
            var user = UserEntity.New();
            user.Name = "Ashok Guduru";
            user.Credentials = new Credentials { LoginName = "Ashok" };
            user.Designation = "Admin";
            user.IsAdmin = true;
            user.IsActive = true;
            _session.Store(user);

            user = UserEntity.New();
            user.Name = "Srikanth Guduru";
            user.Credentials = new Credentials { LoginName = "Srikanth" };
            user.Designation = "Finance";
            user.IsAdmin = false;
            user.IsActive = true;
            _session.Store(user);

            user = UserEntity.New();
            user.Name = "Sripathi Dasari";
            user.Credentials = new Credentials { LoginName = "Sripathi" };
            user.Designation = "Purchase";
            user.IsAdmin = false;
            user.IsActive = true;
            _session.Store(user);

            user = UserEntity.New();
            user.Name = "Shyam V Manda";
            user.Credentials = new Credentials { LoginName = "Shyam" };
            user.Designation = "Guest";
            user.IsAdmin = false;
            user.IsActive = true;
            _session.Store(user);

            user = UserEntity.New();
            user.Name = "Nikhil N Shah";
            user.Credentials = new Credentials { LoginName = "Nikhil" };
            user.Designation = "Marketing";
            user.IsAdmin = false;
            user.IsActive = true;
            _session.Store(user);
        }

        #endregion
    }
}
