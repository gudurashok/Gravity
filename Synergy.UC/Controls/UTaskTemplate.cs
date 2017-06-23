using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Picklists;
using Scalable.Shared.Common;
using Scalable.SpellChecker;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Properties;

namespace Synergy.UC.Controls
{
    public partial class UTaskTemplate : UFormBase
    {
        public event EventHandler TemplateSaved;
        public event EventHandler Cancelled;

        private readonly Spelling _spelling;
        private TextBoxBase _textControl;
        private readonly Checklist _checklist = Checklist.New();
        private AttachmentEntity _attachment;
        private IList<AttachmentEntity> _attachments;

        private TaskTemplate _template;

        public UTaskTemplate()
        {
            InitializeComponent();
            setAnchors();
            _spelling = new Spelling();
            _spelling.DeletedWord += spelling_DeletedWord;
            _spelling.ReplacedWord += spelling_ReplacedWord;
        }

        private void setAnchors()
        {
            Splitter1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            Splitter2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            Splitter3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            Splitter5.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        public void Initialize()
        {
            _template = TaskTemplate.New();
            loadDropDownLists();
            setupChecklist();
            setupAttachments();
            loadPicklists();
        }

        private void loadPicklists()
        {
            txbAssignedBy.PickList = PicklistFactory.Users.Form;
            txbAssignTo.PickList = PicklistFactory.Users.Form;
        }

        private void loadDropDownLists()
        {
            EnumUtil.LoadEnumListItems(cmbPriority, typeof(Priority), Priority.Normal, (int)Priority.None);
            EnumUtil.LoadEnumListItems(cmbEstimatedTime, typeof(Duration));

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

        private void setupAttachments()
        {
            lvwAttachments.Columns.Add(new iColumnHeader("Nr", "Nr.", 35));
            lvwAttachments.Columns.Add(new iColumnHeader("Name", "Attachment", true));
            lvwAttachments.Columns.Add(new iColumnHeader("Type", 40));
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _template;
            }
            set
            {
                _template = value as TaskTemplate;
                fillForm();
            }
        }

        private void fillObject()
        {
            _template.Entity.Name = txtName.Text.Trim();
            _template.Entity.Tag = txtTag.Text.Trim();
            _template.Entity.Description = rtbDescription.Rtf;
            _template.Entity.EstimatedTime = cmbEstimatedTime.Text;
            _template.Entity.Priority = getPriority();
            _template.AssignedBy = getAssignedByObject();
            _template.Entity.AssignedById = getAssignedById();
            _template.AssignedTo = getAssignedToObject();
            _template.Entity.AssignedToId = getAssignedToId();
            _template.Entity.CcToIds = getCcToIds();
            _template.Entity.LocationId = getLocationId();
            _template.Entity.ProjectId = getProjectId();
            _template.Entity.TypeId = getTaskTypeId();
            _template.Entity.Checklist = _checklist.Entity;
            _template.Checklist = new Checklist(_checklist.Entity);
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

        private Priority getPriority()
        {
            return (Priority)cmbPriority.SelectedValue;
        }

        private User getAssignedByObject()
        {
            return txbAssignedBy.Value == null ? null : new User(((UserEntity)txbAssignedBy.Value));
        }

        private User getAssignedToObject()
        {
            return txbAssignTo.Value == null ? null : new User(((UserEntity)txbAssignTo.Value));
        }

        private string getAssignedById()
        {
            return txbAssignedBy.Value == null ? null : ((UserEntity)txbAssignedBy.Value).Id;
        }

        private string getAssignedToId()
        {
            return txbAssignTo.Value == null ? null : ((UserEntity)txbAssignTo.Value).Id;
        }

        private IList<string> getCcToIds()
        {
            return _template.CcTo == null ? null : _template.CcTo.Select(u => u.Entity.Id).ToList();
        }

        private void fillForm()
        {
            txtName.Text = _template.Entity.Name;
            txtTag.Text = _template.Entity.Tag;
            rtbDescription.RichText = _template.Entity.Description;

            cmbEstimatedTime.Text = _template.Entity.EstimatedTime;
            cmbPriority.Text = _template.Entity.Priority.ToString();
            txbAssignedBy.Value = getAssignedBy();
            txbAssignTo.Value = getAssignedTo();
            txtCcTo.Text = getCcToNames();

            cmbLocation.SelectItem(l => l.Id == _template.Entity.LocationId);
            cmbProject.SelectItem(p => p.Id == _template.Entity.ProjectId);
            cmbTaskType.SelectItem(t => t.Id == _template.Entity.TypeId);
            cmbChecklist.SelectItem(c => c.Id == _template.Entity.Checklist.Id);
            fillChecklistObject();
            fillAttachments();
            cmbChecklist.SelectedIndexChanged += cmbChecklist_SelectedIndexChanged;
        }

        private void fillAttachments()
        {
            _attachments = _template.Entity.Attachments;
            lvwAttachments.FillData(_attachments);
        }

        private void fillChecklistObject()
        {
            _checklist.Entity.Id = _template.Checklist.Entity.Id;
            _checklist.Entity.Name = _template.Checklist.Entity.Name;
            _checklist.Entity.Items = _template.Checklist.Entity.Items.ToList();
            loadChecklistItems();
        }

        private UserEntity getAssignedBy()
        {
            return _template.AssignedBy == null ? null : _template.AssignedBy.Entity;
        }

        private UserEntity getAssignedTo()
        {
            return _template.AssignedTo == null ? null : _template.AssignedTo.Entity;
        }

        private string getCcToNames()
        {
            if (_template.CcTo == null)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var user in _template.CcTo)
                sb.Append(user.Entity.Name).Append(", ");

            if (sb.Length >= 2)
                sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSave);
        }

