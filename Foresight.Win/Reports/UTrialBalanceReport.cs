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
using Scalable.Shared.Enums;

namespace Foresight.Win.Reports
{
    public partial class UTrialBalanceReport : UReportBase
    {
        #region Declarations

        private IList<TrialBalance> _report;
        private const int fudgeSize = 21;
        private const int accountNameColumnIndex = 0;
        private const int openingCreditColumnIndex = 1;
        private const int openingDebitColumnIndex = 2;
        private const int txnCreditColumnIndex = 3;
        private const int txnDebitColumnIndex = 4;
        private const int closingCreditColumnIndex = 5;

        #endregion

        #region Properties

        public IList<string> SelectedAccountIds { get; set; }
        public bool MultiSelect { private get; set; }
        public AccountTypes AccountTypes { private get; set; }

        #endregion

        #region Constructor

        public UTrialBalanceReport(Command command)
            : base(command)
        {
            InitializeComponent();
            SelectedAccountIds = new List<string>();
            loadAmountFormatList();
        }

        #endregion

        #region Load

        private void UTrialBalanceReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(intialize);
        }

        private void intialize()
        {
            lvwReport.Resize -= lvwReport_Resize;
            lvwReport.CheckBoxes = MultiSelect;
            btnInvertSelection.Visible = MultiSelect;
            btnClose.Visible = !(Parent is Form);
            showReport();
            btnShowLedger.Enabled = false;
            btnShowLedger.Focus();
            lvwReport.Resize += lvwReport_Resize;
        }

        #endregion

        #region Change Amount Format

