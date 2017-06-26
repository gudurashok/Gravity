using System.ComponentModel.DataAnnotations;
using Foresight.Logic.Properties;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Foresight.Logic.DataAccess
{
    public static class ForesightDatabaseFactory
    {
        public static ForesightDatabase GetInstance()
        {
            var genus = AppConfig.ForesightAppGenus;

            switch (genus)
            {
                case Genus.Embedded:
                    return new ForesightSqlCeDatabase();
                case Genus.Server:
                    return new ForesightSqlServerDatabase();
                default:
                    throw new ValidationException(
                        string.Format(Resources.GenusNotSupported, genus));
            }
        }
    }
}
