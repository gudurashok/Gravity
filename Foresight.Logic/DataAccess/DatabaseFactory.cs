using Foresight.Logic.Common;
using Foresight.Logic.Connection;
using Gravity.Root.Model;

namespace Foresight.Logic.DataAccess
{
    public static class DatabaseFactory
    {
        public static Database GetForesightDatabase(CompanyGroup companyGroup)
        {
            var db = GetForesightDatabase(TargetDbConnInfoFactory.GetConnectionInfo(companyGroup));
            db.ChangeDatabase(companyGroup.Entity.ForesightDatabaseName);
            return db;
        }

        public static Database GetForesightDatabase(IDbConnectionInfo connInfo)
        {
            return new Database(
                    DbConnectionFactory.GetConnection(
                                ForesightUtil.GetForesightDatabaseProvider(),
                                connInfo.GetConnectionString()));
        }
    }
}
