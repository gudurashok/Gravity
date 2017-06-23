using System;
using System.Collections.Generic;
using Ferry.Logic.Base;
using Ferry.Logic.Model;
using Ferry.Logic.Sql;
using System.Data;
using Scalable.Shared.Model;

namespace Ferry.Logic.MCS
{
    public class McsCompanyExtractor : CompanyExtractorBase
    {
        #region Constructor

        public McsCompanyExtractor(string sourceDataPath)
            : base(sourceDataPath)
        {
        }

        #endregion

        #region Extract Source Data

        public override IList<SourceCompanyPeriod> GetSourceData()
        {
            return loadSourceData(readSourceData());
        }

        private List<SourceCompanyPeriod> loadSourceData(IDataReader reader)
        {
            var result = new List<SourceCompanyPeriod>();

            while (reader.Read())
                result.Add(getSourceCoPeriod(reader));

            reader.Close();
            return result;
        }

        private IDataReader readSourceData()
        {
            return dbc.ExecuteReader(
                string.Format(McsSqlQueries.SelectAllCompanyPeriods, GetCompanyFileName()));
        }

        protected virtual string GetCompanyFileName()
        {
            return McsSqlQueries.CompanyFileName;
        }

        private SourceCompanyPeriod getSourceCoPeriod(IDataReader reader)
        {
            var result = new SourceCompanyPeriod();
            result.CompanyCode = reader["COM_CD"].ToString();
            result.CompanyName = reader["COM_NM"].ToString();
            result.GroupCode = reader["GROUP"].ToString();
            result.Period = new DatePeriod
                                {
                                    From = Convert.ToDateTime(reader["YDT1"]), 
                                    To = Convert.ToDateTime(reader["YDT2"])
                                };
            result.SourceDataPath = sourceDataPath + @"\" + result.CompanyCode;
            return result;
        }

        #endregion

        #region Overridden Methods

        protected override string createCompanyName(string coName)
        {
            return coName.Substring(0, 3);
        }

        protected override void makeDatePeriod(DatePeriod period, int year)
        {
            period.From = new DateTime(year - 1, 4, 1);
            period.To = new DateTime(year, 3, 31);
        }

        #endregion
    }
}
