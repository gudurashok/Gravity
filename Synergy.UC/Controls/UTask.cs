using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Scalable.SpellChecker;
using Synergy.Domain.ViewModel;
using Synergy.UC.Picklists;
using GravityPicklistFactory = Gravity.Root.Picklists.PicklistFactory;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Events;
using Synergy.UC.Forms;

namespace Synergy.UC.Controls
{
    public partial class UTask : UFormBase
    {
        #region Declarations

        private Task _task;
        private const int _tagRefreshDelayConstant = 100;
        private TaskReminder _reminder;
        private readonly Spelling _spelling;
        private TextBoxBase _textControl;

        public event EventHandler<TaskSavedEventArgs> TaskSaved;

        #endregion

        #region Constructor

        public UTask()
        {
            InitializeComponent();
            _spelling = new Spelling();
            _spelling.DeletedWord += spelling_DeletedWord;
            _spelling.ReplacedWord += spelling_ReplacedWord;
        }

        #endregion

        #region Initialize

        public void Initialize()
        {
            _task = Task.New();
            loadDropDownLists();
            txbParent.PickList = PicklistFactory.Tasks.Form;
            txbOwner.PickList = GravityPicklistFactory.Users.Form;
            txbAssignedBy.PickList = GravityPicklistFactory.Users.Form;
            txbAssignTo.PickList = GravityPicklistFactory.Users.Form;
        }

        private void loadDropDownLists()
        {
            EnumUtil.LoadEnumListItems(cmbPriority, typeof(Priority), Priority.Normal, (int)Priority.None);
            EnumUtil.LoadEnumListItems(cmbEstimatedTime, typeof(Duration));
            fillTag();
        }

        private void fillTag()
        {
            var repo = new TaskRepository();
            cmbTag.DataSource = repo.GetAllTaskTags();
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
            _task.Entity.Name = txtName.Text;
            _task.Entity.Description = rtbDescription.Rtf;
            _task.Entity.DescriptionText = rtbDescription.Text;
            _task.Entity.Tag = cmbTag.Text.Trim();
            _task.Entity.ParentId = getParentId();
            _task.Entity.Value = txtValue.Value;

            _task.Entity.StartDate = getStartDateTime();
            _task.Entity.DueDate = getDueDateTime();
            _task.Entity.EstimatedTime = cmbEstimatedTime.Text;
            _task.Entity.Priority = getPriority();

            _task.Entity.CreatedById = getCreatedById();
            _task.Entity.AssignedById = getAssignedById();
            _task.Entity.AssignedToId = getAssignedToId();
            _task.Entity.CcToIds = getCcToIds();
        }

        private IList<string> getCcToIds()
        {
            return _task.CcTo == null ? null : _task.CcTo.Select(u => u.Entity.Id).ToList();
        }

        private string getParentId()
        {
            return txbParent.Value == null ? null : ((TaskListItem)txbParent.Value).Task.Entity.Id;
        }

        private DateTime? getStartDateTime()
        {
            if (!dtpStartDate.Checked)
                return null;

            var date = dtpStartDate.Value.Date;
            return dtpStartTime.Checked ? getDateAndTime(date, dtpStartTime.Value) : date;
        }

        private DateTime? getDueDateTime()
        {
            if (!dtpDueDate.Checked)
                return null;

            var date = dtpDueDate.Value.Date;
            return dtpDueTime.Checked ? getDateAndTime(date, dtpDueTime.Value) : date;
        }

        private static DateTime getDateAndTime(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day,
                        time.Hour, time.Minute, time.Second, DateTime.Now.Millisecond);
        }

        private Priority getPriority()
        {
            return (Priority)cmbPriority.SelectedValue;
        }

        private string getCreatedById()
        {
            if (_task.IsNew())
                return txbOwner.Value == null
                        ? GravitySession.User.Entity.Id
                        : ((UserEntity)txbOwner.Value).Id;

            return _task.Entity.CreatedById;
        }

        private string getAssignedById()
        {
            if (!txbAssignedBy.Enabled)
                return _task.Entity.AssignedById;

            return txbAssignedBy.Value == null ? null : ((UserEntity)txbAssignedBy.Value).Id;
        }

        private string getAssignedToId()
        {
            if (!txbAssignTo.Enabled)
                return _task.Entity.AssignedToId;

            return txbAssignTo.Value == null ? null : ((UserEntity)txbAssignTo.Value).Id;
        }

