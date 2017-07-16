using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Gravity.Root.Model;
using Insight.Domain.Model;
using Insight.Domain.Enums;

namespace Foresight.Logic.Report
{
    public abstract class ReportDataContext : IDisposable
    {
        #region Declarations

        protected readonly Database db;
        public IList<CompanyPeriod> SelectedCoPeriods { protected get; set; }
        public bool PartyGrouping { protected get; set; }
        public bool ItemGrouping { protected get; set; }

        #endregion

        #region Constructor

        protected ReportDataContext()
        {
            db = DatabaseFactory.GetForesightDatabase(ForesightSession.CompanyGroup);
        }

        #endregion

        #region Factory Method

        public static ReportDataContext CreateInstance(Command command)
        {
            var asm = Assembly.GetExecutingAssembly();
            return asm.CreateInstance("Foresight.Logic.Report." +
                                        command.GetPropertyValue("DataContextName"),
                                            true) as ReportDataContext;
        }

        #endregion

        #region Public Members

        public abstract ReportData GetReportData();

        public void Dispose()
        {
            db.Close();
        }

        #endregion

        #region Internal Members

        protected IList<CompanyPeriod> getSelectedCoPeriods()
        {
            if (SelectedCoPeriods.Count > 0)
                return SelectedCoPeriods;

            return ForesightSession.Dbc.GetCompanyPeriods();
        }

        protected string[] getCompanyIds()
        {
            return getSelectedCoPeriods().Select(p => p.Company.Entity.Id).Distinct().ToArray();
        }

        protected string[] getPeriodIds()
        {
            return getSelectedCoPeriods().Select(p => p.Period.Entity.Id).Distinct().ToArray();
        }

        protected string[] getCoPeriodIds()
        {
            return getSelectedCoPeriods().Select(p => p.Entity.Id).ToArray();
        }

        protected string createFilterExprFrom(IList<string> selectedIds)
        {
            return createFilterExprFrom("", selectedIds);
        }

        protected string createFilterExprFrom(string prefix, IList<string> selectedIds)
        {
            if (selectedIds.Count() == 0)
                return "";

            var result = new StringBuilder(prefix).Append("(");
            foreach (var id in selectedIds)
                result.Append(string.Format("{0},", id));

            return result.Remove(result.Length - 1, 1).Append(")").ToString();
        }

        protected string getPartyIdentityColumn()
        {
            return PartyGrouping ? "GroupId" : "Id";
        }

        protected string getItemIdentityColumn()
        {
            return ItemGrouping ? "GroupId" : "Id";
        }

        protected string GetChartOfAccountIds(AccountTypes accountTypes)
        {
            return GetChartOfAccountIds((int)accountTypes);
        }

        protected string GetChartOfAccountIds(int coaId)
        {
            return ForesightSession.Dbc.GetChartOfAccountIds(coaId);
        }

        protected bool IsDaybookAccount(string accountId)
        {
            var daybook = ForesightSession.Dbc.GetDaybookOfAccount(accountId);
            return daybook != null;
        }

        #endregion
    }
}
