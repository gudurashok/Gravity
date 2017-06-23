using System;
using System.Collections.Generic;
using System.IO;
using Ferry.Logic.Common;
using Ferry.Logic.Connection;
using Foresight.Logic.DataAccess;
using Ferry.Logic.Model;
using Scalable.Shared.Model;

namespace Ferry.Logic.Base
{
    public abstract class CompanyExtractorBase
    {
        #region Declarations

        protected readonly string sourceDataPath;
        protected Database dbc;

        #endregion

        #region Constructor

        protected CompanyExtractorBase(string sourceDataPath)
        {
            this.sourceDataPath = sourceDataPath;
            dbc = FerryUtil.GetSourceDatabase(SourceDbConnInfoFactory.GetConnectionInfo(sourceDataPath));
        }

        #endregion        
        
        public abstract IList<SourceCompanyPeriod> GetSourceData();

        public SourceCompanyPeriod GetCompanyPeriod()
        {
            return createCompanyPeriod(new DirectoryInfo(sourceDataPath));
        }

        #region Create Company Period From Folder Name

        protected SourceCompanyPeriod createCompanyPeriod(DirectoryInfo dir)
        {
            var cp = new SourceCompanyPeriod();
            cp.CompanyCode = createCompanyName(dir.Name);
            cp.CompanyName = createCompanyName(dir.Name);
            cp.Period = createPeriod(dir.Name);
            cp.SourceDataPath = dir.FullName;
            return cp;
        }

        protected abstract string createCompanyName(string coName);

        private DatePeriod createPeriod(string companyName)
        {
            var period = new DatePeriod();
            makeDatePeriod(period, getFinancialYear(companyName));
            return period;
        }

        protected abstract void makeDatePeriod(DatePeriod period, int year);

        private int getFinancialYear(string companyName)
        {
            int year = Convert.ToInt32(companyName.Substring(companyName.Length - 2));
            year = addCentury(year);
            return year;
        }

        private int addCentury(int year)
        {
            return year + (year <= 70 ? 2000 : 1900);
        }

        #endregion
    }
}