        private void cmbAmtFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(ChangeAmountFormat);
        }

        private void ChangeAmountFormat()
        {
            if (_report == null)
                return;

            var selectedIndex = 0;
            if (lvwReport.SelectedIndices.Count > 0)
                selectedIndex = lvwReport.SelectedIndices[0];

            addReportViewRows();
            lvwReport.SelectItem(selectedIndex, true);
        }

        #endregion

        #region Report View Rows

        private void addReportViewRows()
        {
            lvwReport.Items.Clear();

            foreach (ListViewGroup group in lvwReport.Groups)
            {
                addReportViewRows(group, _report.Where(r => r.ChartOfAccountName == group.Name));
                addChartOfAccountGroupTotals(group);
            }

            addReportGrandTotals();
        }

        private void addChartOfAccountGroupTotals(ListViewGroup group)
        {
            var openingCr = _report.Where(r => r.ChartOfAccountName == group.Name && r.Opening > 0)
                                   .Sum(r => r.Opening);
            var openingDb = Math.Abs(_report.Where(r => r.ChartOfAccountName == group.Name && r.Opening < 0)
                                            .Sum(r => r.Opening));
            var transCr = _report.Where(r => r.ChartOfAccountName == group.Name)
                                 .Sum(r => r.TransactionCredit);
            var transDb = Math.Abs(_report.Where(r => r.ChartOfAccountName == group.Name)
                                          .Sum(r => r.TransactionDebit));

            var closingCr = _report.Where(r => r.ChartOfAccountName == group.Name && r.Closing > 0)
                                   .Sum(r => r.Closing);
            var closingDb = Math.Abs(_report.Where(r => r.ChartOfAccountName == group.Name && r.Closing < 0)
                                            .Sum(r => r.Closing));

            var lvi = new ListViewItem("TOTAL:", group);
            lvi.SubItems.Add(formatAmountWithBlank(openingCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(openingDb, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(transCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(transDb, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(closingCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(closingDb, cmbAmtFormat));

            lvwReport.Items.Add(lvi);
        }

        private void addReportGrandTotals()
        {
            var openingCr = _report.Where(r => r.Opening > 0).Sum(r => r.Opening);
            var openingDb = Math.Abs(_report.Where(r => r.Opening < 0).Sum(r => r.Opening));
            var transCr = _report.Sum(r => r.TransactionCredit);
            var transDb = Math.Abs(_report.Sum(r => r.TransactionDebit));
            var closingCr = _report.Where(r => r.Closing > 0).Sum(r => r.Closing);
            var closingDb = Math.Abs(_report.Where(r => r.Closing < 0).Sum(r => r.Closing));

            const string totalsGroupName = "REPORT GRAND TOTALS";
            var grandTotalsGroup = lvwReport.Groups.Add(totalsGroupName, totalsGroupName);
            grandTotalsGroup.Name = totalsGroupName;
            lvwReport.Groups.Add(grandTotalsGroup);

            var lvi = new ListViewItem("GRAND TOTAL:", grandTotalsGroup);
            lvi.BackColor = Color.Maroon;
            lvi.ForeColor = Color.White;
            lvi.SubItems.Add(formatAmountWithBlank(openingCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(openingDb, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(transCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(transDb, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(closingCr, cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(closingDb, cmbAmtFormat));

            lvwReport.Items.Add(lvi);
        }

        #endregion

        #region Party Group CheckedChange

        private void chkPartyGrouping_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processResize);
        }

        private void processResize()
        {
            lvwReport.Resize -= lvwReport_Resize;
            showReport();
            lvwReport.Resize += lvwReport_Resize;
        }

        #endregion

        #region Listview SelectedIndexChanged

        private void lvwReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(displayShowButton);
        }

        private void displayShowButton()
        {
            btnShowLedger.Enabled = (lvwReport.SelectedItems.Count > 0 &&
                                     lvwReport.SelectedItems[0].Tag as TrialBalance != null);
        }

        #endregion

        #region ListView DoubleClick

        private void lvwReport_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCheckedListViewItem);
        }

        #endregion

        #region when Modifier Keys pressed

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != Keys.Enter)
                return base.ProcessCmdKey(ref msg, keyData);

            EventHandlerExecutor.Execute(processCheckedListViewItem);

            return true;
        }

        private void processCheckedListViewItem()
        {
            if (!lvwReport.CheckBoxes)
                showLedger();
        }

        #endregion

        #region When Close button click

        private void btnClose_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(closeButton);
        }

        private void closeButton()
        {
            Close();
        }

        #endregion

        #region Show ledger

        private void btnShowLedger_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showAccountLedger);
        }

        private void showAccountLedger()
        {
            if (lvwReport.SelectedItems[0].Tag == null)
                return;

            showLedger();
        }

        private void showLedger()
        {
            var trialBalance = lvwReport.SelectedItems[0].Tag as TrialBalance;

            if (trialBalance == null)
                return;

            var account = ForesightSession.Dbc.GetAccountById(trialBalance.AccountId);
            FReportViewer.ShowLedger(FindForm(), account);
        }

        #endregion

        #region Invert Checked selection

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(invertSelection);
        }

        private void invertSelection()
        {
            foreach (ListViewItem lvi in lvwReport.Items)
                lvi.Checked = !lvi.Checked;
        }

        #endregion

        #region ShowReport

        private void showReport()
        {
            getReportData();
            renderReport();
        }


        private void getReportData()
        {
            var adc = rdc as AccountDataContext;
            rdc.PartyGrouping = chkPartyGrouping.Checked;
            if (adc == null)
                return;

            _report = adc.GetReportData().Result as IList<TrialBalance>;
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();

            lvwReport.Columns.Add(new iColumnHeader("Account Name", true, 150));
            lvwReport.Columns.Add(new iColumnHeader("Opening Credit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Opening Debit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Txn Credit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Txn Debit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Closing Credit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Closing Debit", DataType.Number, 120));

            createChartOfAccountGroups();
        }

        private void createChartOfAccountGroups()
        {
            foreach (var coaName in _report.Select(tb => tb.ChartOfAccountName).Distinct())
            {
                var group = lvwReport.Groups.Add(coaName, coaName);
                group.Name = coaName;
                lvwReport.Groups.Add(group);
            }
        }

        private void addReportViewRows(ListViewGroup group, IEnumerable<TrialBalance> data)
        {
            foreach (var trialBalance in data)
            {
                var lvi = new ListViewItem(trialBalance.AccountName, group);
                lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
                lvi.Tag = trialBalance;

                addOpeningBalanceSubItems(trialBalance, lvi);
                addTransactionSubItems(trialBalance, lvi);
                addClosingBalanceSubItems(trialBalance, lvi);

                lvwReport.Items.Add(lvi);
            }
        }

        private void addTransactionSubItems(TrialBalance trialBalance, ListViewItem lvi)
        {
            lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.TransactionCredit), cmbAmtFormat));
            lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.TransactionDebit), cmbAmtFormat));
        }

        private void addClosingBalanceSubItems(TrialBalance trialBalance, ListViewItem lvi)
        {
            if (trialBalance.Closing >= 0)
            {
                lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.Closing), cmbAmtFormat));
                lvi.SubItems.Add("");
            }
            else
            {
                lvi.SubItems.Add("");
                lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.Closing), cmbAmtFormat));
            }
        }

        private void addOpeningBalanceSubItems(TrialBalance trialBalance, ListViewItem lvi)
        {
            if (trialBalance.Opening >= 0)
            {
                lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.Opening), cmbAmtFormat));
                lvi.SubItems.Add("");
            }
            else
            {
                lvi.SubItems.Add("");
                lvi.SubItems.Add(formatAmountWithBlank(Math.Abs(trialBalance.Opening), cmbAmtFormat));
            }
        }

        #endregion

        #region PartyGroups

        public void ShowPartyGroups()
        {
            chkPartyGrouping.Visible = true;
        }

        public bool IsPartyGroupingSelected()
        {
            return chkPartyGrouping.Checked;
        }

        public void ProjectSelectedAccounts()
        {
            SelectedAccountIds = new List<string>();

            if (MultiSelect)
                populateSelectedItems();
            else
                populateSelectedItem();
        }

        private void populateSelectedItems()
        {
            for (var index = 0; index < lvwReport.CheckedItems.Count; index++)
                SelectedAccountIds.Add(((TrialBalance)lvwReport.CheckedItems[index].Tag).AccountId);
        }

        private void populateSelectedItem()
        {
            if (lvwReport.SelectedItems.Count == 0)
                return;

            SelectedAccountIds.Add((lvwReport.CheckedItems[0].Tag as TrialBalance).AccountId);
        }

        #endregion

        #region Common

        private void lvwReport_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processResizeListView);
        }

        private void processResizeListView()
        {
            if (lvwReport.Columns.Count > 0)
                autoResize();
        }

        private void autoResize()
        {
            lvwReport.Columns[accountNameColumnIndex].Width =
                lvwReport.Width - lvwReport.Columns[openingCreditColumnIndex].Width
                - lvwReport.Columns[openingDebitColumnIndex].Width
                - lvwReport.Columns[txnCreditColumnIndex].Width
                - lvwReport.Columns[txnDebitColumnIndex].Width
                - lvwReport.Columns[closingCreditColumnIndex].Width
                - lvwReport.Columns[openingDebitColumnIndex].Width
                - fudgeSize;
        }

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                       (int)ReportsAmountFormat.Thousands);
        }

        #endregion
    }
}
