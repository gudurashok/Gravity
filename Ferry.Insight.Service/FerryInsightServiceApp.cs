using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using System.IO;

namespace Ferry.Insight.Service
{
    public class FerryInsightServiceApp
    {
        public FerryInsightServiceApp()
        {
        }

        public void Initialize()
        {
            var coGroup = getCoGroupFromAppConfig();
            if (!isCoGroupOfAppConfigExist(coGroup))
            {
                ServiceConfig.WriteLog("Company group specified in app.config doesn't exist.");
                return;
            }

            GravitySession.ReInitialize();
            GravitySession.OpenCompanyGroup(coGroup);
        }

        private CompanyGroup getCoGroupFromAppConfig()
        {
            var databaseName = AppConfig.CoGroupDatabase;
            return string.IsNullOrWhiteSpace(databaseName)
                ? null
                : CompanyGroup.NewFrom(AppConfig.CoGroupId, databaseName);
        }

        private bool isCoGroupOfAppConfigExist(CompanyGroup coGroup)
        {
            if (AppConfig.AppGenus == Genus.RunInMemory)
                return false;

            if (AppConfig.AppGenus == Genus.Embedded)
                return Directory.Exists(coGroup.DatabaseName);

            var exists = true;

            GravitySession.Initialize();

            if (AppConfig.AppGenus != Genus.RavenHQ)
            {
                exists = GravitySession.StoreManager
                        .Store.IsDatabaseExists(coGroup.DatabaseName);
            }

            GravitySession.Dispose();
            return exists;
        }
    }
}
