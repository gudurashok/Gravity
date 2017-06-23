using System;
using System.Windows.Forms;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UFiscalDatePeriods : UPicklist
    {
        public UFiscalDatePeriods()
        {
            InitializeComponent();
        }

        #region Initialization

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new FiscalDatePeriods();
            FillList(true);
            uFiscalDatePeriod.Initialize();
            uFiscalDatePeriod.ItemSaved += uFiscalDatePeriod_FiscalDatePeriodSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("FinancialYear", true));
            ListView.Columns.Add(new iColumnHeader("AssessmentYear", true));
        }

        private void setButtonStates()
        {
            var enable = ListView.HasAnyItemsSelected();
            btnOK.Enabled = enable;
            btnOpen.Enabled = enable;
            btnDelete.Enabled = enable;
            btnPreferred.Enabled = enable;
        }

        #endregion

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            if (uFiscalDatePeriod.Enabled)
                return;

            setButtonStates();
            uFiscalDatePeriod.DataSource = getSelectedFiscalDatePeriod();
        }

        private FiscalDatePeriod getSelectedFiscalDatePeriod()
        {
            return ListView.HasAnyItemsSelected() 
                        ? ((FiscalDatePeriodListItem)ListView.SelectedItems[0].Tag).FiscalDatePeriod 
                        : FiscalDatePeriod.New();
        }

        void uFiscalDatePeriod_FiscalDatePeriodSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewFiscalDatePeriod);
        }

        void processNewFiscalDatePeriod()
        {
            btnCancel.Enabled = true;
            uFiscalDatePeriod.Enabled = true;
            uFiscalDatePeriod.DataSource = FiscalDatePeriod.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditFiscalDatePeriod);
        }

        void processEditFiscalDatePeriod()
        {
            btnCancel.Enabled = true;
            uFiscalDatePeriod.Enabled = true;
            uFiscalDatePeriod.DataSource = getSelectedFiscalDatePeriod();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uFiscalDatePeriod.DataSource = getSelectedFiscalDatePeriod();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uFiscalDatePeriod.Enabled = false;
        }
    }
}
