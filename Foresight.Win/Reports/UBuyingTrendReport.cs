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
    public partial class UBuyingTrendReport : UReportBase
    {
        #region Internal Declarations

        private const int yearColumnIndex = 0;
        private IList<BuyingTrendValue> _report;
        private IList<string> _selectedAccountIds;
        private bool _partyGrouping;

        #endregion

        #region Constructor

        public UBuyingTrendReport(Command command)
            : base(command)
        {
            InitializeComponent();
            loadAmountFormatList();
            _selectedAccountIds = new List<string>();
            displaySelectedParty();
        }

        #endregion

        #region Constructor Helper methods

        private void loadAmountFormatList()
        {
            EnumUtil.LoadEnumListItems(cmbAmtFormat, typeof(ReportsAmountFormat),
                                    (int)AmountFormat);
        }

        private void displaySelectedParty()
        {
            if (_selectedAccountIds.Count == 0)
                txtParty.Text = @"(All)";
            else if (_selectedAccountIds.Count > 1)
                txtParty.Text = @"(Multiple)";
            else
            {
                var account = ForesightSession.Dbc.GetAccountById(_selectedAccountIds[0]);
                txtParty.Text = string.Format("{0}, {1}", account.Entity.Name, account.ToStringAddress());
            }
        }

        #endregion

        #region Load Report

        private void UBuyingTrendReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processLoad);
        }

        private void processLoad()
        {
            btnShow.Focus();
            btnShow.PerformClick();
        }

        #endregion

        #region Show button clicked

        private void btnShow_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showReport);
        }

        #endregion

        #region party button checked

        private void btnParty_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processPartyGrouping);
        }

        private void processPartyGrouping()
        {
            if (!selectAccountGroups())
                return;

            showReport();
        }

        private bool selectAccountGroups()
        {
            var accountsForm = new FAccounts(_selectedAccountIds, true, AccountTypes.Customers, true);

            var result = accountsForm.ShowDialog();

            if (result == DialogResult.Cancel)
                return false;

            _selectedAccountIds = accountsForm.GetSelectedAccountIds();
            _partyGrouping = accountsForm.IsPartyGroupingSelected;
            displaySelectedParty();
            SelectedCoPeriods = new List<CompanyPeriod>();
            return true;
        }

        #endregion

        #region Company button Click

        private void btnCompany_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyPeriods);
        }

        void processCompanyPeriods()
        {
            if (!selectCompanyPeriods(CompanyPeriodType.Both))
                return;

            showReport();
        }

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

        #region Report Close

        private void btnClose_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(CloseReport);
        }

        private void CloseReport()
        {
            Close();
        }

        #endregion

        #region Show Report

        private void showReport()
        {
            Cursor = Cursors.WaitCursor;
            getReportData();
            renderReport();
        }

        private void getReportData()
        {
            var bdc = rdc as BuyingTrendDataContext;
            rdc.PartyGrouping = _partyGrouping;
            if (bdc == null)
                return;

            bdc.SelectedCoPeriods = SelectedCoPeriods;
            bdc.SelectedAccountIds = _selectedAccountIds;
            _report = rdc.GetReportData().Result as IList<BuyingTrendValue>;
        }

        private void renderReport()
        {
            buildReportViewColumns();
            addReportViewRows();
            addMonthTotalsRow();
            formatYearColumn();
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Add("Year", 70);
            buildMonthColumns();
            buildYearTotalColumn();
        }

        private void buildYearTotalColumn()
        {
            var yearTotal = lvwReport.Columns.Add("TOTAL", 100);
            yearTotal.Tag = 13;
            yearTotal.TextAlign = HorizontalAlignment.Right;
        }

        private void buildMonthColumns()
        {
            foreach (var month in getReorderedDistinctMonths())
                addMonthColumn(month);
        }

        private void addReportViewRows()
        {
            foreach (var periodId in (_report.Select(r => r.Period.Entity.Id).Distinct()))
            {
                IList<BuyingTrendValue> monthValues = getMonthValuesOf(periodId);
                var lvi = new ListViewItem(monthValues[0].Period.Entity.Financial.To.Year.ToString());
                lvi.UseItemStyleForSubItems = false;

                for (var i = 1; i < lvwReport.Columns.Count - 1; i++)
                    addSubItem(lvi, getBuyingTrendValue(monthValues, periodId, getMonthNumber(i)));

                addSubItem(lvi, getYearTotal(periodId));
                lvwReport.Items.Add(lvi);
            }
        }

        private List<BuyingTrendValue> getMonthValuesOf(string periodId)
        {
            return (from r in _report
                    where r.Period.Entity.Id == periodId
                    orderby r.Month
                    select r).ToList();
        }

        private BuyingTrendValue getBuyingTrendValue(IEnumerable<BuyingTrendValue> monthValues,
                                                    string periodId, int month)
        {
            var value = monthValues.SingleOrDefault(r => r.Period.Entity.Id == periodId &&
                                                        r.Month == month);
            if (value == null)
                return new BuyingTrendValue();

            return value;
        }

        private void addMonthTotalsRow()
        {
            var lvi = new ListViewItem("TOTAL:");

            foreach (var month in getReorderedDistinctMonths())
                addSubItem(lvi, getMonthTotal(calculateMonth(month)));

            addSubItem(lvi, getGrandTotal());
            lvwReport.Items.Add(lvi);
        }

        private void formatYearColumn()
        {
            var yearTotalColumnIndex = lvwReport.Columns.Count - 1;
            var monthTotalColumnIndex = lvwReport.Items.Count - 1;

            foreach (ListViewItem item in lvwReport.Items)
            {
                item.SubItems[yearColumnIndex].ForeColor = Color.Blue;
                item.SubItems[yearTotalColumnIndex].ForeColor = Color.Brown;
                item.SubItems[yearTotalColumnIndex].Font = lvwReport.Font;
            }

            lvwReport.Items[monthTotalColumnIndex].SubItems[0].ForeColor = Color.Brown;
        }

        private void addMonthColumn(int month)
        {
            var year = lvwReport.Columns.Add(getMonthName(calculateMonth(month)), 80);
            year.Tag = calculateMonth(month);
            year.TextAlign = HorizontalAlignment.Right;
        }

        private int calculateMonth(int month)
        {
            if (month > 12)
                month = month % 12;

            return month;
        }

        private IEnumerable<int> getReorderedDistinctMonths()
        {
            var months = (from r in _report
                          orderby r.Month
                          select r.Month).Distinct().ToArray();

            for (var i = 0; i <= months.Length - 1; i++)
                if (months[i] < 4) months[i] += 12;

            return months.OrderBy(i => i).ToArray();
        }

        private int getMonthNumber(int i)
        {
            var ch = lvwReport.Columns[i];
            var month = Convert.ToInt32(ch.Tag);
            return month;
        }

        private void addSubItem(ListViewItem lvi, BuyingTrendValue btv)
        {
            var lvs = lvi.SubItems.Add(getMonthValue(btv));
            formatSubItem(lvs);
            setColorOfNonAvailable(btv, lvs);
        }

        private string getMonthValue(BuyingTrendValue btv)
        {
            if (isNotAvailable(btv))
                return "<N.A>";

            return formatAmount(btv.Amount, cmbAmtFormat);
        }

        private void setColorOfNonAvailable(BuyingTrendValue btv, ListViewItem.ListViewSubItem lvs)
        {
            if (isNotAvailable(btv))
                lvs.ForeColor = Color.DarkGray;
        }

        private bool isNotAvailable(BuyingTrendValue btv)
        {
            return (btv.Month == 0);
        }

        private void formatSubItem(ListViewItem.ListViewSubItem listViewSubItem)
        {
            listViewSubItem.Font = new Font(lvwReport.Font, FontStyle.Regular);
        }

        private BuyingTrendValue getGrandTotal()
        {
            return new BuyingTrendValue { Month = 13, Amount = _report.Sum(r => r.Amount) };
        }

        private BuyingTrendValue getYearTotal(string periodId)
        {
            var total = (from r in _report
                         where r.Period.Entity.Id == periodId
                         select r.Amount).Sum();

            return new BuyingTrendValue { Period = new FiscalDatePeriod(new FiscalDatePeriodEntity { Id = periodId }), Month = 13, Amount = total };
        }

        private BuyingTrendValue getMonthTotal(int month)
        {
            var total = (from r in _report
                         where r.Month == month
                         select r.Amount).Sum();

            return new BuyingTrendValue { Month = month, Amount = total };
        }
        #endregion
    }
}
