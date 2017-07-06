using System;
using Foresight.Logic.Connection;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Foresight.Logic.DataAccess
{
    public class ForesightSqlCeDatabase : ForesightDatabase
    {
        private const string databaseFileName = "Foresight.isd";
        private const string foresightFilePassword = "iScalable@2011";

        public ForesightSqlCeDatabase()
        {
            setDatabaseContext();
        }

        public override bool IsCompanyGroupExist(string companyGroupDbName)
        {
            return File.Exists(companyGroupDbName);
        }

        private void setDatabaseContext()
        {
            IDbConnectionInfo connInfo = new SqlCeConnectionInfo(getForesightFilePath(), foresightFilePassword);
            db = DatabaseFactory.GetForesightDatabase(connInfo);
        }

        private static string getForesightFilePath()
        {
            return AppConfig.AppPath + @"\" + databaseFileName;
        }
    }
}
