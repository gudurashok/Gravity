using Gravity.Root.Model;
using Gravity.Root.Repositories;

namespace Gravity.Root.Common
{
    public static class GravitySession
    {
        public static User User { get; set; }
        public static CompanyGroup CompanyGroup { get; private set; }
        public static AppStoreManager StoreManager { get; private set; }
        public static GravityAppBase Application { get; set; }

        public static void Initialize()
        {
            StoreManager = new AppStoreManager();
        }

        public static void ReInitialize()
        {
            Dispose();
            Initialize();
        }

        public static void OpenCompanyGroup(CompanyGroup coGroup, bool setOnly = false)
        {
            if (coGroupNotChanged(coGroup))
                return;

            if (setOnly)
            {
                CompanyGroup = coGroup;
                return;
            }

            StoreManager.OpenCoGroupDatabase(coGroup);
            var repo = new CoGroupRepository();
            CompanyGroup = repo.GetById(coGroup.Entity.Id);
        }

        private static bool coGroupNotChanged(CompanyGroup coGroup)
        {
            return coGroup.Equals(CompanyGroup);
        }

        public static void Dispose()
        {
            if (StoreManager == null)
                return;

            StoreManager.Dispose();
            StoreManager = null;
        }
    }
}
