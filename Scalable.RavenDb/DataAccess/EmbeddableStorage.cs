using System;
using System.Linq;
using System.IO;
using Raven.Client;
using Raven.Client.Embedded;
using System.Reflection;
using Raven.Client.Indexes;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Scalable.RavenDb.DataAccess
{
    public class EmbeddableStorage : DocumentStorageBase
    {
        public override void OpenDatabase(string databaseName)
        {
            store = new EmbeddableDocumentStore
            {
                RunInMemory = AppConfig.AppGenus == Genus.RunInMemory,
                DefaultDatabase = databaseName,
                UseEmbeddedHttpServer = AppConfig.UseEmbeddedHttpServer
            };

            (store as EmbeddableDocumentStore)
                .Configuration.Port = AppConfig.EmbeddedHttpServerPort;

            store.Initialize();
        }

        //public override IDocumentSession OpenSession()
        //{
        //    var result = store.OpenSession();
        //    result.Advanced.MaxNumberOfRequestsPerSession = MaxNumberOfRequestsPerSession;
        //    return result;
        //}

        public override string[] GetDatabaseNames()
        {
            if (!Directory.Exists(AppConfig.CoGroupDataPath))
                return new string[] { };

            var di = new DirectoryInfo(AppConfig.CoGroupDataPath);
            var dirs = di.GetDirectories();
            return dirs.Where(d => (File.Exists(string.Concat(d.FullName, @"\raven-data.ico"))))
                        .Select(d => d.FullName)
                        .ToArray();
        }

        public override void CreateIndexes(Assembly assemblyToScanForIndexingTasks)
        {
            IndexCreation.CreateIndexes(assemblyToScanForIndexingTasks, store);
        }

        public override bool IsDatabaseExists(string databaseName)
        {
            return AppConfig.AppGenus != Genus.RunInMemory && Directory.Exists(databaseName);
        }

        public override void AttachDatabase(string databaseName)
        {
            //TODO: attach databases from Datafolder
            throw new NotImplementedException();
        }

        public override void DeleteDatabase(string databaseName, bool deleteDataDir = false)
        {
            throw new NotImplementedException();
            //IOExtensions.DeleteDirectory(); //(it is part of RavenDB)
            //CopyDirectory
        }
    }
}
