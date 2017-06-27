using Foresight.Logic.Connection;

namespace Foresight.Logic.DataAccess
{
    public class ForesightSqlServerDatabase : ForesightDatabase
    {
        private const string databaseName = "Foresight";

        public ForesightSqlServerDatabase()
        {
            setDatabaseContext();
        }

        private void setDatabaseContext()
        {
            db = DatabaseFactory.GetForesightDatabase(TargetDbConnInfoFactory.GetSqlConnectionInfo());
            db.ChangeDatabase(databaseName);
        }
    }
}
