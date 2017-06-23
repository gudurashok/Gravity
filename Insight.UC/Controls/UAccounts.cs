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
    public partial class UAccounts : UPicklist
    {
        public UAccounts()
        {
            InitializeComponent();
        }

        #region Initialization

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new Accounts();
            FillList(true);
            uAccount.Initialize();
            uAccount.ItemSaved += uAccount_AccountSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("ChartOfAccount", 120));
        }

        #endregion

        private void setButtonStates()
        {
            var enable = ListView.HasAnyItemsSelected();
            btnOK.Enabled = enable;
            btnOpen.Enabled = enable;
            btnDelete.Enabled = enable;
            btnPreferred.Enabled = enable;
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            if (uAccount.Enabled)
                return;

            setButtonStates();
            uAccount.DataSource = getSelectedAccount();
        }

        private Account getSelectedAccount()
        {
            return ListView.HasAnyItemsSelected() 
                        ? ((AccountListItem)ListView.SelectedItems[0].Tag).Account 
                        : Account.New();
        }

        void uAccount_AccountSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewAccount);
        }

        void processNewAccount()
        {
            btnCancel.Enabled = true;
            uAccount.Enabled = true;
            uAccount.DataSource = Account.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditAccount);
        }

        void processEditAccount()
        {
            btnCancel.Enabled = true;
            uAccount.Enabled = true;
            uAccount.DataSource = getSelectedAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uAccount.DataSource = getSelectedAccount();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uAccount.Enabled = false;
        }
    }
}
