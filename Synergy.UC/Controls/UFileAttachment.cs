using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Repositories;
using Synergy.UC.Properties;

namespace Synergy.UC.Controls
{
    public partial class UFileAttachment : UPicklist
    {
        #region Declarations

        public bool ReadOnly { get; set; }
        public event EventHandler AttachmentsSaved;
        private AttachmentEntity _attachment;
        private IList<AttachmentEntity> _attachments;
        private int _panelHeight;

        #endregion

        #region Contructor

        public UFileAttachment()
        {
            _attachments = new List<AttachmentEntity>();
            InitializeComponent();
        }

        #endregion

        #region Initialize form

        public override void Initialize()
        {
            MakeList();
            _panelHeight = pnlFileDetails.Height + 2;
            btnDelete.Enabled = getDeleteButtonStatus();
            buildColumns();
            _attachments = _attachments.Union((IList<AttachmentEntity>)DataSource).ToList();
            Repository = new TaskAttachments(_attachments);
            FillList(true);
            hidePanel();
        }

        private bool getDeleteButtonStatus()
        {
            return lvw.SelectedItems.Count > 0 && !ReadOnly;
        }

        private void buildColumns()
        {
            lvw.Columns.Add(new iColumnHeader("Nr", "Nr.", 35));
            lvw.Columns.Add(new iColumnHeader("Name", 200));
            lvw.Columns.Add(new iColumnHeader("Path", true));
            lvw.Columns.Add(new iColumnHeader("Type", 40));
            lvw.Columns.Add(new iColumnHeader("AttachedOn", "Attached On", 132));
        }

        #endregion

        #region Select file to attach

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(openFileBrowser);
        }

        void openFileBrowser()
        {
            var fileBrowser = new iFileBrowser("Attach File", Parent as Form);
            var path = fileBrowser.Show();

            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Text = fileBrowser.SelectedFileName;

            if (!string.IsNullOrWhiteSpace(path))
                txtPath.Text = Pathing.GetUNCPath(path);
        }

        #endregion

        #region Item selection

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(setFormState);
        }

        private void setFormState()
        {
            btnDelete.Enabled = getDeleteButtonStatus();
            btnEdit.Enabled = lvw.HasAnyItemsSelected();
            btnOpen.Enabled = lvw.HasAnyItemsSelected();

            _attachment = getSelectedAttachment();
            txtFullName.Text = _attachment == null ? string.Empty : _attachment.Path;
        }

        #endregion

        #region Open attachment

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            EventHandlerExecutor.Execute(processOpenAttachment);
        }

        private void processOpenAttachment()
        {
            Process.Start(txtFullName.Text);
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

        #region Command button actions

        private void commandButtonAction_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandButtonAction, sender);
        }

        void processCommandButtonAction(object sender)
        {
            if (CommandBar[sender].IsNew())
                processNewAttachment();

            if (CommandBar[sender].IsEdit())
                processEditAttachment();

            if (CommandBar[sender].IsDelete())
                processDeleteAttachment();

            if (CommandBar[sender].IsAdd())
                processSaveItem();

            if (CommandBar[sender].IsCancel())
                hidePanel();

            if (CommandBar[sender].IsSave())
                raiseSaveEvent();
        }

        private void processNewAttachment()
        {
            _attachment = new AttachmentEntity();
            chkIsLink.Checked = false;
            txtName.Text = string.Empty;
            txtPath.Text = string.Empty;
            btnAdd.Text = @"Add";
            showPanel();
        }

        private void processEditAttachment()
        {
            _attachment = getSelectedAttachment();
            chkIsLink.Checked = _attachment.Type == AttachmentType.Link;
            txtName.Text = _attachment.Name;
            txtPath.Text = _attachment.Path;
            btnAdd.Text = @"Update";
            showPanel();
        }

        private void processDeleteAttachment()
        {
            var result = MessageBoxUtil.GetConfirmationYesNo(Resources.WantToRemoveAttachment);
            if (result != DialogResult.Yes)
                return;

            _attachments.Remove(getSelectedAttachment());
            FillList(true);
            hidePanel();
            setFormState();
        }

        private AttachmentEntity getSelectedAttachment()
        {
            if (ListView.HasAnyItemsSelected())
                return (AttachmentEntity)lvw.SelectedItems[0].Tag;

            return null;
        }

        private void processSaveItem()
        {
            validateAttachment();

            _attachment.Name = txtName.Text;
            _attachment.Path = txtPath.Text;
            _attachment.Type = chkIsLink.Checked ? AttachmentType.Link : AttachmentType.File;
            _attachment.AttachedOn = DateTime.Now;

            if (isNew())
            {
                _attachment.Nr = getNewAttachmentNr();
                _attachments.Add(_attachment);
            }

            FillList(true);
            hidePanel();
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

        private void validateAttachment()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                throw new ValidationException(Resources.AttachmentNameCannotBeEmpty);

            if (string.IsNullOrWhiteSpace(txtPath.Text))
                throw new ValidationException(
                        string.Format(Resources.AttachmentPathCannotBeEmpty,
                                                chkIsLink.Checked ? "link" : "path"));

            var count = _attachments.Count(f => f.Name == txtName.Text && f.Path == txtPath.Text);
            if (count != 0 && isNew())
                throw new ValidationException(Resources.AttachmentAlreadyExist);
        }

        private void raiseSaveEvent()
        {
            DataSource = _attachments;
            OnAttachmentsSaved(new EventArgs());
        }

        protected virtual void OnAttachmentsSaved(EventArgs e)
        {
            if (AttachmentsSaved != null)
                AttachmentsSaved(this, e);
        }

        #endregion

        #region Show/Hide panel

        void showPanel()
        {
            if (pnlFileDetails.Visible)
                return;

            lvw.Height = lvw.Height - _panelHeight;
            lblFullName.Location = new Point(lblFullName.Location.X, lblFullName.Location.Y - _panelHeight);
            txtFullName.Location = new Point(txtFullName.Location.X, txtFullName.Location.Y - _panelHeight);
            pnlFileDetails.Visible = true;
        }

        void hidePanel()
        {
            if (!pnlFileDetails.Visible)
                return;

            lvw.Height = lvw.Height + _panelHeight;
            lblFullName.Location = new Point(lblFullName.Location.X, lblFullName.Location.Y + _panelHeight);
            txtFullName.Location = new Point(txtFullName.Location.X, txtFullName.Location.Y + _panelHeight);
            pnlFileDetails.Visible = false;
        }

        #endregion
    }
}