        void processSave()
        {
            ((TaskTemplate)DataSource).Save();
            OnTemplateSaved(new EventArgs());
        }

        protected virtual void OnTemplateSaved(EventArgs e)
        {
            if (TemplateSaved != null)
                TemplateSaved(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelled(new EventArgs());
        }

        protected virtual void OnCancelled(EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, e);
        }

        private void btnCcTo_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCcTo);
        }

        void processCcTo()
        {
            var fCclist = new FMultiUsers(_template.CcTo);
            if (fCclist.ShowDialog() != DialogResult.OK)
                return;

            _template.CcTo = fCclist.Users;
            txtCcTo.Text = getCcToNames();
        }

        #region Checklist item command button actions

        private void checklistCommandActions(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processChecklistCommand, sender);
        }

        void processChecklistCommand(object sender)
        {
            if (CommandBar[sender].IsAdd())
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

        private void loadChecklistItems()
        {
            lvwChecklistItem.FillData(_checklist.Entity.Items);
        }

        #endregion


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

        #region Select file to attach

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(openFileBrowser);
        }

        void openFileBrowser()
        {
            var fileBrowser = new iFileBrowser("Attach File", Parent as Form);
            var path = fileBrowser.Show();

            if (string.IsNullOrWhiteSpace(txtAttachment.Text))
                txtAttachment.Text = fileBrowser.SelectedFileName;

            if (!string.IsNullOrWhiteSpace(path))
                txtPath.Text = Pathing.GetUNCPath(path);
        }

        #endregion

        #region Process link

        private void chkIsLink_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processLink);
        }

        void processLink()
        {
            lblPath.Text = !chkIsLink.Checked ? "&Path" : "Lin&k";
            txtPath.ReadOnly = !chkIsLink.Checked;
            btnBrowseFile.Enabled = !chkIsLink.Checked;
            //TODO: Enable later
            //chkEmbedded.Enabled = !chkIsLink.Checked;
        }

        #endregion

        private void attachmentButtonAction_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandButtonAction, sender);
        }

        void processCommandButtonAction(object sender)
        {
            if (CommandBar[sender].IsDelete())
                processDeleteAttachment();

            if (CommandBar[sender].IsAdd())
                processSaveItem();
        }

        private void processDeleteAttachment()
        {
            _attachments.Remove(getSelectedAttachment());
            lvwAttachments.FillData(_attachments);
        }

        private AttachmentEntity getSelectedAttachment()
        {
            if (lvwAttachments.HasAnyItemsSelected())
                return (AttachmentEntity)lvwAttachments.SelectedItems[0].Tag;

            return null;
        }

        private void processSaveItem()
        {
            if (!isValidAttachment())
                return;

            _attachment = new AttachmentEntity();
            _attachment.Name = txtAttachment.Text;
            _attachment.Path = txtPath.Text;
            _attachment.Type = chkIsLink.Checked ? AttachmentType.Link : AttachmentType.File;
            _attachment.AttachedOn = DateTime.Now;
            _attachment.Nr = getNewAttachmentNr();
            _attachments.Add(_attachment);
            lvwAttachments.FillData(_attachments);

            txtAttachment.Text = string.Empty;
            txtPath.Text = string.Empty;
            chkIsLink.Checked = false;
            return;
        }

        private bool isNew()
        {
            return _attachment.Nr == 0;
        }

        private int getNewAttachmentNr()
        {
            return _attachments.Count > 0 ? _attachments.Max(c => c.Nr) + 1 : 1;
        }

        private bool isValidAttachment()
        {
            if (string.IsNullOrWhiteSpace(txtAttachment.Text) || string.IsNullOrWhiteSpace(txtPath.Text))
                return false;

            var count = _attachments.Count(f => f.Name == txtAttachment.Text && f.Path == txtPath.Text);
            if (count != 0 && isNew())
                throw new ValidationException(Resources.AttachmentAlreadyExist);

            return true;
        }

        private void lvwAttachment_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnRemoveAttachment.Enabled = lvwAttachments.HasAnyItemsSelected();
        }

        private void lvwChecklist_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnRemoveChecklistItem.Enabled = lvwChecklistItem.HasAnyItemsSelected();
        }


        #region Spell check

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(SpellCheck);
        }

        private void SpellCheck()
        {
            _textControl = txtName;
            _spelling.AlertComplete = false;
            _spelling.SpellCheck(_textControl.Text);

            while (_spelling.SuggestionForm.Visible)
                Application.DoEvents();

            _textControl = rtbDescription;
            _spelling.AlertComplete = true;
            _spelling.SpellCheck(_textControl.Text);
        }

        private void spelling_DeletedWord(object sender, SpellingEventArgs e)
        {
            EventHandlerExecutor.Execute(deleteSpelling, sender, e);
        }

        private void deleteSpelling(object sender, EventArgs e)
        {
            var args = (SpellingEventArgs)e;
            var start = _textControl.SelectionStart;
            var length = _textControl.SelectionLength;

            _textControl.Select(args.TextIndex, args.Word.Length);
            _textControl.SelectedText = "";

            if (start > _textControl.Text.Length)
                start = _textControl.Text.Length;

            if ((start + length) > _textControl.Text.Length)
                length = 0;

            _textControl.Select(start, length);
        }

        private void spelling_ReplacedWord(object sender, ReplaceWordEventArgs e)
        {
            EventHandlerExecutor.Execute(replaceSpelling, sender, e);
        }

        private void replaceSpelling(object sender, EventArgs e)
        {
            var args = (ReplaceWordEventArgs)e;
            var start = _textControl.SelectionStart;
            var length = _textControl.SelectionLength;

            _textControl.Select(args.TextIndex, args.Word.Length);
            _textControl.SelectedText = args.ReplacementWord;

            if (start > _textControl.Text.Length)
                start = _textControl.Text.Length;

            if ((start + length) > _textControl.Text.Length)
                length = 0;

            _textControl.Select(start, length);
        }

        #endregion
    }
}