        #endregion

        #region Fill form

        private void fillForm()
        {
            txtName.Text = _task.Entity.Name;
            rtbDescription.RichText = _task.Entity.Description;
            cmbTag.Text = _task.Entity.Tag;
            txbParent.Value = getParent();
            txtValue.Value = _task.Entity.Value;
            dtpStartDate.Enabled = shouldEnableStartAndDueDates();
            dtpDueDate.Enabled = shouldEnableStartAndDueDates();
            fillStartDateTimeControls();
            fillDueDateTimeControls();
            cmbEstimatedTime.Text = _task.Entity.EstimatedTime;
            cmbPriority.Text = _task.Entity.Priority.ToString();
            txbOwner.Value = null;
            txbAssignedBy.Value = getAssignedBy();
            txbAssignTo.Value = getAssignedTo();
            txtCcTo.Text = getCcToNames();

            if (shouldDisableAssignedBy())
                txbAssignedBy.Enabled = false;

            setControlStatus();
            showReminder();
        }

        private bool shouldEnableStartAndDueDates()
        {
            return _task.Entity.Recurrence == null ||
                    _task.Entity.Recurrence.RepeatFrom == RecurrenceRepeatFrom.DateCompleted
                    ? true : false;
        }

        private void showReminder()
        {
            _reminder = TaskReminder.GetReminderForSelectedTask(_task.Entity.Id, GravitySession.User.Entity.Id);

            if (_reminder == null)
                return;

            dtpReminderDate.Value = _reminder.Entity.RemindOn;
            dtpReminderTime.Enabled = dtpReminderDate.Checked;
            dtpReminderTime.Value = _reminder.Entity.RemindOn;

            if (dtpReminderDate.Checked)
                chkReminderForAll.Enabled = true;

            chkReminderForAll.Checked = _reminder.Entity.UserIds
                                                .Where(r => r.ToString() != GravitySession.User.Entity.Id)
                                                .Count() > 0;
        }

        private TaskListItem getParent()
        {
            if (string.IsNullOrWhiteSpace(_task.Entity.ParentId))
                return null;

            var repo = new TaskRepository();
            var item = new TaskListItem { Task = new Task(repo.GetTaskEntityBy(_task.Entity.ParentId)) };
            return item;
        }

        private void setControlStatus()
        {
            var canUpdate = _task.CanUpdateStatus(TaskUpdateAction.Edit, GravitySession.User);
            txtName.ReadOnly = !canUpdate;
            cmbTag.Enabled = canUpdate;
            txbParent.Enabled = canUpdate;
            rtbDescription.ReadOnly = !canUpdate;
            pnlTask.Enabled = canUpdate;
            CommandBar.Enabled = canUpdate;
            recurrenceToolStripMenuItem.Enabled = canUpdate;
            addCommentToolStripMenuItem.Enabled = canComment();
            btnCcTo.Enabled = canUpdate;
            viewCommentsToolStripMenuItem.Enabled = !_task.IsNew();

            dtpReminderDate.Value = DateTime.Now;
            dtpReminderDate.Checked = false;
            dtpReminderTime.Value = DateTime.Now;
            dtpReminderTime.Enabled = dtpReminderDate.Checked;
            chkReminderForAll.Enabled = dtpReminderDate.Checked;
            chkReminderForAll.Checked = false;
        }

        private bool canComment()
        {
            if (_task.IsNew())
                return false;
            if (_task.Entity.Status == TaskStatus.Completed)
                return false;
            if (_task.Entity.Status == TaskStatus.Cancelled)
                return false;

            return true;
        }

        private UserEntity getAssignedBy()
        {
            if (_task.IsNew())
                return null;

            var users = new Users();

            if (string.IsNullOrWhiteSpace(_task.Entity.AssignedById))
                return GravitySession.User.Entity.Id != _task.Entity.CreatedById
                           ? users.GetById(_task.Entity.CreatedById).Entity
                           : null;

            return GravitySession.User.Entity.Id != _task.Entity.AssignedById
                           ? users.GetById(_task.Entity.AssignedById).Entity
                           : null;
        }

