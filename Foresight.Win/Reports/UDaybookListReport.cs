using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Report;
using Gravity.Root.Model;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Foresight.Win.Reports
{
    public partial class UDaybookListReport : UReportBase
    {
        #region Declarations

        private IList<Daybook> _report;
        private ListViewItem _selectedAccountItem;
        private const int fudgeSize = 21;
        private bool _isAscending = true;

        #endregion

        #region Properties

        public IList<Daybook> SelectedDaybooks { get; set; }
        public bool MultiSelect { get; set; }

        #endregion

        #region Constructor

        public UDaybookListReport(Command command)
            : base(command)
        {
            InitializeComponent();
            SelectedDaybooks = new List<Daybook>();
            buildReportViewColumns();
        }

        #endregion

        #region Event Handlers

        private void UAccountListReport_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            lvwReport.Resize -= lvwReport_Resize;
            lvwReport.CheckBoxes = MultiSelect;
            btnClose.Visible = !(Parent is Form);
            showReport();
            btnShowLedger.Enabled = lvwReport.Items.Count > 0;
            lvwReport.Focus();
            lvwReport.Resize += lvwReport_Resize;
        }

        private void lvwReport_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(reportResize);
        }

        void reportResize()
        {
            if (lvwReport.Columns.Count > 0)
                autoResize();
        }

        private void lvwReport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            EventHandlerExecutor.Execute(sortListItems,sender,e);
        }

        void sortListItems(object sender, EventArgs e)
        {
            var args = e as ColumnClickEventArgs;

            lvwReport.ListViewItemSorter = new ListViewItemComparer(args.Column, sortDirection());
        }

        private void lvwReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(enableViewLedger);
        }

        void enableViewLedger()
        {
            btnShowLedger.Enabled = lvwReport.SelectedItems.Count > 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != Keys.Enter)
                return base.ProcessCmdKey(ref msg, keyData);

            EventHandlerExecutor.Execute(showLedger);

            return true;
        }

        private void lvwReport_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showLedger);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(Close);
        }

        private void btnShowLedger_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(selectedItemLedger);
        }

        void selectedItemLedger()
        {
            if (lvwReport.SelectedItems[0].Tag == null)
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

        private void showReport()
        {
            getReportData();
            renderReport();
        }

        private void getReportData()
        {
            var adc = rdc as AccountDataContext;
            if (adc == null)
                return;

            adc.OnlyDaybooks = true;
            _report = adc.GetReportData().Result as IList<Daybook>;
        }

        private void buildReportViewColumns()
        {
            lvwReport.Columns.Clear();
            lvwReport.Items.Clear();

            lvwReport.Columns.Clear();
            lvwReport.Columns.Add("Name", 280);
            autoResize();
        }

        private void autoResize()
        {
            lvwReport.Columns[0].Width = lvwReport.Width - fudgeSize;
        }

        private void renderReport()
        {
            lvwReport.Items.Clear();
            addReportViewRows();
        }

        private void addReportViewRows()
        {
            foreach (var daybook in _report)
                lvwReport.Items.Add(createListItem(daybook));

            lvwReport.SelectTopItem(true);
        }

        private ListViewItem createListItem(Daybook daybook)
        {
            var lvi = new ListViewItem();
            lvi.Font = new Font(lvwReport.Font, FontStyle.Regular);
            lvi.Tag = daybook;
            lvi.Text = daybook.Entity.Name;

            if (MultiSelect)
                lvi.Checked = shouldCheck(daybook);
            else if (_selectedAccountItem == null && shouldCheck(daybook))
                _selectedAccountItem = lvi;

            return lvi;
        }

        private bool shouldCheck(Daybook daybook)
        {
            return SelectedDaybooks.SingleOrDefault(g => g.Entity.Id == daybook.Entity.Id) != null;
        }

        private void showLedger()
        {
            var daybook = (lvwReport.SelectedItems[0].Tag as Daybook);

            if (daybook.Account == null)
                FReportViewer.ShowLedger(FindForm(), daybook);
            else
                FReportViewer.ShowLedger(FindForm(), daybook.Account);
        }

        #endregion
    }
}
