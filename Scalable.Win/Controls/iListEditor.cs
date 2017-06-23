using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;

namespace Scalable.Win.Controls
{
    public partial class iListEditor : UBaseForm
    {
        #region Declarations

        public event EventHandler<ListItemEventArgs> ItemAdded;
        public event EventHandler<ListItemEventArgs> ItemUpdated;
        public event EventHandler<ListItemEventArgs> ItemDeleted;
        public event EventHandler<ListItemEventArgs> ItemPreferred;
        public event EventHandler<ListItemEventArgs> ItemSelected;

        #endregion

        #region Constructor

        public iListEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Load

        public virtual void Initiliaze()
        {
            buildColoumns();
        }

        private void buildColoumns()
        {
            lvwItems.Columns.Add(new iColumnHeader("Name", true));
        }

        #endregion

        #region Item selection changed

        private void lvwItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedtem, sender, e);
        }

        void processSelectedtem(object sender, EventArgs e)
        {
            setCommandButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            var item = (IListItem)args.Item.Tag;
            OnItemSelected(new ListItemEventArgs(item));
            if (!args.IsSelected)
                return;

            txtName.Text = item.Name;
            chkIsActive.Checked = item.IsActive;
        }

        protected virtual void OnItemSelected(ListItemEventArgs e)
        {
            if (ItemSelected != null)
                ItemSelected(this, e);
        }

        #endregion

        #region Refresh List

        public virtual void RefreshList()
        {
            //TODO abstract...
        }

        protected virtual void refreshList(IEnumerable<IListItem> list)
        {
            //TODO: use self fill and make preferred bold or make FillData to render make preferred bold
            lvwItems.FillData(list);
            setCommandButtonStates();
        }

        private void setCommandButtonStates()
        {
            btnDelete.Enabled = lvwItems.HasAnyItemsSelected();
            btnPreferred.Enabled = lvwItems.HasAnyItemsSelected();
            btnUpdate.Enabled = lvwItems.HasAnyItemsSelected();
            btnDescription.Enabled = lvwItems.HasAnyItemsSelected();
            txtName.Text = lvwItems.HasItems() ? txtName.Text : string.Empty;
        }

        #endregion

        #region Add Item

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAdd);
        }

        private void processAdd()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                return;

            OnItemAdded(new ListItemEventArgs(createListItem()));
            lvwItems.SelectLastItem(true);
        }

        private IListItem createListItem()
        {
            return new ListItem
            {
                Name = txtName.Text,
                IsActive = chkIsActive.Checked
            };
        }

        protected virtual void OnItemAdded(ListItemEventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded(this, e);
        }

        #endregion

        #region Update Item

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processUpdate);
        }

        private void processUpdate()
        {
            if (!lvwItems.HasItems()) return;
            var item = (IListItem)lvwItems.SelectedItems[0].Tag;
            item.Name = txtName.Text;
            item.IsActive = chkIsActive.Checked;
            OnItemUpdated(new ListItemEventArgs(item));
        }

        protected virtual void OnItemUpdated(ListItemEventArgs e)
        {
            if (ItemUpdated != null)
                ItemUpdated(this, e);
        }

        #endregion

        #region Delete Item

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDelete);
        }

        private void processDelete()
        {
            var item = (IListItem)lvwItems.SelectedItems[0].Tag;
            OnItemDeleted(new ListItemEventArgs(item));
        }

        protected virtual void OnItemDeleted(ListItemEventArgs e)
        {
            if (ItemDeleted != null)
                ItemDeleted(this, e);
        }

        #endregion

        #region Preferred

        private void btnPreferred_Click_1(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processPreferred);
        }

        void processPreferred()
        {
            var item = (IListItem)lvwItems.SelectedItems[0].Tag;
            item.IsPreferred = true;
            OnItemPreferred(new ListItemEventArgs(item));
        }

        protected virtual void OnItemPreferred(ListItemEventArgs e)
        {
            if (ItemPreferred != null)
                ItemPreferred(this, e);
        }

        #endregion

        #region Description

        private void btnDescription_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDescription);
        }

        void processDescription()
        {
            var item = (IListItem)lvwItems.SelectedItems[0].Tag;
            var args = notesFormArgs(item);
            var notesForm = new FNotes(args);
            if (notesForm.ShowDialog() != DialogResult.OK)
                return;

            item.Description = args.Notes;
            OnItemUpdated(new ListItemEventArgs(item));
        }

        private NotesFormArgs notesFormArgs(IListItem item)
        {
            var args = new NotesFormArgs();
            args.Caption = string.Format("Task Type: {0}", item.Name);
            args.Title = string.Format("Enter Description for Task Type {0}", item.Name);
            args.Notes = item.Description;
            return args;
        }

        #endregion
    }
}
