using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Gravity.Root.Model;
using Scalable.RavenDb.DataAccess;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Gravity.Root.Repositories
{
    public class AppStoreManager : StorageManagerBase
    {
        public void OpenCoGroupDatabase(CompanyGroup coGroup)
        {
            checkCoGroupDatabaseExists(coGroup);
            Store.OpenDatabase(coGroup.DatabaseName);
        }

        private void checkCoGroupDatabaseExists(CompanyGroup coGroup)
        {
            if (AppConfig.AppGenus == Genus.RunInMemory || AppConfig.AppGenus == Genus.RavenHQ)
                return;

            if (!Store.IsDatabaseExists(coGroup.DatabaseName))
                throw new ValidationException(
                    string.Format("Database for company group {0} does not exist!\n\nPath: {1}",
                                  coGroup.Entity.Name, coGroup.DatabaseName));
        }

        public void CreateCoGroupDatabase(CompanyGroup coGroup)
        {
            Store.OpenDatabase(coGroup.DatabaseName);
        }

        public void CreateIndexesFrom(IEnumerable<Assembly> assembliesToScanForIndexingTasks)
        {
            foreach (var assembly in assembliesToScanForIndexingTasks)
                Store.CreateIndexes(assembly);
        }
    }
}
