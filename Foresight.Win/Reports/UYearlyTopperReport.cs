using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class UYearlyTopperReport : UReportBase
    {
        #region Declarations

        private const int periodColumnIndex = 0;
        private const int accountNameColumnIndex = 1;
        private const int totalAmountColumnIndex = 2;
        private const int pctColumnIndex = 3;
        private const int fudgeSize = 21;
        private IList<CompanyPeriodTopperValue> _report;

        #endregion

        #region Constructor

        public UYearlyTopperReport(Command command)
            : base(command)
        {
            InitializeComponent();
            buildReportViewColumns();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UYearlyTopperReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        void initialize()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        private void btnSelectCompany_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedCompanyPeriods);
        }

        void processSelectedCompanyPeriods()
        {
            lvwReport.Resize -= lvwReport_Resize;
            if (!selectCompanyPeriods(CompanyPeriodType.Both))
                return;

            showReport();
            lvwReport.Resize += lvwReport_Resize;
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

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyPeriod);
        }

        void processCompanyPeriod()
        {
            lvwReport.Resize -= lvwReport_Resize;
            SelectedCoPeriods = new List<CompanyPeriod>();
            showReport();
            lvwReport.Resize += lvwReport_Resize;
        }

        private void cmbAmtFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(changaAmountFormat);
        }

        void changaAmountFormat()
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
            getReportData();
            renderReport();
        }

        private void getReportData()
        {
            var adc = rdc as CompanyTopperBaseDataContext;
            if (adc == null)
                return;

            adc.TopNCount = Convert.ToInt32(nudTopNCount.Value);
            adc.SelectedCoPeriods = SelectedCoPeriods;
            _report = rdc.GetReportData().Result as IList<CompanyPeriodTopperValue>;

        }

        private void buildReportViewColumns()
        {
            clearList();
            lvwReport.Columns.Add("Year", 55);
            lvwReport.Columns.Add("Name", 150);
            lvwReport.Columns.Add("Total Amount", 100, HorizontalAlignment.Right);
            lvwReport.Columns.Add("Total %", 70, HorizontalAlignment.Right);

            autoResize();
        }

        private void clearList()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();
        }

        private void autoResize()
        {
            lvwReport.Columns[accountNameColumnIndex].Width =
                    lvwReport.Width -
                    (lvwReport.Columns[periodColumnIndex].Width +
                     lvwReport.Columns[totalAmountColumnIndex].Width +
                     lvwReport.Columns[pctColumnIndex].Width +
                     fudgeSize);
        }

        private void renderReport()
        {
            lvwReport.Items.Clear();
            addReportViewRows();
        }

        private void addReportViewRows()
        {
            foreach (var v in _report)
            {
                var lvi = new ListViewItem(v.CompanyPeriod.Period.Entity.Financial.To.Year.ToString());
                lvi.SubItems.Add(v.Account.Name);
                var value = v.Account.Amount ?? 0;
                lvi.SubItems.Add(formatAmount(value, cmbAmtFormat));
                lvi.SubItems.Add(v.Account.Percentage.ToString("0.00"));
                lvwReport.Items.Add(lvi);
            }
        }

        #endregion
    }
}
