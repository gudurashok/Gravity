using System;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Model;
using Gravity.Root.Events;
using Gravity.Root.Properties;
using Scalable.Shared.Common;
using Gravity.Root.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UCompanyGroups : UPicklist
    {
        #region Declarations

        public event EventHandler<CoGroupSelectedEventArgs> CoGroupSelected;
        public event EventHandler<OpenCoGroupEventArgs> OpenCoGroup;

        #endregion

        #region Constructor

        public UCompanyGroups()
        {
            InitializeComponent();
        }

        #endregion

        #region Loading

        public override void Initialize()
        {
            applySecurityRights();
            buildList();
            selectNewIfNoGroupsExist();
        }

        private void buildList()
        {
            buildColumns();
            hookEventHandlers();
            fillListData();
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            var col = new iColumnHeader("Name", true);
            ListView.Columns.Add(col);
        }

        private void hookEventHandlers()
        {
            ItemSelected += UCompanyGroups_ItemSelected;
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
        }

        private void fillListData()
        {
            var repo = new CoGroupRepository();
            ListData = repo.GetCoGroupListItems();
            selectCurrentCompanyGroup(GravitySession.CompanyGroup);
        }

        private void applySecurityRights()
        {
            var visible = (GravitySession.User.Entity.IsAdmin);

            btnNew.Visible = visible;
            btnEdit.Visible = visible;
            btnDelete.Visible = visible;
        }

        private void selectNewIfNoGroupsExist()
        {
            if (areAnyGroupsExist())
                ListView.Select();
            else
                btnNew.Select();
        }

        private bool areAnyGroupsExist()
        {
            return ListView.Items.Count > 0;
        }

        #endregion

        #region Editing

        private void btnNewOrEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddEditCompanyGroup, sender, e);
        }

        private void processAddEditCompanyGroup(object sender, EventArgs e)
        {
            initializeEntry(createObject(sender));
        }

        private CompanyGroup createObject(object sender)
        {
            return sender == btnNew ? CompanyGroup.New() : getSelectedCompanyGroup();
        }

        private void initializeEntry(CompanyGroup coGroup)
        {
            OnCoGroupSelected(new CoGroupSelectedEventArgs(coGroup));
            refreshList();
            selectCurrentCompanyGroup(coGroup);
        }

        protected virtual void OnCoGroupSelected(CoGroupSelectedEventArgs e)
        {
            if (CoGroupSelected != null)
                CoGroupSelected(this, e);
        }

        #endregion

        #region Delete

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDeleteCompanyGroup);
        }

        private void processDeleteCompanyGroup()
        {
            if (MessageBoxUtil.GetConfirmationYesNo(Resources.DeleteCompanyGroup) == DialogResult.No)
                return;

            //TODO: delete company group should delete folder and data/database entry etc for server...
            var repo = new CoGroupRepository();
            repo.DeleteGroup(getSelectedCompanyGroup(), true); //TODO: provide a separate confirmation to delete the DB
            refreshList();
        }

        #endregion

        #region Open

        void UCompanyGroups_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            EventHandlerExecutor.Execute(processOpenCompanyGroup, sender, e);
        }

        private void processOpenCompanyGroup(object sender, EventArgs e)
        {
            var args = e as PicklistItemEventArgs;
            var coGroup = getSelectedCompanyGroup(args.PicklistItem as CoGroupListItem);
            var isCoGroupChanged = isAnotherCoGroupSelected(coGroup);
            GravitySession.OpenCompanyGroup(coGroup);
            OnOpenCoGroup(new OpenCoGroupEventArgs(isCoGroupChanged));
        }

        private bool isAnotherCoGroupSelected(CompanyGroup coGroup)
        {
            return !coGroup.Equals(GravitySession.CompanyGroup);
        }

        protected virtual void OnOpenCoGroup(OpenCoGroupEventArgs e)
        {
            if (OpenCoGroup != null)
                OpenCoGroup(this, e);
        }

        #endregion

        #region Set Command Button States

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelectionChangedEvent);
        }

        private void processItemSelectionChangedEvent()
        {
            setCommandButtonStates();
        }

        private void setCommandButtonStates()
        {
            if (ListView.SelectedItems.Count == 1)
                enableCommandButtons();
            else
                disableCommandButtons();
        }

        private void enableCommandButtons()
        {
            btnOK.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void disableCommandButtons()
        {
            btnOK.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        #endregion

        #region Refresh Methods

        private void refreshList()
        {
            fillListData();
            setCommandButtonStates();
        }

        #endregion

        #region Common

        private void selectCurrentCompanyGroup(CompanyGroup coGroup)
        {
            selectCompanyGroupListItem(coGroup == null || string.IsNullOrWhiteSpace(coGroup.Entity.Name)
                                        ? null
                                        : ListView.FindItemWithText(coGroup.Entity.Name));
        }

        private void selectCompanyGroupListItem(ListViewItem lvi)
        {
            if (lvi == null)
                ListView.SelectTopItem(true);
            else
                ListView.SelectItem(lvi);
        }

        private CompanyGroup getSelectedCompanyGroup()
        {
            return getSelectedCompanyGroup(ListView.SelectedItems[0].Tag as CoGroupListItem);
        }

        private CompanyGroup getSelectedCompanyGroup(CoGroupListItem item)
        {
            var repo = new CoGroupRepository();
            return repo.GetById(item.Id, true);
        }

        #endregion
    }
}