        private UserEntity getAssignedTo()
        {
            if (_task.IsNew())
                return null;

            var users = new Users();

            if (string.IsNullOrWhiteSpace(_task.Entity.AssignedToId))
                return GravitySession.User.Entity.Id != _task.Entity.CreatedById
                           ? users.GetById(_task.Entity.CreatedById).Entity
                           : null;

            return GravitySession.User.Entity.Id != _task.Entity.AssignedToId
                           ? users.GetById(_task.Entity.AssignedToId).Entity
                           : null;
        }

        private bool shouldDisableAssignedBy()
        {
            if (_task.IsNew())
                return false;

            if (string.IsNullOrWhiteSpace(_task.Entity.AssignedById))
                return false;

            if (_task.Entity.CreatedById == GravitySession.User.Entity.Id)
                return false;

            return true;
        }

        private void fillStartDateTimeControls()
        {
            dtpStartDate.Checked = false;
            dtpStartTime.Checked = false;

            if (_task.Entity.StartDate == null)
                return;

            dtpStartDate.Checked = true;
            dtpStartDate.Value = _task.Entity.StartDate.Value;

            dtpStartTime.Value = _task.Entity.StartDate.Value;
            dtpStartTime.Checked = isDateHasTimePart(_task.Entity.StartDate.Value);
            dtpStartTime.Enabled = dtpStartDate.Checked && dtpStartDate.Enabled;
        }

        private void fillDueDateTimeControls()
        {
            dtpDueDate.Checked = false;
            dtpDueTime.Checked = false;

            if (_task.Entity.DueDate == null)
                return;

            dtpDueDate.Checked = true;
            dtpDueDate.Value = _task.Entity.DueDate.Value;

            dtpDueTime.Value = _task.Entity.DueDate.Value;
            dtpDueTime.Checked = isDateHasTimePart(_task.Entity.DueDate.Value);
            dtpDueTime.Enabled = dtpDueDate.Checked && dtpDueDate.Enabled;
        }

        private static bool isDateHasTimePart(DateTime value)
        {
            return value.Hour > 0 || value.Minute > 0 || value.Second > 0 || value.Millisecond > 0;
        }

        #endregion

        #endregion

        #region Setting start time control state

