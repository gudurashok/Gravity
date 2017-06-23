using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Configuration;
using Foresight.Logic.Connection;
using Foresight.Logic.DataAccess;
using Foresight.Logic.Properties;
using Insight.Domain.Enums;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;

namespace Foresight.Logic.Common
{
    public static class ForesightUtil
    {
        public static void TestDatabaseConnection()
        {
            TestDatabaseConnection(TargetDbConnInfoFactory.GetSqlConnectionInfo());
        }

        public static void TestDatabaseConnection(IDbConnectionInfo sqlConnInfo)
        {
            new Database(DbConnectionFactory.GetConnection(
                DatabaseProvider.SqlServer, sqlConnInfo.GetConnectionString()));
        }

        public static DatabaseProvider GetForesightDatabaseProvider()
        {
            var genus = AppConfig.AppGenus;

            switch (genus)
            {
                case Genus.Embedded:
                    return DatabaseProvider.SqlCe;
                case Genus.Server:
                    return DatabaseProvider.SqlServer;
                default:
                    throw new ValidationException(string.Format(Resources.GenusNotSupported, genus));
            }
        }

        public static string GetLionValue()
        {
            return ConfigurationManager.AppSettings.Get("Lion");
        }

        public static object ConvertToDbValue(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return DBNull.Value;
            
            return value;
        }

        public static object ConvertDbNull(object value)
        {
            return DBNull.Value == value ? null : value;
        }

        public static string ConvertDbNullToString(object value)
        {
            return DBNull.Value == value ? string.Empty : value.ToString();
        }

        public static Assembly GetSqlCeAssembly()
        {
#if DEBUG
            return Assembly.LoadFrom(@"C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Desktop\System.Data.SqlServerCe.dll");
#else
            return Assembly.LoadFrom(string.Format(@"{0}\Private\System.Data.SqlServerCe.dll", AppConfig.AppPath));
#endif
        }
    }
}
