using Foresight.Logic.Sql;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Foresight.Logic.DataAccess
{
    public abstract class CoGroupDatabase : IDisposable
    {
        private const string databaseScriptFileName = "ForesightData.sqlce";
        protected Database groupDb;
        protected CompanyGroup companyGroup;
        private readonly ForesightDatabase _foresightDb;

        protected CoGroupDatabase()
        {
            _foresightDb = ForesightDatabaseFactory.GetInstance();
        }

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            if (groupDb != null)
                groupDb.Close();
        }

        public bool IsDatabaseExists(string databaseName)
        {
            return groupDb.IsDatabaseExists(databaseName);
        }

        public int SaveCompanyGroup(CompanyGroup coGroup)
        {
            companyGroup = coGroup;

            if (coGroup.IsNew())
            {
                if (shouldCreateDataFile(coGroup))
                    return createCompanyGroup();
                else
                    return saveCompanyGroupInForesight();
            }
            else
                return updateCompanyGroup();
        }

        private bool shouldCreateDataFile(CompanyGroup coGroup)
        {
            try
            {
                new DataContext(coGroup).GetCompanyGroupById(1);
                return false;
            }
            catch { }

            return true;
        }

        private int createCompanyGroup()
        {
            companyGroup.FilePath = getCompanyGroupDatabaseName();
            companyGroup.ForesightDatabaseName = companyGroup.FilePath;
            companyGroup.Entity.ForesightDatabaseName = companyGroup.FilePath;
            validateCompanyGroup(companyGroup);
#if DEBUG
            checkScriptFileExists();
#endif
            createCompanyGroupDatabase();
            createDatabaseSchema(getDatabaseSchemaScript());
            saveCompanyGroup(SqlQueries.InsertCompanyGroup);
            return saveCompanyGroupInForesight();
        }

        private void validateCompanyGroup(CompanyGroup companyGroup)
        {
            if (string.IsNullOrWhiteSpace(companyGroup.Entity.Name))
                throw new ValidationException("Company group name cannot be empty");

            if (_foresightDb.IsCompanyGroupNameExist(companyGroup))
                throw new ValidationException("This company group already exist");
        }

        private int saveCompanyGroupInForesight()
        {
            return _foresightDb.SaveCompanyGroup(companyGroup);
        }

        protected abstract string getCompanyGroupDatabaseName();
        protected abstract void createCompanyGroupDatabase();
        protected abstract void deleteCompanyGroupDatabase(CompanyGroup coGroup);

        public void DeleteCompanyGroup(CompanyGroup coGroup)
        {
            deleteCompanyGroupDatabase(coGroup);
            _foresightDb.DeleteCompanyGroup(coGroup);
        }

        private string getDatabaseSchemaScript()
        {

#if DEBUG
            return File.ReadAllText(getDatabaseScriptFileName());
#else
            return _foresightDb.GetDbScript();
#endif
        }

#if DEBUG
        private void checkScriptFileExists()
        {
            if (!File.Exists(getDatabaseScriptFileName()))
                throw new ValidationException(
                    $"Script file {databaseScriptFileName} not found at {getDatabaseScriptFileName()}");
        }
#endif
        private string getDatabaseScriptFileName()
        {
            return AppConfig.AppPath + @"\" + databaseScriptFileName;
        }

        private void createDatabaseSchema(string script)
        {
            var cmd = groupDb.CreateCommand();
            var builder = new StringBuilder(0x2710);

            using (var reader = new StringReader(script))
            {
                string scriptLine;

                while ((scriptLine = reader.ReadLine()) != null)
                {
                    if (scriptLine.Equals("GO", StringComparison.OrdinalIgnoreCase))
                    {
                        cmd.CommandText = builder.ToString();
                        cmd.ExecuteNonQuery();
                        builder.Remove(0, builder.Length);
                    }
                    else if (!scriptLine.StartsWith("-- "))
                    {
                        builder.Append(scriptLine);
                        builder.Append(Environment.NewLine);
                    }
                }
            }
        }

        private int updateCompanyGroup()
        {
            setDatabaseContext();
            validateCompanyGroup(companyGroup);
            saveCompanyGroup(SqlQueries.UpdateCompanyGroup);
            return updateCompanyGroupInForesight();
        }

        protected abstract void setDatabaseContext();

        private void saveCompanyGroup(string commandText)
        {
            var cmd = groupDb.CreateCommand(commandText);
            groupDb.AddParameterWithValue(cmd, "@Id", 1);
            groupDb.AddParameterWithValue(cmd, "@Name", companyGroup.Entity.Name);
            cmd.ExecuteNonQuery();
        }

        private int updateCompanyGroupInForesight()
        {
            return _foresightDb.UpdateCompanyGroup(companyGroup);
        }
    }
}
