using Foresight.Logic.Connection;
using Scalable.Shared.Common;

namespace Foresight.Logic.DataAccess
{
    public class ForesightSqlCeDatabase : ForesightDatabase
    {
        #region Declarations

        private const string databaseFileName = "Foresight.isd";
        private const string foresightFilePassword = "iScalable@2011";

        #endregion

        #region Constructors

        public ForesightSqlCeDatabase()
        {
            setDatabaseContext();
        }

        #endregion

        #region Internal Methods

        private void setDatabaseContext()
        {
            IDbConnectionInfo connInfo = new SqlCeConnectionInfo(getForesightFilePath(), foresightFilePassword);
            db = DatabaseFactory.GetForesightDatabase(connInfo);
        }

        private static string getForesightFilePath()
        {
            return AppConfig.AppPath + @"\" + databaseFileName;
        }

        #endregion
    }
}
