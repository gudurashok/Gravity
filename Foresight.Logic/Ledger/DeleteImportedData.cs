using System.Data;
using Foresight.Logic.DataAccess;
using Foresight.Logic.Sql;
using Insight.Domain.Model;

namespace Foresight.Logic.Ledger
{
    internal class DeleteImportedData
    {
        private readonly IDbCommand _cmd;
        private readonly CompanyPeriod _cp;
        private readonly Database _db;

        public DeleteImportedData(Database db, IDbCommand cmd, CompanyPeriod cp)
        {
            _db = db;
            _cmd = cmd;
            _cp = cp;
        }

        public void Delete()
        {
            var deleteCmd = _cmd.Connection.CreateCommand();
            deleteCmd.Transaction = _cmd.Transaction;
            var rdr = getTransTableList(deleteCmd);
            while (rdr.Read())
                deleteTransTablePeriodData(_cmd, _cp, rdr);

            rdr.Close();
        }

        private void deleteTransTablePeriodData(IDbCommand cmd, CompanyPeriod cp, IDataReader rdr)
        {
            cmd.CommandText = string.Format(SqlQueries.DeleteTransTablePeriodData, rdr["TableName"]);
            cmd.Parameters.Clear();
            _db.AddParameterWithValue(cmd, "@CompanyId", cp.Company.Entity.Id);
            _db.AddParameterWithValue(cmd, "@PeriodId", cp.Period.Entity.Id);
            cmd.ExecuteNonQuery();
        }

        private static IDataReader getTransTableList(IDbCommand cmd)
        {
            cmd.CommandText = SqlQueries.SelectTransTables;
            return cmd.ExecuteReader();
        }
    }
}
