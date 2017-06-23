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
    public partial class UCompanies : UPicklist
    {
        public UCompanies()
        {
            InitializeComponent();
        }

        #region Initialization

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new Companies();
            FillList(true);
            uCompany.Initialize();
            uCompany.ItemSaved += uCompany_CompanySaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Party", 100));
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
            if (uCompany.Enabled)
                return;

            setButtonStates();
            uCompany.DataSource = getSelectedCompany();
        }

        private Company getSelectedCompany()
        {
            return ListView.HasAnyItemsSelected()
                        ? ((CompanyListItem)ListView.SelectedItems[0].Tag).Company
                        : Company.New();
        }

        void uCompany_CompanySaved(object sender, EventArgs e)
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
            uCompany.Enabled = true;
            uCompany.DataSource = Company.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditCompany);
        }

        void processEditCompany()
        {
            btnCancel.Enabled = true;
            uCompany.Enabled = true;
            uCompany.DataSource = getSelectedCompany();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uCompany.DataSource = getSelectedCompany();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uCompany.Enabled = false;
        }
    }
}
