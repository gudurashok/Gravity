using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Shared.Enums;

namespace Foresight.Win.Reports
{
    public partial class ULedgerSummaryReport : UReportBase
    {
        #region Declarations

        private LedgerSummary _yearTotal;
        private IList<LedgerSummary> _report;
        private readonly Account _account;
        private readonly Daybook _daybook;
        private LedgerView _currentView = LedgerView.Yearly;
        public ULedgerDetailReport DetailControl { private get; set; }

        #endregion

        #region Constructor

        public ULedgerSummaryReport(Command command, Daybook jvDaybook)
            : base(command)
        {
            _daybook = jvDaybook;
            initializeReport();
        }

        public ULedgerSummaryReport(Command command, Account account)
            : base(command)
        {
            _account = account;
            initializeReport();
        }

        private void initializeReport()
        {
            InitializeComponent();
            rdc = new LedgerSummaryDataContext();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UCompanyLedgerReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            setReportTitle();
            lblDescription.Text = _account == null ? "" : _account.ToStringAddress();
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

        private void lvwReport_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processLedgerView);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Enter)
                {
                    processLedgerView();
                    return true;
                }

                if (keyData == Keys.Back)
                {
                    processBackButton();
                    return true;
                }

            }
            catch (Exception ex)
            {
                ExceptionProcessor.Process(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void processLedgerView()
        {
            if (lvwReport.SelectedItems.Count == 0)
                return;

            switchLedgerView();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processBackButton);
        }

        #endregion

        #region Private Methods

        private void switchLedgerView()
        {
            Cursor = Cursors.WaitCursor;

            if (_currentView == LedgerView.Yearly)
                showMonthlyLedger();
            else
                showDetailLedger();
        }

        private void processBackButton()
        {
            Cursor = Cursors.WaitCursor;

            if (_currentView == LedgerView.Yearly)
            {
                var form = FindForm();
                if (form != null) form.Close();
            }
            else
            {
                _currentView = LedgerView.Yearly;
                setViewTypeColumnText();
                setLedgerPeriod();

                Cursor = Cursors.Default;
                showReport();
            }
        }

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                    (int)ReportsAmountFormat.Thousands);
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Add(new iColumnHeader("Year", 80));

            if (_currentView == LedgerView.Yearly)
                lvwReport.Columns.Add(new iColumnHeader("Opening", DataType.Number, 120));

            lvwReport.Columns.Add(new iColumnHeader("Credit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Debit", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader("Balance", DataType.Number, 120));
        }

        private void setViewTypeColumnText()
        {
            lvwReport.Columns[0].Text = _currentView == LedgerView.Yearly ? "Year" : "Month";
        }

        private void setReportTitle()
        {
            lblTitle.Text = _account == null ? _daybook.Entity.Name : _account.Entity.Name;
        }

        private void showReport()
        {
            getReportData();
            renderReport();
            lvwReport.SelectTopItem(true);
        }

        private void getReportData()
        {
            var ldc = rdc as LedgerSummaryDataContext;
            if (ldc == null)
                return;

            ldc.Account = _account;
            ldc.Daybook = _daybook;
            ldc.View = _currentView;

            if (_currentView == LedgerView.Monthly)
                ldc.Period = getSelectedPeriod().CompanyPeriod.Period;

            _report = ldc.GetReportData().Result as IList<LedgerSummary>;
        }

        private LedgerSummary getSelectedPeriod()
        {
            return lvwReport.SelectedItems[0].Tag as LedgerSummary;
        }

        private void renderReport()
        {
            buildReportViewColumns();

            if (_currentView == LedgerView.Monthly)
                addMonthlyOpeningRow();

            addReportViewRows();

            if (_currentView == LedgerView.Monthly)
                addMonthlyTotalsRow();
        }

        private void addMonthlyOpeningRow()
        {
            var lvi = new ListViewItem();
            lvi.Text = @"Opening:";
            lvi.ForeColor = Color.Maroon;

            if (_yearTotal.OpeningAmount > 0)
            {
                lvi.SubItems.Add(formatAmount(_yearTotal.OpeningAmount, cmbAmtFormat));
                lvi.SubItems.Add("");
            }
            else
            {
                lvi.SubItems.Add("");
                lvi.SubItems.Add(formatAmount(Math.Abs(_yearTotal.OpeningAmount), cmbAmtFormat));
            }

            lvi.SubItems.Add(formatAmount(_yearTotal.OpeningAmount, cmbAmtFormat, withDbCr: true));
            lvwReport.Items.Add(lvi);
        }

        private void addReportViewRows()
        {
            foreach (var ls in _report)
            {
                var lvi = new ListViewItem();
                lvi.UseItemStyleForSubItems = true;
                lvi.Font = new Font(lvi.Font, FontStyle.Regular);
                lvi.Tag = ls;
                lvi.Text = getViewTypeColumnValue(ls);

                if (_currentView == LedgerView.Yearly)
                    lvi.SubItems.Add(formatAmount(ls.OpeningAmount, cmbAmtFormat, withDbCr: true));

                lvi.SubItems.Add(formatAmount(ls.CreditAmount, cmbAmtFormat));
                lvi.SubItems.Add(formatAmount(ls.DebitAmount, cmbAmtFormat));
                lvi.SubItems.Add(formatAmount(ls.BalanceAmount, cmbAmtFormat, withDbCr: true));
                lvwReport.Items.Add(lvi);
            }
        }

        private void addMonthlyTotalsRow()
        {
            _yearTotal.Month = 13;
            var lvi = new ListViewItem();
            lvi.ForeColor = Color.Maroon;
            lvi.Tag = _yearTotal;
            lvi.Text = @"TOTAL:";
            lvi.SubItems.Add(formatAmount(_yearTotal.CreditAmount, cmbAmtFormat));
            lvi.SubItems.Add(formatAmount(_yearTotal.DebitAmount, cmbAmtFormat));
            lvi.SubItems.Add(formatAmount(_yearTotal.BalanceAmount, cmbAmtFormat, withDbCr: true));
            lvwReport.Items.Add(lvi);
        }

        private string getViewTypeColumnValue(LedgerSummary ls)
        {
            if (_currentView == LedgerView.Yearly)
                return ls.CompanyPeriod.Period.Entity.Financial.To.Year.ToString();

            return getMonthName(ls.Month);
        }

        private void showMonthlyLedger()
        {
            _yearTotal = getSelectedPeriod();
            _currentView = LedgerView.Monthly;
            setViewTypeColumnText();
            setLedgerPeriod();
            showReport();
        }

        private void setLedgerPeriod()
        {
            if (_currentView == LedgerView.Monthly)
            {
                lblYear.Visible = true;
                lblYearValue.Text = getSelectedPeriod().CompanyPeriod.Period.Entity.Financial.To.Year.ToString();
            }
            else
            {
                lblYear.Visible = false;
                lblYearValue.Text = "";
            }
        }

        private void showDetailLedger()
        {
            if (isOpeningRow())
                return;

            DetailControl.Summary = getSelectedPeriod();
            DetailControl.LoadData();
            Hide();
            Enabled = false;
            DetailControl.Enabled = true;
            DetailControl.Show();
            DetailControl.Focus();
        }

        private bool isOpeningRow()
        {
            return getSelectedPeriod() == null;
        }

        #endregion
    }
}
