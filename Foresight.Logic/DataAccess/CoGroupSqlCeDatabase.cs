using System.Text;
using System.IO;
using Gravity.Root.Model;
using Foresight.Logic.Common;
using Scalable.Shared.Common;

namespace Foresight.Logic.DataAccess
{
    public class CoGroupSqlCeDatabase : CoGroupDatabase
    {
        private const string dataFileExtension = ".fsd";

        protected override void createCompanyGroupDatabase()
        {
            createCompanyGroupWithEngine();
            groupDb = DatabaseFactory.GetForesightDatabase(companyGroup);
        }

        protected override string getCompanyGroupDatabaseName()
        {
            return getCompanyGroupFileName();
        }

        private void createCompanyGroupWithEngine()
        {
            var engine = ForesightUtil.GetSqlCeAssembly().CreateInstance("System.Data.SqlServerCe.SqlCeEngine");
            if (engine == null)
                return;

            var type = engine.GetType();
            var pi = type.GetProperty("LocalConnectionString");
            pi.SetValue(engine, getNewDbConnectionString(), null);
            var mi = type.GetMethod("CreateDatabase");
            mi.Invoke(engine, null);
        }

        private string getNewDbConnectionString()
        {
            var result = new StringBuilder("Data Source=" + companyGroup.FilePath);

            if (!string.IsNullOrEmpty(ForesightUtil.ForesightDbPassword))
                result.Append(";Password=" + ForesightUtil.ForesightDbPassword);

            return result.ToString();
        }

        private string getCompanyGroupFileName()
        {
            return companyGroup.ForesightDatabaseName + dataFileExtension;
        }

        protected override void setDatabaseContext()
        {
            groupDb = DatabaseFactory.GetForesightDatabase(companyGroup);
        }

        protected override void deleteCompanyGroupDatabase(CompanyGroup coGroup)
        {
            var fi = new FileInfo(coGroup.FilePath);
            if (fi.Directory != null && !fi.Directory.Exists)
                return;

            fi.Delete();
        }

        private string getDataPath()
        {
            //TODO: get from the config file
            //string path = Common.GetDataPath();
            //if (path == null) path = DataPath;

            //return Common.GetAppPath();
            var path = AppConfig.ForesightDataPath;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
