using System;
using Raven.Client;
using System.Reflection;

namespace Scalable.RavenDb.DataAccess
{
    public abstract class DocumentStorageBase : IDisposable
    {
        protected const int MaxNumberOfRequestsPerSession = 1000000;
        protected IDocumentStore store { get; set; }
        public abstract void OpenDatabase(string databaseName);
        //public abstract IDocumentSession OpenSession();
        public abstract string[] GetDatabaseNames();
        public abstract void CreateIndexes(Assembly assemblyToScanForIndexingTasks);
        public abstract bool IsDatabaseExists(string databaseName);
        public abstract void AttachDatabase(string databaseName);
        public abstract void DeleteDatabase(string databaseName, bool deleteDataDir = false);
        public abstract bool IsServerOnline();

        public void Dispose()
        {
            if (store != null)
                store.Dispose();
        }

        public IDocumentSession OpenSession()
        {
            var result = store.OpenSession();
            result.Advanced.MaxNumberOfRequestsPerSession = MaxNumberOfRequestsPerSession;
            return result;
        }

        protected void deleteDatabaseDir(string databaseName)
        {
            throw new NotImplementedException();
        }
    }
}
