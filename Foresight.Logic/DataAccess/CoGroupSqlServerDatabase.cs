using Foresight.Logic.Connection;
using Foresight.Logic.Sql;
using Gravity.Root.Model;

namespace Foresight.Logic.DataAccess
{
    public class CoGroupSqlServerDatabase : CoGroupDatabase
    {
        public CoGroupSqlServerDatabase()
        {
            groupDb = DatabaseFactory.GetForesightDatabase(TargetDbConnInfoFactory.GetSqlConnectionInfo());
            changeDatabaseContextToMasterDb();
        }

        protected override void deleteCompanyGroupDatabase(CompanyGroup coGroup)
        {
            changeDatabaseContextToMasterDb();
            groupDb.ExecuteNonQuery(string.Format(SqlQueries.DropDatabase, coGroup.FilePath));
        }

        protected override void createCompanyGroupDatabase()
        {
            groupDb.ExecuteNonQuery(string.Format(SqlQueries.CreateDatabase, companyGroup.FilePath));
            groupDb.ChangeDatabase(companyGroup.FilePath);
        }

        protected override string getCompanyGroupDatabaseName()
        {
            return companyGroup.ForesightDatabaseName;
        }

        protected override void setDatabaseContext()
        {
            groupDb.ChangeDatabase(companyGroup.FilePath);
        }

        private void changeDatabaseContextToMasterDb()
        {
            groupDb.ChangeDatabase("master");
        }
    }
}
