using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Foresight.Logic.Common;
using Foresight.Logic.Sql;
using Gravity.Root.Enums;
using Gravity.Root.Model;
using Insight.Domain.Model;

namespace Foresight.Logic.DataAccess
{
    public abstract class ForesightDatabase : IDisposable
    {
        protected Database db;

        public void Dispose()
        {
            db.Close();
        }

        public bool IsCompanyGroupNameExist(CompanyGroup companyGroup)
        {
            var cmd = db.CreateCommand(SqlQueries.SelectCountByCompanyGroupName);
            db.AddParameterWithValue(cmd, "@name", companyGroup.Entity.Name);
            var value = cmd.ExecuteScalar();
            return Convert.ToInt32(value) > 0;
        }

        public IEnumerable<CompanyGroup> GetCompanyGroups()
        {
            var result = new List<CompanyGroup>();
            var rdr = db.ExecuteReader(SqlQueries.SelectAllCompanyGroups);
            while (rdr.Read())
                result.Add(readCompanyGroup(rdr));

            rdr.Close();
            return result;
        }

        private CompanyGroup readCompanyGroup(IDataReader rdr)
        {
            var companyGroup = CompanyGroup.New();
            companyGroup.Entity.Name = rdr["Name"].ToString();
            companyGroup.FilePath = rdr["DatabaseName"].ToString();
            companyGroup.Entity.Id = rdr["Id"].ToString();
            return companyGroup;
        }

        public int SaveCompanyGroup(CompanyGroup companyGroup)
        {
            var cmd = db.CreateCommand(SqlQueries.ForesightInsertCompanyGroup);
            db.AddParameterWithValue(cmd, "@Name", companyGroup.Entity.Name);
            db.AddParameterWithValue(cmd, "@DatabaseName", companyGroup.Entity.ForesightDatabaseName);
            cmd.ExecuteNonQuery();
            var newId = db.GetGeneratedIdentityValue();
            return Convert.ToInt32(newId);
        }

        public int UpdateCompanyGroup(CompanyGroup companyGroup)
        {
            var cmd = db.CreateCommand(SqlQueries.ForesightUpdateCompanyGroup);
            db.AddParameterWithValue(cmd, "@Id", companyGroup.Entity.Id);
            db.AddParameterWithValue(cmd, "@Name", companyGroup.Entity.Name);
            db.AddParameterWithValue(cmd, "@DatabaseName", companyGroup.FilePath);
            cmd.ExecuteNonQuery();
            return 0;
        }

        public void DeleteCompanyGroup(CompanyGroup companyGroup)
        {
            db.ExecuteNonQuery(SqlQueries.ForesightDeleteCompanyGroup, "@Id", companyGroup.Entity.Id);
        }

        public Command GetCommandByNr(int nr)
        {
            var rdr = db.ExecuteReader(SqlQueries.SelectCommandByNr, "@nr", nr);
            Command ri = null;

            if (rdr.Read())
                ri = readCommand(rdr);

            rdr.Close();

            if (ri == null)
                throw new ValidationException(string.Format("Command Nr: {0} not found.", nr));

            return ri;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var result = new List<Command>();
            var rdr = db.ExecuteReader(SqlQueries.SelectAllCommands);
            while (rdr.Read())
                result.Add(readCommand(rdr));

            rdr.Close();
            return result;
        }

        private Command readCommand(IDataReader rdr)
        {
            var cmd = new Command();
            cmd.Id = rdr["Id"].ToString();
            cmd.Nr = Convert.ToInt32(rdr["Nr"]);
            cmd.Name = rdr["Name"].ToString();
            cmd.Title = rdr["Title"].ToString();
            cmd.Description = rdr["Description"].ToString();
            cmd.UIControlName = rdr["UIControlName"].ToString();
            cmd.IsActive = Convert.ToBoolean(rdr["IsActive"]);
            cmd.Type = (AppCommandType)rdr["Type"];
            cmd.Properties = readCommandPropsByCommandtNr(cmd.Id);
            return cmd;
        }

        private IList<CommandProp> readCommandPropsByCommandtNr(string commandId)
        {
            var result = new List<CommandProp>();
            var rdr = db.ExecuteReader(SqlQueries.SelectCommandPropsByCommandId,
                                                    "@commandId", commandId);
            while (rdr.Read())
                result.Add(new CommandProp
                {
                    Id = rdr["Id"].ToString(),
                    PropName = rdr["PropName"].ToString(),
                    PropValue = rdr["PropValue"].ToString()
                });

            rdr.Close();
            return result;
        }

        public IList<ChartOfAccountMapper> GetChartOfAccountsMapper()
        {
            var result = new List<ChartOfAccountMapper>();
            var rdr = db.ExecuteReader(SqlQueries.SelectChartOfAccountsMapper);
            while (rdr.Read())
                result.Add(readChartOfAccountMapper(rdr));

            rdr.Close();
            return result;
        }

        private ChartOfAccountMapper readChartOfAccountMapper(IDataReader rdr)
        {
            var coaMapper = new ChartOfAccountMapper();
            coaMapper.Id = rdr["Id"].ToString();
            coaMapper.ChartOfAccountId = rdr["ChartOfAccountId"].ToString();
            coaMapper.ChartOfAccountName = rdr["ChartOfAccountName"].ToString();
            coaMapper.EasyCode = ForesightUtil.ConvertDbNullToString(rdr["EasyCode"]);
            coaMapper.McsCode = ForesightUtil.ConvertDbNullToString(rdr["McsCode"]);
            coaMapper.TcsCode = ForesightUtil.ConvertDbNullToString(rdr["TcsCode"]);
            return coaMapper;
        }

        public string GetDbScript()
        {
            return db.ExecuteScalar(SqlQueries.SelectDbScript).ToString();
        }
    }
}
