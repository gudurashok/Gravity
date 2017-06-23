using System;
using System.Windows.Forms;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UChartOfAccounts : UPicklist
    {
        private readonly ChartOfAccountType _type;

        public UChartOfAccounts(ChartOfAccountType type = ChartOfAccountType.None)
        {
            InitializeComponent();
            _type = type;
        }

        #region Initialization

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new ChartOfAccounts(_type);
            FillList(true);
            uChartOfAccount.Initialize();
            uChartOfAccount.ItemSaved += uChartOfAccount_ChartOfAccountSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Type", 90));
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
            if (uChartOfAccount.Enabled)
                return;

            setButtonStates();
            uChartOfAccount.DataSource = getSelectedChartOfAccount();
        }

        private ChartOfAccount getSelectedChartOfAccount()
        {
            return ListView.HasAnyItemsSelected() 
                        ? ((ChartOfAccountListItem)ListView.SelectedItems[0].Tag).ChartOfAccount 
                        : ChartOfAccount.New();
        }

        void uChartOfAccount_ChartOfAccountSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewChartOfAccount);
        }

        void processNewChartOfAccount()
        {
            btnCancel.Enabled = true;
            uChartOfAccount.Enabled = true;
            uChartOfAccount.DataSource = ChartOfAccount.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEdituChartOfAccount);
        }

        void processEdituChartOfAccount()
        {
            btnCancel.Enabled = true;
            uChartOfAccount.Enabled = true;
            uChartOfAccount.DataSource = getSelectedChartOfAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uChartOfAccount.DataSource = getSelectedChartOfAccount();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uChartOfAccount.Enabled = false;
        }
    }
}
