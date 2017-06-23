using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Ferry.Logic.Properties;
using Foresight.Logic.Connection;
using Foresight.Logic.DataAccess;
using Insight.Domain.Enums;

namespace Ferry.Logic.Common
{
    public  static class FerryUtil
    {
        public static DatabaseProvider GetSourceProvider()
        {
            var sourceProvider = ConfigurationManager.AppSettings.Get("SourceProvider");

            switch (sourceProvider)
            {
                case "SqlServer":
                    return DatabaseProvider.SqlServer;
                case "OleDb":
                    return DatabaseProvider.OleDb;
                case "SqlCe":
                    return DatabaseProvider.SqlCe;
                case "Odbc":
                    return DatabaseProvider.Odbc;
                default:
                    throw new ValidationException(
                        String.Format(Resources.SourceDatabaseProviderNotSupported, sourceProvider));
            }
        }

        public static Database GetSourceDatabase(IDbConnectionInfo connInfo)
        {
            return new Database(DbConnectionFactory
                                .GetConnection(GetSourceProvider(), 
                                connInfo.GetConnectionString()));
        }
    }
}
