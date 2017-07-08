using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
    public partial class UPartyCountReport : UReportBase
    {
        #region Internal Declarations

        private IList<NewLostPartyCount> _report;

        #endregion

        #region Constructor

        public UPartyCountReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UPartyCountReport_Load(object sender, EventArgs e)
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
            EventHandlerExecutor.Execute(selectCompanyPeriods);
        }

        void selectCompanyPeriods()
        {
            if (!selectCompanyPeriods(CompanyPeriodType.Both))
                return;

            showReport();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showReport);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
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
            var adc = rdc as PartyCountBaseDataContext;
            if (adc == null)
                return;

            adc.PartyGrouping = chkPartyGrouping.Checked;
            adc.SelectedCoPeriods = SelectedCoPeriods;
            _report = rdc.GetReportData().Result as IList<NewLostPartyCount>;
        }

        private void buildReportViewColumns()
        {
            clearList();
            lvwReport.Columns.Add(new iColumnHeader("Year", 60));
            lvwReport.Columns.Add(new iColumnHeader("Total Amount", DataType.Number, 120));
            lvwReport.Columns.Add(new iColumnHeader(getColumnName(), DataType.Number, 220));
        }

        private string getColumnName()
        {
            const string a = "No. of Customers";
            return chkPartyGrouping.Checked ? a + " (Groupwise)" : a;
        }

        private void clearList()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
            addTotalsRow();
        }

        private void addReportViewRows()
        {
            foreach (var p in _report.OrderByDescending(r => r.CompanyPeriod.Period.Entity.Financial.To.Year))
            {
                var lvi = new ListViewItem(p.CompanyPeriod.Period.Entity.Financial.To.Year.ToString());
                lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
                lvi.SubItems.Add(formatAmount(p.Amount, cmbAmtFormat));
                lvi.SubItems.Add(p.Count.ToString());
                lvwReport.Items.Add(lvi);
            }
        }

        private void addTotalsRow()
        {
            var lvi = new ListViewItem("TOTAL:");
            lvi.UseItemStyleForSubItems = true;
            lvi.ForeColor = Color.Maroon;
            lvi.SubItems.Add(formatAmount(_report.Sum(r => r.Amount), cmbAmtFormat));
            lvi.SubItems.Add(_report.Sum(r => r.Count).ToString());
            lvwReport.Items.Add(lvi);
        }

        #endregion
    }
}
