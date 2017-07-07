using System.Linq;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;
using Raven.Client.Indexes;
using Scalable.RavenDb.Properties;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Scalable.RavenDb.DataAccess
{
    public class ServerStorage : DocumentStorageBase
    {
        private string _databaseName;

        public ServerStorage()
        {
            connectToServer();
        }

        public override bool IsServerOnline()
        {
            return store.IsServerOnline();
        }

        public override void OpenDatabase(string databaseName)
        {
            _databaseName = databaseName;
            connectToServer();
        }

        private void connectToServer()
        {
            if (AppConfig.AppGenus == Genus.RavenHQ)
                connectToRavenHQServer();
            else
                connectToLocalServer();
        }

        private void connectToRavenHQServer()
        {
            store = new DocumentStore
            {
                Url = AppConfig.ServerUrl,
                ApiKey = AppConfig.RavenHQApiKey
            }.Initialize();
        }

        private void connectToLocalServer()
        {
            store = new DocumentStore
            {
                Url = AppConfig.ServerUrl,
                DefaultDatabase = _databaseName
            }.Initialize();
        }

        //public override IDocumentSession OpenSession()
        //{
        //    var result = store.OpenSession();
        //    result.Advanced.MaxNumberOfRequestsPerSession = MaxNumberOfRequestsPerSession;
        //    return result;
        //}

        public override string[] GetDatabaseNames()
        {
            const int pageSize = 1024;
            return store.DatabaseCommands.GlobalAdmin.GetDatabaseNames(pageSize);
        }

        public override void CreateIndexes(Assembly assemblyToScanForIndexingTasks)
        {
            var catalog = new CompositionContainer(new AssemblyCatalog(assemblyToScanForIndexingTasks));
            IndexCreation.CreateIndexes(catalog, store.DatabaseCommands.ForDatabase(_databaseName), store.Conventions);
        }

        public override bool IsDatabaseExists(string databaseName)
        {
            try
            {
                return GetDatabaseNames().Contains(databaseName);
            }
            catch (WebException ex)
            {
                throw new ValidationException(
                    string.Format(Resources.CannotConnectToDatabaseServer, store.Url), ex);
            }
        }

        public override void AttachDatabase(string databaseName)
        {
            //TODO: RavenDB v2.5 did not find MultiDatabase class???

            //var document = MultiDatabase.CreateDatabaseDocument(databaseName);
            //var docs = store.DatabaseCommands.Put(string.Format(@"Raven/Databases/{0}", databaseName), null, document, null);

            ////TODO: docs... could inform what happened to caller
        }

        public override void DeleteDatabase(string databaseName, bool deleteDataDir = false)
        {
            store.DatabaseCommands.Delete(string.Format(@"Raven/Databases/{0}", databaseName), null);

            if (deleteDataDir)
                deleteDatabaseDir(databaseName);
        }
    }
}
