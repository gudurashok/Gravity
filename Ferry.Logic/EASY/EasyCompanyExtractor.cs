using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using Ferry.Logic.Base;
using Ferry.Logic.Sql;
using Ferry.Logic.Model;
using Scalable.Shared.Model;

namespace Ferry.Logic.EASY
{
    public class EasyCompanyExtractor : CompanyExtractorBase
    {
        #region Constructor

        public EasyCompanyExtractor(string sourceDataPath)
            : base(sourceDataPath)
        {
        }

        #endregion

        #region Extract Source Data

        public override IList<SourceCompanyPeriod> GetSourceData()
        {
            if (shouldUseCompanyFile())
                return loadSourceData(readAllCompanyPeriods());

            return findAllCompanyPeriodsFromFolders();
        }

        private bool shouldUseCompanyFile()
        {
            try
            {
                if (!isConvertedCompanyFilesExists())
                    return false;

                dbc.ExecuteScalar(EasySqlQueries.SelectAllCompanyPeriods);
                return true;
            }
            catch { } //Intentionally ignored error thrown by the body

            return false;
        }

        private bool isConvertedCompanyFilesExists()
        {
            if (!File.Exists(sourceDataPath + @"\" + EasySqlQueries.FsEasyCoGroupFileName))
                return false;

            return File.Exists(sourceDataPath + @"\" + EasySqlQueries.FsEasyCompanyFileName);
        }

        private IDataReader readAllCompanyPeriods()
        {
            return dbc.ExecuteReader(EasySqlQueries.SelectAllCompanyPeriods);
        }

        private List<SourceCompanyPeriod> loadSourceData(IDataReader reader)
        {
            var result = new List<SourceCompanyPeriod>();

            while (reader.Read())
                result.Add(getSourceCoPeriod(reader));

            reader.Close();
            return result;
        }

        private SourceCompanyPeriod getSourceCoPeriod(IDataReader coData)
        {
            var cp = new SourceCompanyPeriod();
            cp.GroupCode = coData["CO_GRP"].ToString();
            cp.GroupName = coData["CO_GNAME"].ToString();
            cp.CompanyCode = coData["CO_CODE"].ToString();
            cp.CompanyName = coData["CO_NAME"].ToString();
            cp.Period = new DatePeriod
                            {
                                From = Convert.ToDateTime(coData["FINYEAR_BD"]),
                                To = Convert.ToDateTime(coData["FINYEAR_ED"])
                            };
            cp.SourceDataPath = coData["DIR_NAME"].ToString();
            return cp;
        }

        #endregion

        #region Extract Source Data From Folders

        private List<SourceCompanyPeriod> findAllCompanyPeriodsFromFolders()
        {
            return getProviderDirectories()
                        .Where(isProviderDirectoryValid)
                        .Select(createCompanyPeriod).ToList();
        }

        private IEnumerable<DirectoryInfo> getProviderDirectories()
        {
            var di = new DirectoryInfo(sourceDataPath);
            return di.GetDirectories("*_*");
        }

        private bool isProviderDirectoryValid(DirectoryInfo dir)
        {
            var files = dir.GetFiles("*.ASK");
            if (files.Length == 0) return false;
            var fi = files.SingleOrDefault(f => f.Name == "TXN_FILE.ASK");
            return fi != null;
        }

        protected override string createCompanyName(string coName)
        {
            return coName.Substring(0, coName.IndexOf('_'));
        }

        protected override void makeDatePeriod(DatePeriod period, int year)
        {
            period.From = new DateTime(year, 4, 1);
            period.To = new DateTime(year + 1, 3, 31);
        }

        #endregion
    }
}
