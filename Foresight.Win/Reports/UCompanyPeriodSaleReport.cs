using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class UCompanyPeriodSaleReport : UReportBase
    {
        #region Declarations

        private IList<CompanyPeriodValue> _report;

        #endregion

        #region Constructor

        public UCompanyPeriodSaleReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
        }

        #endregion

        #region Event Handlers

        private void UCompanyPeriodSaleReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initializeLoad);
        }

        void initializeLoad()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        private void btnSelectCompany_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(selectCompanyPeriod);
        }

        void selectCompanyPeriod()
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

        #region Private methods

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                    (int)ReportsAmountFormat.Lacs);
        }

        private void showReport()
        {
            getReportData(SelectedCoPeriods);
            renderReport();
        }

        private void renderReport()
        {
            buildReportViewColumns(_report);
            addReportViewRows(_report);
            formatReportView();
        }

        private void getReportData(IList<CompanyPeriod> selectedCoPeriods)
        {
            var cdc = rdc as CompanyPeriodSaleDataContext;
            if (cdc != null)
                cdc.SelectedCoPeriods = selectedCoPeriods;
            _report = rdc.GetReportData().Result as IList<CompanyPeriodValue>;
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

            if (lvwReport.Items.Count > 0)
                lvwReport.Items[lvwReport.Items.Count - 1].SubItems[0].ForeColor = Color.Brown;
        }

        private void buildReportViewColumns(IList<CompanyPeriodValue> report)
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Add("Company", 100);

            var periodIds = getDistinctPeriods(report);
            var count = periodIds.Count();

            foreach (var period in periodIds.Select(periodId => getPeriodOf(report, periodId)))
            {
                addYearListColumn(period);

                if (count != 1)
                    addDiffPctListColumn();

                count--;
            }
        }

        private void formatTotalRow()
        {
            if (lvwReport.Items.Count == 0)
                return;

            var lvi = lvwReport.Items[lvwReport.Items.Count - 1];
            foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                lvs.Font = new Font(Font, FontStyle.Bold);
        }

        private void addYearListColumn(CompanyPeriodValue cpv)
        {
            var year = lvwReport.Columns.Add(cpv.CompanyPeriod.Period.Entity.Financial.To.Year.ToString(), 80);
            year.Tag = cpv.CompanyPeriod.Period.Entity.Id;
            year.TextAlign = HorizontalAlignment.Right;
        }

        private void addDiffPctListColumn()
        {
            var diffPct = lvwReport.Columns.Add("Diff %", 75);
            diffPct.TextAlign = HorizontalAlignment.Right;
        }

        private IEnumerable<string> getDistinctPeriods(IEnumerable<CompanyPeriodValue> report)
        {
            return (from r in report
                    orderby r.CompanyPeriod.Period.Entity.Id descending
                    select r.CompanyPeriod.Period.Entity.Id).Distinct();
        }

        private CompanyPeriodValue getPeriodOf(IEnumerable<CompanyPeriodValue> report, string periodId)
        {
            return (from r in report
                    where r.CompanyPeriod.Period.Entity.Id == periodId
                    select r).ToList()[0];
        }

        private void addReportViewRows(IList<CompanyPeriodValue> report)
        {
            foreach (var companyId in (report.Select(r => r.CompanyPeriod.Company.Entity.Id).Distinct()))
            {
                var companies = getCompaniesOf(report, companyId);
                var lvi = new ListViewItem(companies[0].CompanyPeriod.Company.Entity.Name);
                lvi.UseItemStyleForSubItems = false;

                for (var i = 1; i < lvwReport.Columns.Count; i = i + 2)
                    addSubItem(lvi, getCompanyOfPeriod(companies, getColumnPeriodId(i)));

                lvwReport.Items.Add(lvi);
            }
        }

        private string getColumnPeriodId(int i)
        {
            return lvwReport.Columns[i].Tag.ToString();
        }

        private CompanyPeriodValue getCompanyOfPeriod(IList<CompanyPeriodValue> companies, string periodId)
        {
            var cpv = companies.SingleOrDefault(co => co.CompanyPeriod.Period.Entity.Id == periodId);
            if (cpv == null)
                return getCompanyPeriodValue(companies[0].CompanyPeriod.Company.Entity.Id, periodId);

            return cpv;
        }

        private CompanyPeriodValue getCompanyPeriodValue(string companyId, string periodId)
        {
            var cp = ForesightSession.Dbc.GetCompanyPeriodByCompanyAndPeriodId(companyId, periodId) ?? CompanyPeriod.New();
            var cdc = rdc as CompanyPeriodSaleDataContext;
            if (cdc == null)
                return null;

            var value = cdc.GetCompanyPeriodValue(cp);
            return new CompanyPeriodValue { Value = value };
        }

        private void addSubItem(ListViewItem lvi, CompanyPeriodValue cpv)
        {
            var lvs = lvi.SubItems.Add(getPeriodValue(cpv));
            formatSubItem(lvs);
            setColorOfNonSelected(cpv, lvs);
            addDiffPctSubItem(cpv, lvi);
        }

        private string getPeriodValue(CompanyPeriodValue cpv)
        {
            var value = cpv.Value ?? 0;

            if (isNotSelected(cpv))
                if (cpv.Value == null)
                    return "<N.A>";
                else
                    return string.Format("<{0}>", formatAmount(value, cmbAmtFormat));

            return formatAmount(value, cmbAmtFormat);
        }

        private void setColorOfNonSelected(CompanyPeriodValue cpv, ListViewItem.ListViewSubItem lvs)
        {
            if (isNotSelected(cpv))
                lvs.ForeColor = Color.DarkGray;
        }

        private bool isNotSelected(CompanyPeriodValue cpv)
        {
            return (cpv.CompanyPeriod == null);
        }

        private void formatSubItem(ListViewItem.ListViewSubItem listViewSubItem)
        {
            listViewSubItem.Font = new Font(lvwReport.Font, FontStyle.Regular);
        }

        private void addDiffPctSubItem(CompanyPeriodValue company, ListViewItem lvi)
        {
            var pct = company.DifferencePct;
            var lvs = lvi.SubItems.Add((pct ?? 0).ToString("0.00"));
            lvs.ForeColor = getDifferencePctColor(company.DifferencePct);
            lvs.Font = new Font(lvwReport.Font, FontStyle.Regular);
        }

        private IList<CompanyPeriodValue> getCompaniesOf(IEnumerable<CompanyPeriodValue> report, 
                                                            string companyId)
        {
            return (from r in report
                    where r.CompanyPeriod.Company.Entity.Id == companyId
                    orderby r.CompanyPeriod.Period.Entity.Id descending
                    select r).ToList();
        }

        private Color getDifferencePctColor(decimal? value)
        {
            if (value < 0)
                return Color.Red;
            if (value > 0)
                return Color.DarkGreen;

            return Color.Black;
        }

        #endregion
    }
}
