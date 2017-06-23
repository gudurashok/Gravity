using Foresight.Logic.Connection;

namespace Foresight.Logic.DataAccess
{
    public class ForesightSqlServerDatabase : ForesightDatabase
    {
        #region Declarations

        private const string databaseName = "Foresight";

        #endregion

        #region Constructors

        public ForesightSqlServerDatabase()
        {
            setDatabaseContext();
        }

        #endregion

        #region Internal Methods

        private void setDatabaseContext()
        {
            db = DatabaseFactory.GetForesightDatabase(TargetDbConnInfoFactory.GetSqlConnectionInfo());
            db.ChangeDatabase(databaseName);
        }

        #endregion
    }
}
