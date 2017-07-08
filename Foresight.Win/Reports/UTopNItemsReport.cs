using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Shared.Enums;

namespace Foresight.Win.Reports
{
    public partial class UTopNItemsReport : UReportBase
    {
        #region Declarations

        private IList<ItemValue> _report;
        private const int rankColumnIndex = 0;
        private const int itemNameColumnIndex = 1;
        private const int totalAmountColumnIndex = 2;
        private const int pctColumnIndex = 3;
        private const int fudgeSize = 21;

        #endregion

        #region Constructor

        public UTopNItemsReport(Command command)
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
            EventHandlerExecutor.Execute(processShow);
        }

        void processShow()
        {
            lvwReport.Resize -= lvwReport_Resize;
            SelectedCoPeriods = new List<CompanyPeriod>();
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

        private void lvwReport_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAutoResize);
        }

        private void processAutoResize()
        {
            if (lvwReport.Columns.Count > 0)
                autoResize();
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
            var idc = rdc as TopNItemsBaseDataContext;
            if (idc == null)
                return;

            idc.ItemGrouping = chkItemGrouping.Checked;
            idc.TopNCount = Convert.ToInt32(nudTopNCount.Value);
            idc.SelectedCoPeriods = selectedCoPeriods;
            _report = rdc.GetReportData().Result as IList<ItemValue>;
        }

        private void buildReportViewColumns()
        {
            clearList();
            lvwReport.Columns.Add(new iColumnHeader("Rank", DataType.Number, 45));
            lvwReport.Columns.Add(new iColumnHeader(getColumnName(), 150));
            lvwReport.Columns.Add(new iColumnHeader("Total Amount", DataType.Number, 100));
            lvwReport.Columns.Add(new iColumnHeader("Total %", DataType.Number, 70));

            autoResize();
        }

        private void clearList()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();
        }

        private string getColumnName()
        {
            const string a = "Items";
            return chkItemGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private void autoResize()
        {
            lvwReport.Columns[itemNameColumnIndex].Width =
                    lvwReport.Width -
                    (lvwReport.Columns[rankColumnIndex].Width +
                     lvwReport.Columns[totalAmountColumnIndex].Width +
                     lvwReport.Columns[pctColumnIndex].Width +
                     fudgeSize);
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
            addTotalsRow();
        }

        private void addReportViewRows()
        {
            var rank = 1;
            foreach (var iv in _report)
            {
                var lvi = new ListViewItem(rank.ToString());
                lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
                lvi.Tag = iv;
                lvi.SubItems.Add(iv.Name);
                lvi.SubItems.Add(formatAmount(iv.Amount, cmbAmtFormat));
                lvi.SubItems.Add(iv.Percentage.ToString("0.00"));
                lvwReport.Items.Add(lvi);
                rank++;
            }
        }

        private void addTotalsRow()
        {
            var lvi = new ListViewItem("");
            lvi.UseItemStyleForSubItems = true;
            lvi.ForeColor = Color.Maroon;
            lvi.SubItems.Add("TOTAL:");
            lvi.SubItems.Add(formatAmount(_report.Sum(r => r.Amount), cmbAmtFormat));
            lvi.SubItems.Add(_report.Sum(r => r.Percentage).ToString("0.00"));
            lvwReport.Items.Add(lvi);
        }

        #endregion
    }
}
