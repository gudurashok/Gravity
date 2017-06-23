using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Model;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class UTopNAccountWiseItemsReport : UReportBase
    {
        private IList<AccountItemValue> _report;

        #region Constructor

        public UTopNAccountWiseItemsReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UTopNAccountsReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        void initialize()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyPeriod);
        }

        void processCompanyPeriod()
        {
            SelectedCoPeriods = new List<CompanyPeriod>();
            showReport();
        }

        private void cmbAmtFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(changeAmountFormat);
        }

        void changeAmountFormat()
        {
            if (_report == null)
                return;

            renderReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(Close);
        }

        private void lvwReport_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showSelectedAccountLedger);
        }

        void showSelectedAccountLedger()
        {
            if (lvwReport.SelectedItems[0].Tag == null)
                return;

            showLedger();
        }

        #endregion

        #region Private Methods

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                    (int)AmountFormat);
        }

        private void showReport()
        {
            getReportData(SelectedCoPeriods);
            renderReport();
        }

        private void getReportData(IList<CompanyPeriod> selectedCoPeriods)
        {
            var idc = rdc as TopNAccountItemsBaseDataContext;
            if (idc == null)
                return;

            idc.ItemGrouping = chkItemGrouping.Checked;
            idc.TopNCount = Convert.ToInt32(nudTopNCount.Value);
            idc.SelectedCoPeriods = selectedCoPeriods;
            _report = rdc.GetReportData().Result as IList<AccountItemValue>;
        }

        private void buildReportViewColumns()
        {
            clearList();
            lvwReport.Columns.Add("Rank", 45);
            lvwReport.Columns.Add(getAccountColumnName(), 150);
            lvwReport.Columns.Add(getItemColumnName(), 150);
            lvwReport.Columns.Add("Total Amount", 100, HorizontalAlignment.Right);
        }

        private void clearList()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();
        }

        private string getAccountColumnName()
        {
            const string a = "Account";
            return chkPartyGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private string getItemColumnName()
        {
            const string a = "Items";
            return chkItemGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
        }

        private void addReportViewRows()
        {
            var rank = 1;
            foreach (var iv in _report)
            {
                var lvi = new ListViewItem(rank.ToString());
                lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
                lvi.Tag = iv;
                lvi.SubItems.Add(iv.AccountName);
                lvi.SubItems.Add(iv.ItemName);
                lvi.SubItems.Add(formatAmount(iv.Amount, cmbAmtFormat));
                lvwReport.Items.Add(lvi);
                rank++;
            }
        }

        private void showLedger()
        {
            var account = ForesightSession.Dbc.GetAccountById(((AccountItemValue)lvwReport.SelectedItems[0].Tag).AccountId);

            if (account == null)
                return;

            FReportViewer.ShowLedger(FindForm(), account);
        }

        #endregion
    }
}
