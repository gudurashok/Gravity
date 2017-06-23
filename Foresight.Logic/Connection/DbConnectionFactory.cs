using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using Foresight.Logic.Common;
using Foresight.Logic.Properties;
using Insight.Domain.Enums;

namespace Foresight.Logic.Connection
{
    public static class DbConnectionFactory
    {
        public static IDbConnection GetConnection(
                                    DatabaseProvider provider,
                                    string connectionString)
        {
            switch (provider)
            {
                case DatabaseProvider.SqlServer:
                    return new SqlConnection(connectionString);
                case DatabaseProvider.OleDb:
                    return new OleDbConnection(connectionString);
                case DatabaseProvider.SqlCe:
                    return getSqlCeConnection(connectionString);
                case DatabaseProvider.Odbc:
                    return new OdbcConnection(connectionString);
                default:
                    throw new ValidationException(
                            string.Format(Resources.TargetDatabaseProviderNotSupported, provider));
            }
        }

        private static IDbConnection getSqlCeConnection(string connectionString)
        {
            var conn = ForesightUtil.GetSqlCeAssembly().CreateInstance("System.Data.SqlServerCe.SqlCeConnection") as IDbConnection;
            if (conn == null) return null;
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
