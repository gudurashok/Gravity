using Foresight.Logic.Properties;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Foresight.Logic.DataAccess
{
    public static class CoGroupDatabaseFactory
    {
        public static CoGroupDatabase GetInstance()
        {
            var genus = AppConfig.ForesightAppGenus;

            switch (genus)
            {
                case Genus.Embedded:
                    return new CoGroupSqlCeDatabase();
                case Genus.Server:
                    return new CoGroupSqlServerDatabase();
                default:
                    throw new ValidationException(
                        string.Format(Resources.GenusNotSupported, genus));
            }
        }
    }
}
