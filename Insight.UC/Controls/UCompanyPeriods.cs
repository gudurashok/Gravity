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
    public partial class UCompanyPeriods : UPicklist
    {
        public UCompanyPeriods()
        {
            InitializeComponent();
        }

        #region Initialization

        public override void Initialize()
        {
            SearchProperty = "Company";
            buildColumns();
            Repository = new CompanyPeriods();
            FillList(true);
            uCompanyPeriod.Initialize();
            uCompanyPeriod.ItemSaved += uCompanyPeriod_CompanyPeriodSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Company", true));
            ListView.Columns.Add(new iColumnHeader("Period", 100));
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
            if (uCompanyPeriod.Enabled)
                return;

            setButtonStates();
            uCompanyPeriod.DataSource = getSelectedCompanyPeriod();
        }

        private CompanyPeriod getSelectedCompanyPeriod()
        {
            return ListView.HasAnyItemsSelected()
                       ? ((CompanyPeriodListItem)ListView.SelectedItems[0].Tag).CompanyPeriod
                       : CompanyPeriod.New();
        }

        void uCompanyPeriod_CompanyPeriodSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewCompany);
        }

        void processNewCompany()
        {
            btnCancel.Enabled = true;
            uCompanyPeriod.Enabled = true;
            uCompanyPeriod.DataSource = CompanyPeriod.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditCompany);
        }

        void processEditCompany()
        {
            btnCancel.Enabled = true;
            uCompanyPeriod.Enabled = true;
            uCompanyPeriod.DataSource = getSelectedCompanyPeriod();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uCompanyPeriod.DataSource = getSelectedCompanyPeriod();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uCompanyPeriod.Enabled = false;
        }
    }
}
