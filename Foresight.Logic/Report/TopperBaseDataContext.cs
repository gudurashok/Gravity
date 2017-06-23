﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public abstract class TopperBaseDataContext : ReportDataContext
    {
        public int TopNCount { protected get; set; }

        public override ReportData GetReportData()
        {
            var result = new List<CompanyPeriodTopperValue>();
            var coPeriods = getSelectedCoPeriods();

            foreach (var id in getDistinctIds(coPeriods))
            {
                var cp = getCompanyPeriodOf(coPeriods, id);
                var totalValue = getCompanyPeriodTotalValue(id);
                var rdr = db.ExecuteReader(getAccountsQuery(getCompanyPeriodFilter(id)));
                while (rdr.Read())
                    result.Add(readData(rdr, cp, totalValue));

                rdr.Close();
            }

            return new ReportData(result);
        }

        protected abstract IEnumerable<string> getDistinctIds(IEnumerable<CompanyPeriod> coPeriods);
        protected abstract CompanyPeriod getCompanyPeriodOf(IEnumerable<CompanyPeriod> coPeriods, string id);

        private decimal getCompanyPeriodTotalValue(string id)
        {
            var value = db.ExecuteScalar(getCompanyPeriodTotalValueQuery(getCompanyPeriodFilter(id)));
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }

        protected abstract string getCompanyPeriodFilter(string id);
        protected abstract string getAccountsQuery(string filterExpr);
        protected abstract string getCompanyPeriodTotalValueQuery(string filterExpr);

        private CompanyPeriodTopperValue readData(IDataReader rdr, CompanyPeriod cp, decimal totalValue)
        {
            var result = new CompanyPeriodTopperValue();
            result.CompanyPeriod = cp;
            result.Account = new AccountValue();
            result.Account.Id = rdr["Id"].ToString();
            result.Account.Name = rdr["Name"].ToString();
            result.Account.Amount = Convert.ToDecimal(rdr["TotalAmount"]);

            if (totalValue != 0)
                result.Account.Percentage = (decimal)((result.Account.Amount) / totalValue * 100);
            
            return result;
        }

        public decimal? GetAccountValue(string accountId, string id)
        {
            var filterExpr = new StringBuilder();
            filterExpr.Append(string.Format(" AND AccountId={0}", accountId));
            filterExpr.Append(getCompanyPeriodFilter(id));

            var value = db.ExecuteScalar(getCompanyPeriodTotalValueQuery(filterExpr.ToString()));

            if (value == DBNull.Value)
                return null;

            return Convert.ToDecimal(value);
        }
    }
}
