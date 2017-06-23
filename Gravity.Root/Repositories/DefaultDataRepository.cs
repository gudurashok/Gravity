using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Raven.Client;

namespace Gravity.Root.Repositories
{
    public class DefaultDataRepository : RepositoryBase
    {
        #region Declarations

        private const string defaultDataInsertedKey = "GravityDefaultDataInserted";
        protected IDocumentSession _session;

        #endregion

        #region Insert default data

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (defaultDataInserted())
                    return;

                _session.Store(createAdminUser());
                //_session.Store(saveUserMenuItem());
                setDefaultDataInsertedConfigItems();
                _session.SaveChanges();
            }
        }

        private UserEntity createAdminUser()
        {
            var user = UserEntity.New();
            user.Name = "Administrator";
            user.Credentials = new Credentials { LoginName = "Admin" };
            user.Designation = "Admin";
            user.IsAdmin = true;
            user.IsActive = true;
            return user;
        }

        private AppMenuItemEntity saveUserMenuItem()
        {
            var menuItem = new AppMenuItemEntity();
            menuItem.Nr = 1;
            menuItem.DisplayOrder = "1";
            menuItem.Name = "Users";
            menuItem.Caption = "&Users";
            menuItem.UIControlName = "UUsers";
            menuItem.UIControlPath = "Gravity.Root.Controls";
            menuItem.UIAssembly = "Gravity.Root.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.U;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            return menuItem;
        }

        private void setDefaultDataInsertedConfigItems()
        {
            var config = SysConfigEntity.New();
            config.Name = defaultDataInsertedKey;
            config.Value = true;
            _session.Store(config);
        }

        private bool defaultDataInserted()
        {
            var appAconfig = _session.Query<SysConfigEntity>()
                            .Where(item => item.Name == defaultDataInsertedKey)
                            .SingleOrDefault();

            return appAconfig != null && (bool)appAconfig.Value;
        }

        #endregion
    }
}
