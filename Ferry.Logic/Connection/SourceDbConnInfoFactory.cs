using System.ComponentModel.DataAnnotations;
using Ferry.Logic.Common;
using Ferry.Logic.Properties;
using Foresight.Logic.Connection;
using Insight.Domain.Enums;

namespace Ferry.Logic.Connection
{
    internal static class SourceDbConnInfoFactory
    {
        public static IDbConnectionInfo GetConnectionInfo(string path)
        {
            var provider = FerryUtil.GetSourceProvider();

            switch (provider)
            {
                case DatabaseProvider.Odbc:
                    return new OdbcConnectionInfo(path);
                case DatabaseProvider.OleDb:
                    return new OleDbConnectionInfo(path);
                default:
                    throw new ValidationException(
                        string.Format(Resources.SourceDatabaseProviderNotSupported, provider));
            }
        }
    }
}
