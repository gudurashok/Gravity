using System;
using Scalable.Shared.Common;
using Scalable.RavenDb.Properties;
using Scalable.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Scalable.RavenDb.DataAccess
{
    public static class DocumentStorageFactory
    {
        public static DocumentStorageBase GetInstance()
        {
            var genus = AppConfig.AppGenus;

            switch (genus)
            {
                case Genus.RunInMemory:
                case Genus.Embedded:
                    return new EmbeddableStorage();
                case Genus.Server:
                case Genus.RavenHQ:
                    return new ServerStorage();
                default:
                    throw new ValidationException(String.Format(Resources.GenusNotSupported, genus));
            }
        }
    }
}
