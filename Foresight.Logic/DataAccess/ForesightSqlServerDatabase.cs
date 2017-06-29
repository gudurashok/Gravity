using Foresight.Logic.Connection;
using Gravity.Root.Model;
using System;

namespace Foresight.Logic.DataAccess
{
    public class ForesightSqlServerDatabase : ForesightDatabase
    {
        private const string databaseName = "Foresight";

        public ForesightSqlServerDatabase()
        {
            setDatabaseContext();
        }

        public override bool IsCompanyGroupExist(CompanyGroup companyGroup)
        {
            return db.IsDatabaseExists(companyGroup.ForesightDatabaseName);
        }

        private void setDatabaseContext()
        {
            db = DatabaseFactory.GetForesightDatabase(TargetDbConnInfoFactory.GetSqlConnectionInfo());
            db.ChangeDatabase(databaseName);
        }
    }
}
