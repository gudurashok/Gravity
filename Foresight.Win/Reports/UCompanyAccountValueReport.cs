using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;

namespace Foresight.Win.Reports
{
    public partial class UCompanyAccountValueReport : UReportBase
    {
        #region Declarations

        private IList<CompanyPeriodAccountValue> _report;

        #endregion

        #region Constructor

        public UCompanyAccountValueReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
        }

        #endregion

        #region Constructor Helper methods

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                       (int)AmountFormat);
        }

        #endregion

        #region Load Report

        private void UCompanyAccountValueReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(loadReport);
        }

        private void loadReport()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        #endregion

        #region Company button click

        private void btnSelectCompany_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(selectCompanyPeriods);
        }

        private void selectCompanyPeriods()
        {
            if (!selectCompanyPeriods(CompanyPeriodType.Company))
                return;

            showReport();
        }

        #endregion

        #region show button clicked

        private void btnShow_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showReport);
        }

        #endregion

        #region show all button clicked

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyPeriod);
        }

        private void processCompanyPeriod()
        {
            SelectedCoPeriods = new List<CompanyPeriod>();
            showReport();
        }

        #endregion

        #region Change Amount Format

        private void cmbAmtFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(changeAmountFormat);
        }

        private void changeAmountFormat()
        {
            if (_report == null)
                return;
            renderReport();
        }

        #endregion

        #region ListView Double

        private void lvwReport_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showLedger);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(Close);
        }

        #region Private methods

        private void showLedger()
        {
            var companyPeriodAccountValue = lvwReport.SelectedItems[0].Tag as CompanyPeriodAccountValue;

            if (companyPeriodAccountValue == null)
                return;

            var account = ForesightSession.Dbc.GetAccountById(companyPeriodAccountValue.Topper.Account.Id);
            if (account == null)
                return;

            FReportViewer.ShowLedger(FindForm(), account);
        }


        private void showReport()
        {
            getReportData();
            renderReport();
        }

        private void getReportData()
        {
            var adc = rdc as CompanyAccountBaseDataContext;
            rdc.PartyGrouping = chkPartyGrouping.Checked;
            if (adc == null)
                return;

            adc.SelectedCoPeriods = SelectedCoPeriods;
            adc.TopNCount = Convert.ToInt32(nudTopNCount.Value);
            _report = adc.GetReportData().Result as IList<CompanyPeriodAccountValue>;
        }

        private void renderReport()
        {
            if (_report.Count == 0)
                return;

            buildReportViewColumns();
            addReportViewRows();
            formatReportView();
        }

        private void formatReportView()
        {
            formatCompanyColumn();
            formatTotalRow();
        }

        private void formatCompanyColumn()
        {
            foreach (ListViewItem item in lvwReport.Items)
                item.SubItems[0].ForeColor = Color.Blue;

            lvwReport.Items[lvwReport.Items.Count - 1].SubItems[0].ForeColor = Color.Brown;
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Add(new iColumnHeader(getColumnName(), 150));

            var companyIds = getDistinctCompanies();
            var count = companyIds.Count();

            foreach (var accountValue in companyIds.Select(getAccountValueOf))
            {
                addListCompanyColumn(accountValue);

                if (count != 1)
                    addDiffPctListColumn();

                count--;
            }
        }

        private string getColumnName()
        {
            var a = Command.GetPropertyValue("ListColumnTitle");
            return chkPartyGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private void formatTotalRow()
        {
            var lvi = lvwReport.Items[lvwReport.Items.Count - 1];
            foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
            {
                lvs.Font = new Font(Font, FontStyle.Bold);
                lvs.ForeColor = Color.Maroon;
            }
        }

        private void addListCompanyColumn(CompanyPeriodAccountValue cpav)
        {
            var company = new iColumnHeader(cpav.Topper.CompanyPeriod.Company.Entity.Code, 100);
            lvwReport.Columns.Add(company);
            company.Tag = cpav.Topper.CompanyPeriod.Company.Entity.Id;
        }

        private void addDiffPctListColumn()
        {
            var diffPct = new iColumnHeader("Diff.%", 65);
            lvwReport.Columns.Add(diffPct);
        }

        private IEnumerable<string> getDistinctCompanies()
        {
            return (from r in _report
                    orderby r.Topper.CompanyPeriod.Company.Entity.Id descending
                    select r.Topper.CompanyPeriod.Company.Entity.Id).Distinct();
        }

        private CompanyPeriodAccountValue getAccountValueOf(string companyId)
        {
            return _report.First(r => r.Topper.CompanyPeriod.Company.Entity.Id == companyId);
        }

        private void addReportViewRows()
        {
            foreach (var accountId in (_report.Select(r => r.Topper.Account.Id).Distinct()))
            {
                var accounts = getAccountsOf(accountId);

                var lvi = new ListViewItem(accounts[0].Topper.Account.Name);
                lvi.UseItemStyleForSubItems = false;

                for (var i = 1; i < lvwReport.Columns.Count; i = i + 2)
                    addSubItem(lvi, getAccountValueOfCompany(accounts, accountId, getColumnCompanyId(i)));

                lvwReport.Items.Add(lvi);
            }
        }

        private IList<CompanyPeriodAccountValue> getAccountsOf(string accountId)
        {
            return (from r in _report
                    where r.Topper.Account.Id == accountId
                    orderby r.Topper.CompanyPeriod.Company.Entity.Id descending
                    select r).ToList();
        }

        private string getColumnCompanyId(int i)
        {
            return lvwReport.Columns[i].Tag.ToString();
        }

        private CompanyPeriodAccountValue getAccountValueOfCompany(IEnumerable<CompanyPeriodAccountValue> accounts,
                                                                   string accountId, string companyId)
        {
            var cpav = accounts.SingleOrDefault(cp => cp.Topper.CompanyPeriod.Company.Entity.Id == companyId);
            if (cpav == null)
            {
                var value = getCompanyAccountValue(accountId, companyId);
                return new CompanyPeriodAccountValue
                {
                    Topper = new CompanyPeriodTopperValue
                    {
                        Account = new AccountValue { Id = accountId, Amount = value }
                    }
                };
            }

            return cpav;
        }

        private decimal? getCompanyAccountValue(string accountId, string companyId)
        {
            var adc = rdc as CompanyAccountBaseDataContext;
            return adc != null ? adc.GetCompanyAccountValue(accountId, companyId) : null;
        }

        private void addSubItem(ListViewItem lvi, CompanyPeriodAccountValue apv)
        {
            var lvs = lvi.SubItems.Add(getAccountValue(apv));
            lvi.Tag = apv;
            formatSubItem(lvs);
            setColorOfNotInTopN(apv, lvs);
            addDiffPctSubItem(apv, lvi);
        }

        private string getAccountValue(CompanyPeriodAccountValue apv)
        {
            var value = apv.Topper.Account.Amount ?? 0;

            if (isNotInTopN(apv))
                if (apv.Topper.Account.Amount == null)
                    return "<N.A>";
                else
                    return string.Format("<{0}>", formatAmount(value, cmbAmtFormat));

            return formatAmount(value, cmbAmtFormat);
        }

        private void setColorOfNotInTopN(CompanyPeriodAccountValue apv, ListViewItem.ListViewSubItem lvs)
        {
            if (isNotInTopN(apv))
                lvs.ForeColor = Color.DarkGray;
        }

        private bool isNotInTopN(CompanyPeriodAccountValue apv)
        {
            return (string.IsNullOrWhiteSpace(apv.Topper.Account.Id)) &&
                   string.IsNullOrWhiteSpace(apv.Topper.Account.Name);
        }

        private void formatSubItem(ListViewItem.ListViewSubItem listViewSubItem)
        {
            listViewSubItem.Font = new Font(lvwReport.Font, FontStyle.Regular);
        }

        private void addDiffPctSubItem(CompanyPeriodAccountValue account, ListViewItem lvi)
        {
            var pct = account.DifferencePct;
            var lvs = lvi.SubItems.Add((pct ?? 0).ToString("0.00"));
            lvs.ForeColor = getDifferencePctColor(account.DifferencePct);
            lvs.Font = new Font(lvwReport.Font, FontStyle.Regular);
        }

        private Color getDifferencePctColor(decimal? value)
        {
            if (value < 0)
                return Color.FromName(Command.GetPropertyValue("NegativePctColor"));

            if (value > 0)
                return Color.FromName(Command.GetPropertyValue("PositivePctColor"));

            return Color.Black;
        }

        #endregion

        private void lvwReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerExecutor.Execute(pressEnterKey, sender, e);
        }

        private void pressEnterKey(object sender, EventArgs e)
        {
            var args = e as KeyPressEventArgs;

            if (args.KeyChar != (char)Keys.Enter)
                return;

            showLedger();
        }
    }
}