        private void dtpStartDate_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setStartTimeState);
        }

        private void setStartTimeState()
        {
            dtpStartTime.Enabled = dtpStartDate.Checked;
            dtpStartTime.Checked = dtpStartDate.Checked;

            if (dtpStartDate.Checked && _task.Entity.StartDate.HasValue)
                return;

            if (dtpStartDate.Checked)
                dtpStartDate.Value = DateTime.Today;

            if (dtpStartTime.Checked)
                dtpStartTime.Value = DateTime.Now;
        }

        #endregion

        #region Setting due time control state

        private void dtpDueDate_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setDueTimeState);
        }

        private void setDueTimeState()
        {
            dtpDueTime.Enabled = dtpDueDate.Checked;
            dtpDueTime.Checked = dtpDueDate.Checked;

            if (dtpDueDate.Checked && _task.Entity.DueDate.HasValue)
                return;

            if (dtpDueDate.Checked)
                dtpDueDate.Value = DateTime.Today;

            if (dtpDueTime.Checked)
                dtpDueTime.Value = DateTime.Now;
        }

        #endregion

        #region Save task

        private void commandBarButton_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandBarAction, sender);
        }

        private void processCommandBarAction(object sender)
        {
            if (CommandBar[sender].IsSave())
            {
                processSave();
                OnTaskSaved(new TaskSavedEventArgs(_task, CommandBar[sender]));
            }

            if (CommandBar[sender].IsNew())
            {
                Thread.Sleep(_tagRefreshDelayConstant);
                processNew();
                txtName.Focus();
            }
        }

        private void OnTaskSaved(TaskSavedEventArgs taskSavedEventArgs)
        {
            if (TaskSaved != null)
                TaskSaved(this, taskSavedEventArgs);
        }

        private void processNew()
        {
            fillTag();
            DataSource = Task.New();
            setStartTimeState();
            setDueTimeState();
        }

        private void processSave()
        {
            var task = ((Task)DataSource);
            var isNew = task.IsNew();
            task.Save();
            processReminder();
            task.WasNew = isNew; 

            if (!GravitySession.User.Entity.ShowNotifications
                    || !isNew || GravitySession.User.Entity.IsAdmin)
                return;

            MessageBoxUtil.ShowMessage(string.Format("Saved Task Nr: {0}", _task.GetTaskNumber()));
        }

        private void processReminder()
        {
            if (dtpReminderDate.Checked)
                setReminder();
            else
                deleteReminderIfExist();
        }

        private void deleteReminderIfExist()
        {
            if (_reminder == null)
                return;

            TaskReminder.DeleteReminderOfCurrentUser(_reminder);
        }

        private IList<string> getAllUserIdsOfPresentTask()
        {
            var userIds = new List<string>();

            userIds.Add(GravitySession.User.Entity.Id);
            if (!chkReminderForAll.Checked)
                return userIds;

            if (!string.IsNullOrWhiteSpace(_task.Entity.AssignedById))
                userIds.Add(_task.Entity.AssignedById);

            if (!string.IsNullOrWhiteSpace(_task.Entity.AssignedToId))
                userIds.Add(_task.Entity.AssignedToId);

            if (_task.Entity.CcToIds != null && _task.Entity.CcToIds.Count > 0)
                userIds.AddRange(_task.Entity.CcToIds);

            return userIds.Distinct().ToList();
        }

        private void setReminder()
        {
            if (_reminder == null)
                _reminder = TaskReminder.New();

            _reminder.Entity.UserIds = getAllUserIdsOfPresentTask();
            _reminder.Entity.TaskId = _task.Entity.Id;
            //_reminder.Entity.TaskNr = _task.Entity.Number;
            _reminder.Entity.Name = _task.Entity.Name;
            _reminder.Entity.RemindOn = getReminderDate();
            _reminder.Entity.IsDefault = true;
            _reminder.Save();
        }

        private DateTime getReminderDate()
        {
            var date = dtpReminderDate.Value;
            var time = dtpReminderTime.Value;
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }

        #endregion

        #region Process Recurrence

        private void recurranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processShowRecurrenceForm);
        }

        private void processShowRecurrenceForm()
        {
            var recurrence = new FRecurrence(_task);
            if (recurrence.ShowDialog() != DialogResult.OK)
                return;

            var noRecurrence = shouldEnableStartAndDueDates();
            dtpDueDate.Enabled = noRecurrence;
            dtpStartDate.Enabled = noRecurrence;

            if (noRecurrence)
            {
                dtpStartDate.Value = DateTime.Today;
                dtpDueDate.Value = DateTime.Today;
                return;
            }

            var recurrenceDate = _task.Entity.Recurrence.StartDate.Date >= DateTime.Today
                                    ? _task.Entity.Recurrence.StartDate.Date : DateTime.Today;

            _task.Entity.DueDate = recurrenceDate;
            _task.Entity.StartDate = recurrenceDate;

            fillDueDateTimeControls();
            fillStartDateTimeControls();
        }

        #endregion

        #region Process Advanced

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showAdvancedForm);
        }

        private void showAdvancedForm()
        {
            new FTaskAdvanced(_task).ShowDialog();
        }

        #endregion

        #region Process Attachments

        private void attachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showAttachmentForm);
        }

        private void showAttachmentForm()
        {
            var result = new FFileAttachment(_task).ShowDialog();
            if (result != DialogResult.OK || pnlTask.Enabled)
                return;

            _task.Save();
        }

        #endregion

        #region Add Comments

        private void addCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddComment);
        }

        void processAddComment()
        {
            var args = getTaskAddCommentFormArgs();
            var notesForm = new FNotes(args);
            var result = notesForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var comment = TaskCommentEntity.New();
            comment.TaskId = _task.Entity.Id;
            comment.Comment = args.Notes;
            comment.UserId = GravitySession.User.Entity.Id;

            new TaskComment(comment) { Task = _task }.Save();
        }

        private NotesFormArgs getTaskAddCommentFormArgs()
        {
            var args = new NotesFormArgs();
            args.Caption = string.Format("Comment on Task #{0}", _task.GetTaskNumber());
            args.Title = string.Format("comment on '{0}'", _task.Entity.Name);
            args.Required = true;
            return args;
        }

        #endregion

        #region View Comments

        private void viewCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showComments);
        }

        private void showComments()
        {
            new FNotes(getShowCommentsArgs())
                .ShowDialog();
        }

        private NotesFormArgs getShowCommentsArgs()
        {
            var args = new NotesFormArgs();
            args.Caption = string.Format("Task #{0} Comments", _task.GetTaskNumber());
            args.Title = _task.Entity.Name;
            args.ReadOnly = true;
            args.IsRtf = true;
            args.Notes = _task.ToStringComments();
            return args;
        }

        #endregion

        #region Common

        private void dtpStartTime_CheckedChanged(object sender, EventArgs e)
        {
            if ((_task.Entity.StartDate.HasValue && isDateHasTimePart(_task.Entity.StartDate.Value)) || !dtpStartTime.Checked)
                return;

            dtpStartTime.Value = DateTime.Now;
        }

        private void dtpDueTime_CheckedChanged(object sender, EventArgs e)
        {
            if ((_task.Entity.DueDate.HasValue && isDateHasTimePart(_task.Entity.DueDate.Value) || !dtpDueTime.Checked))
                return;

            dtpDueTime.Value = DateTime.Now;
        }

        #endregion

        #region CC To

        private void btnCcTo_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCcTo);
        }

        void processCcTo()
        {
            var fCclist = new FMultiUsers(_task.CcTo);
            if (fCclist.ShowDialog() != DialogResult.OK)
                return;

            _task.CcTo = fCclist.Users;
            txtCcTo.Text = getCcToNames();
        }

        private string getCcToNames()
        {
            if (_task.CcTo == null)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var user in _task.CcTo)
                sb.Append(user.Entity.Name).Append(", ");

            if (sb.Length >= 2)
                sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        #endregion

        #region Set reminder

        private void dtpReminder_CheckedChanged(object sender, EventArgs e)
        {
            dtpReminderTime.Enabled = dtpReminderDate.Checked;
            chkReminderForAll.Enabled = dtpReminderDate.Checked;
            if (!chkReminderForAll.Enabled)
                chkReminderForAll.Checked = false;
        }

        #endregion

        #region Save as Templete

        private void lnkSaveAsTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(saveTemplate);
        }

        private void saveTemplate()
        {
            var template = TaskTemplate.New();
            var task = ((Task)DataSource);
            template.Entity.Tag = task.Entity.Tag;
            template.Entity.Description = task.Entity.Description;

            template.Entity.EstimatedTime = task.Entity.EstimatedTime;
            template.AssignedBy = getAssignedByObject();
            template.AssignedTo = getAssignedToObject();
            template.CcTo = task.CcTo;

            template.Entity.Priority = task.Entity.Priority;

            template.Entity.TypeId = task.Entity.TypeId;
            template.Entity.ProjectId = task.Entity.ProjectId;
            template.Entity.LocationId = task.Entity.LocationId;

            template.Entity.Checklist = task.Entity.Checklist;
            template.Checklist = task.Checklist;
            template.Entity.Attachments = task.Entity.Attachments.ToList();

            var fTemplate = new FTaskTemplate(template);
            fTemplate.ShowDialog();
        }

        private User getAssignedByObject()
        {
            return txbAssignedBy.Value == null ? null : new User((UserEntity)txbAssignedBy.Value);
        }

        private User getAssignedToObject()
        {
            return txbAssignTo.Value == null ? null : new User((UserEntity)txbAssignTo.Value);
        }

        private void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showTemplateList);
        }

        private void showTemplateList()
        {
            var fTemplates = new FTaskTemplates();
            if (fTemplates.ShowDialog() != DialogResult.OK)
                return;

            var template = fTemplates.Template;

            _task.Entity.Tag = template.Entity.Tag;
            _task.Entity.Description = template.Entity.Description;

            _task.Entity.EstimatedTime = template.Entity.EstimatedTime;
            _task.AssignedBy = template.AssignedBy;
            _task.AssignedTo = template.AssignedTo;
            _task.CcTo = template.CcTo;

            _task.Entity.Priority = template.Entity.Priority;

            _task.Entity.TypeId = template.Entity.TypeId;
            _task.Entity.ProjectId = template.Entity.ProjectId;
            _task.Entity.LocationId = template.Entity.LocationId;

            _task.Entity.Checklist = template.Entity.Checklist;
            _task.Checklist = template.Checklist;
            _task.Entity.Attachments = template.Entity.Attachments.ToList();

            fillForm();
            txbAssignedBy.Value = template.AssignedBy == null ? null : template.AssignedBy.Entity;
            txbAssignTo.Value = template.AssignedTo == null ? null : template.AssignedTo.Entity;
        }

        #endregion

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
