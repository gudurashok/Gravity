using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using Scalable.Win.Controls;
using Scalable.Shared.Enums;

namespace Foresight.Win.Reports
{
    public partial class UGenuineSaleReport : UReportBase
    {
        #region Internal Declarations

        private IList<GenuineSale> _report;
        private const int rankColumnIndex = 0;
        private const int customerNameColumnIndex = 1;
        private const int saleAmountColumnIndex = 2;
        private const int receiptAmtColumnIndex = 3;
        private const int balanceAmtColumnIndex = 4;
        private const int genSalePctColumnIndex = 5;
        private const int fudgeSize = 21;
        private bool _isAscending = true;

        #endregion

        #region Constructor

        public UGenuineSaleReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UGenuineSaleReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(intialize);
        }

        void intialize()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processShow);
        }

        private void processShow()
        {
            lvwReport.Resize -= lvwReport_Resize;
            showReport();
            lvwReport.Resize += lvwReport_Resize;
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
            EventHandlerExecutor.Execute(showLedger);
        }

        private void lvwReport_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAutoResize);
        }

        void processAutoResize()
        {
            if (lvwReport.Columns.Count > 0)
                autoResize();
        }

        private void lvwReport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            EventHandlerExecutor.Execute(itemSorter, sender, e);
        }

        void itemSorter(object sender, EventArgs e)
        {
            var args = e as ColumnClickEventArgs;
            lvwReport.ListViewItemSorter = new ListViewItemComparer(args.Column, sortDirection());
        }

        private void lvwReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedAccountLedger, sender, e);
        }

        void processSelectedAccountLedger(object sender, EventArgs e)
        {
            var args = e as KeyPressEventArgs;
            if (args.KeyChar != (char)Keys.Enter)
                return;

            showLedger();
        }

        #endregion

        #region Private Methods

        private bool sortDirection()
        {
            _isAscending = !_isAscending;
            return _isAscending;
        }

        private void showLedger()
        {
            var genuineSale = lvwReport.SelectedItems[0].Tag as GenuineSale;
            if (genuineSale == null)
                return;
            var account = ForesightSession.Dbc.GetAccountById(genuineSale.AccountId);

            if (account == null)
                return;

            FReportViewer.ShowLedger(FindForm(), account);
        }

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                    (int)ReportsAmountFormat.Thousands);
        }

        private void showReport()
        {
            getReportData();
            renderReport();
        }

        private void getReportData()
        {
            var sdc = rdc as GenuineSaleDataContext;
            if (sdc == null)
                return;

            sdc.PartyGrouping = chkPartyGrouping.Checked;
            _report = sdc.GetReportData().Result as IList<GenuineSale>;
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Add(new iColumnHeader("Rank", DataType.Number, 50));
            lvwReport.Columns.Add(new iColumnHeader(getColumnName(), 90));
            lvwReport.Columns.Add(new iColumnHeader("Sale", DataType.Number, 90));
            lvwReport.Columns.Add(new iColumnHeader("Receipt", DataType.Number, 90));
            lvwReport.Columns.Add(new iColumnHeader("Balance", DataType.Number, 90));
            lvwReport.Columns.Add(new iColumnHeader("Genuine Sale %", DataType.Number, 70));
            autoResize();
        }

        private string getColumnName()
        {
            const string a = "Name";
            return chkPartyGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private void autoResize()
        {
            lvwReport.Columns[customerNameColumnIndex].Width =
                    lvwReport.Width -
                    (lvwReport.Columns[rankColumnIndex].Width +
                     lvwReport.Columns[saleAmountColumnIndex].Width +
                     lvwReport.Columns[receiptAmtColumnIndex].Width +
                     lvwReport.Columns[balanceAmtColumnIndex].Width +
                     lvwReport.Columns[genSalePctColumnIndex].Width +
                     fudgeSize);
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
        }

        private void addReportViewRows()
        {
            var rank = 1;
            foreach (var gsr in _report.OrderBy(r => r.GenuineSalePct))
            {
                var lvi = new ListViewItem(rank.ToString());
                lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
                lvi.Tag = gsr;
                lvi.SubItems.Add(gsr.Name);
                lvi.SubItems.Add(formatAmount(gsr.SaleAmount, cmbAmtFormat));
                lvi.SubItems.Add(formatAmount(gsr.ReceiptAmount, cmbAmtFormat));
                lvi.SubItems.Add(formatAmount(gsr.BalanceAmount, cmbAmtFormat, true));
                lvi.SubItems.Add(gsr.GenuineSalePct.ToString(CommonUtil.AmountFormat));
                lvwReport.Items.Add(lvi);
                rank++;
            }
        }

        #endregion

    }
}
