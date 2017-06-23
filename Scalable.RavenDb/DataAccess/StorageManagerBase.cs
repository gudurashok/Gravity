using System;

namespace Scalable.RavenDb.DataAccess
{
    public class StorageManagerBase : IDisposable
    {
        public DocumentStorageBase Store { get; private set; }

        protected StorageManagerBase()
        {
            Store = DocumentStorageFactory.GetInstance();
        }

        public void Dispose()
        {
            Store.Dispose();
        }
    }
}
