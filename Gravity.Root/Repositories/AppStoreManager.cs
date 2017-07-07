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
            CheckCoGroupDatabaseExists(coGroup);
            Store.OpenDatabase(coGroup.DatabaseName);
        }

        public void CheckCoGroupDatabaseExists(CompanyGroup coGroup)
        {
            if (AppConfig.AppGenus == Genus.RunInMemory || AppConfig.AppGenus == Genus.RavenHQ)
                return;

            if (!Store.IsDatabaseExists(coGroup.DatabaseName))
            {
                var message = $"Database for company group '{coGroup.Entity.Name}' does not exist.\n\n";
                if (AppConfig.AppGenus == Genus.Embedded)
                    message = $"{message}Path: '{AppConfig.EmbeddedStoreDataPath}'";
                else
                    message = $"{message}Database: '{coGroup.DatabaseName}'";

                throw new ValidationException(message);
            }
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
