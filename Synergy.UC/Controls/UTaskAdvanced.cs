using System;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Controls
{
    public partial class UTaskAdvanced : UFormBase
    {
        #region Declarations

        public event EventHandler TaskSaved;
        private Task _task;
        private readonly Checklist _checklist = Checklist.New();

        #endregion

        #region Constructor

        public UTaskAdvanced()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize

        public void Initialize()
        {
            loadDropDownLists();
            setupChecklist();
        }

        private void loadDropDownLists()
        {
            var repo = new TaskRepository();
            cmbChecklist.Databind("Id", "Name", repo.GetAllChecklists(), c => c.IsActive, -1);
            cmbLocation.Databind("Id", "Name", repo.GetAllLocations(), l => l.IsActive, 0);
            cmbProject.Databind("Id", "Name", repo.GetAllProjects(), p => p.IsActive, 0);
            cmbTaskType.Databind("Id", "Name", repo.GetAllTaskTypes(), t => t.IsActive, 0);
        }

        private void setupChecklist()
        {
            lvwChecklistItem.Columns.Add(new iColumnHeader("Nr", "Nr.", 30));
            lvwChecklistItem.Columns.Add(new iColumnHeader("Name", "Item name", true));
        }

        #endregion

        #region Data source

        public override object DataSource
        {
            get
            {
                fillObject();
                return _task;
            }
            set
            {
                _task = value as Task;
                fillForm();
            }
        }

        #region Fill object

        private void fillObject()
        {
            _task.Entity.LocationId = getLocationId();
            _task.Entity.ProjectId = getProjectId();
            _task.Entity.TypeId = getTaskTypeId();
            _task.Entity.Checklist = _checklist.Entity;
            _task.Checklist = new Checklist(_checklist.Entity);
        }

        private string getLocationId()
        {
            return cmbLocation.SelectedIndex == -1 ? null : cmbLocation.SelectedValue.ToString();
        }

        private string getProjectId()
        {
            return cmbProject.SelectedIndex == -1 ? null : cmbProject.SelectedValue.ToString();
        }

        private string getTaskTypeId()
        {
            return cmbTaskType.SelectedIndex == -1 ? null : cmbTaskType.SelectedValue.ToString();
        }

        #endregion

        #region Fill form

        private void fillForm()
        {
            cmbLocation.SelectItem(l => l.Id == _task.Entity.LocationId);
            cmbProject.SelectItem(p => p.Id == _task.Entity.ProjectId);
            cmbTaskType.SelectItem(t => t.Id == _task.Entity.TypeId);
            cmbChecklist.SelectItem(c => c.Id == _task.Entity.Checklist.Id);
            fillChecklistControl();
            cmbChecklist.SelectedIndexChanged += cmbChecklist_SelectedIndexChanged;
        }

        private void fillChecklistControl()
        {
            _checklist.Entity.Id = _task.Checklist.Entity.Id;
            _checklist.Entity.Name = _task.Checklist.Entity.Name;
            _checklist.Entity.Items = _task.Checklist.Entity.Items.ToList();
            loadChecklistItems();
        }

        #endregion

        #endregion

        #region Checklist item selection

        private void cmbChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processChecklistSelected);
        }

        void processChecklistSelected()
        {
            if (cmbChecklist.DroppedDown)
                return;

            fillChecklist();
        }

        private void fillChecklist()
        {
            var checklist = getSelectedChecklist();
            _checklist.Entity.Id = checklist.Id;
            _checklist.Entity.Name = checklist.Name;

            if (chkChecklistAppend.Checked)
                foreach (var item in checklist.Items)
                    _checklist.CreateNewCheckListItem(item.Name);
            else
                _checklist.Entity.Items = checklist.Items.ToList();

            loadChecklistItems();
        }

        private ChecklistEntity getSelectedChecklist()
        {
            if (cmbChecklist.SelectedIndex == -1)
                return new ChecklistEntity();

            return (ChecklistEntity)cmbChecklist.SelectedItem;
        }

        #endregion

        #region Command button actions

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveTask);
        }

        private void saveTask()
        {
            _task = DataSource as Task;
            OnTaskSaved(new EventArgs());
        }

        protected virtual void OnTaskSaved(EventArgs e)
        {
            if (TaskSaved != null)
                TaskSaved(this, e);
        }

        #endregion

        #region Checklist item command button actions

        private void checklistCommandActions(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processChecklistCommand, sender);
        }

        void processChecklistCommand(object sender)
        {
            if (CommandBar[sender].IsSave())
            {
                addChecklistItem();
                return;
            }

            if (CommandBar[sender].IsDelete())
                removeCheckListItem();
        }

        private void addChecklistItem()
        {
            if (string.IsNullOrWhiteSpace(txtChecklistItem.Text))
                return;

            _checklist.CreateNewCheckListItem(txtChecklistItem.Text);
            loadChecklistItems();
            lvwChecklistItem.SelectLastItem();
        }

        private void removeCheckListItem()
        {
            if (!lvwChecklistItem.HasOnlyOneItemSelected())
                return;

            var item = (ChecklistItemEntity)lvwChecklistItem.SelectedItems[0].Tag;
            _checklist.Entity.Items.Remove(item);
            loadChecklistItems();
        }

        #endregion

        #region Checklist item selection

        void lvwChecklistItem_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedChecklistItem, sender, e);
        }

        private void processSelectedChecklistItem(object sender, EventArgs e)
        {
            setChecklistRemoveButtonState();

            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected)
                return;

            txtChecklistItem.Text = ((ChecklistItemEntity)args.Item.Tag).Name;
        }

        private void setChecklistRemoveButtonState()
        {
            btnRemoveChecklistItem.Enabled = lvwChecklistItem.HasOnlyOneItemSelected();
        }

        #endregion

        #region Common

        private void loadChecklistItems()
        {
            lvwChecklistItem.FillData(_checklist.Entity.Items);
        }

        #endregion
    }
}
