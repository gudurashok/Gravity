using System.ComponentModel.DataAnnotations;
using Foresight.Logic.Common;
using Foresight.Logic.Properties;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Foresight.Logic.Connection
{
    internal static class TargetDbConnInfoFactory
    {
        public static IDbConnectionInfo GetConnectionInfo(CompanyGroup companyGroup)
        {
            var genus = AppConfig.ForesightAppGenus;

            switch (genus)
            {
                case Genus.Embedded:
                    return new SqlCeConnectionInfo(companyGroup.FilePath, ForesightUtil.ForesightDbPassword);
                case Genus.Server:
                    return GetSqlConnectionInfo();
                default:
                    throw new ValidationException(string.Format(Resources.GenusNotSupported, genus));
            }
        }

        public static IDbConnectionInfo GetSqlConnectionInfo()
        {
            return new SqlServerConnectionInfo(ForesightUtil.GetServerValue());
        }
    }
}
