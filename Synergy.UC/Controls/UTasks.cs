using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Enums;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.Domain.ViewModel;
using Synergy.UC.Events;
using Synergy.UC.Forms;
using Synergy.UC.Properties;
using FOptions = Synergy.UC.Forms.FOptions;
using Timer = System.Windows.Forms.Timer;

namespace Synergy.UC.Controls
{
    public partial class UTasks : UPicklist
    {
        #region Declarations

        private const int _refreshDelayTime = 100;
        private CurrentTaskDetails _currentTaskDetails;
        private bool _reinitialize;
        private bool _isMultipleLogin;
        private Timer _currentTaskTimer;

        private FormStartPosition _taskWindowStartPosition;
        private FormWindowState _taskWindowState;
        private Point _taskWindowLocation;
        private Size _taskWindowSize;
        private TaskSearchCriteria _criteria;

        private FReminderPopup _reminderPopup;
        private FReminderPopup reminderPopup
        {
            get { return _reminderPopup ?? (_reminderPopup = new FReminderPopup()); }
        }

        private FMessageBox _messageBox;
        private FMessageBox messageBox
        {
            get { return _messageBox ?? (_messageBox = new FMessageBox()); }
        }

        public event EventHandler<CurrentTaskTimeEventArgs> CurrentTaskTimerTicked;
        public event EventHandler<TaskSearchEventArgs> TaskSearched;
        public event EventHandler<TaskSavedEventArgs> TaskStatusUpdated;
        public event EventHandler<TaskSelectedEventArgs> TaskSelected;
        public event EventHandler<TaskSelectedEventArgs> TaskOpened;
        public event EventHandler<TaskCommentEventArgs> CommentAdded;

        #endregion

        #region Constructor

        public UTasks()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize

        public override void Initialize()
        {
            EventHandlerExecutor.Execute(processInitialize);
        }

        private void processInitialize()
        {
            SearchProperty = "Name";
            buildColumns();
            TaskRecurrence.EvaluateRecurrences();

            _taskWindowStartPosition = UserConfig.TaskWindowStartPosition;
            _taskWindowState = UserConfig.TaskWindowState;
            _taskWindowLocation = UserConfig.TaskWindowLocation;
            _taskWindowSize = UserConfig.TaskWindowSize;

            ReInitialize();
        }

        private void hidePicklistSearchBox()
        {
            txt.Enabled = false;
            txt.Visible = false;
        }

        public void ReInitialize(bool reinitialize = false)
        {
            _reinitialize = reinitialize;
            if (GravitySession.User.Entity.IsAdmin)
            {
                addSetupMenuItem();
                addTaskStatsMenuItem();
            }

            toggleSearchBar();
            togglePreviewBar();
            _criteria = new TaskSearchCriteria();
            performSearch(_criteria);
            uSearch.Initialize();
            hookEventHandlers();
            ListView.SelectTopItem();
            hidePicklistSearchBox();
            txtFullSearch.Focus();

            if (!_reinitialize)
                processCurrentTask();

            lblCurrentTaskInfo.AutoSizeLeft = true;
            btnShowComments.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rtbComments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

        }

        private void processCurrentTask()
        {
            var taskExecutions = TaskExecution.GetFaultyTaskExecution();
            if (taskExecutions != null)
                resolveFaultyCurrentTask(taskExecutions);

            if (_isMultipleLogin)
                return;

            TaskExecution.ReassignCurrentTask();
            startTimer();
            setCurrentTaskDetails();
        }

        private void resolveFaultyCurrentTask(TaskExecutionEntity entity)
        {
            var dialog = MessageBoxUtil.GetConfirmationYesNo("Was program crashed after your previous login?");
            if (dialog == DialogResult.Yes)
            {
                var fCurrentTaskDuration = new FCurrentTaskDuration(entity);
                fCurrentTaskDuration.ShowDialog();
                return;
            }

            _isMultipleLogin = true;
            return;
        }

        private void setCurrentTaskDetails()
        {
            var taskNr = TaskExecution.GetCurrentTaskNr();
            if (_currentTaskDetails != null && _currentTaskDetails.TaskNr == taskNr)
                return;

            Thread.Sleep(_refreshDelayTime);
            _currentTaskDetails = TaskExecution.GetCurrentTaskDetails();
            if (_currentTaskDetails == null) return;

            var task = getTaskByNr(_currentTaskDetails.TaskNr);

            if (task == null)
            {
                lblCurrentTaskInfo.Tag = null;
                lblCurrentTaskInfo.Text = Resources.NoCurrentTask;
                clearTimer();
                return;
            }

            lblCurrentTaskInfo.Tag = task;
            if (_currentTaskDetails.TaskNr == null)
            {
                lblCurrentTaskInfo.Tag = null;
                lblCurrentTaskInfo.Text = Resources.NoCurrentTask;
                clearTimer();
                return;
            }

            setCurrentTaskButtonImage(getSelectedTask());
            if (_currentTaskTimer == null)
                startTimer();

        }

        private Task getTaskByNr(string taskNr)
        {
            return string.IsNullOrWhiteSpace(taskNr)
                        ? null
                        : (ListView.Items.Cast<ListViewItem>()
                                .Where(lvi => ((TaskListItem)lvi.Tag).Task.GetTaskNumber() == taskNr)
                                .Select(lvi => ((TaskListItem)lvi.Tag).Task))
                                .FirstOrDefault();
        }

        private void startTimer()
        {
            _currentTaskTimer = new Timer { Interval = 1000 };
            _currentTaskTimer.Tick += currentTaskTimer_Tick;
            _currentTaskTimer.Start();
        }

        private void clearTimer()
        {
            _currentTaskTimer.Stop();
            _currentTaskTimer.Tick -= currentTaskTimer_Tick;
            _currentTaskTimer = null;
        }

        void currentTaskTimer_Tick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processTimer);
        }

        void processTimer()
        {
            try
            {
                Cursor = Cursors.Default;

                if (_currentTaskDetails.TaskNr == null)
                    return;

                if (_currentTaskDetails.StartTime == null)
                {
                    setCurrentTaskDetails();
                    return;
                }

                var ts = _currentTaskDetails.TotalDuration + (_currentTaskDetails.StartTime.Value - DateTime.Now).Duration();
                lblCurrentTaskInfo.Text = getTimerText(ts);
                OnCurrentTaskTimerTicked(new CurrentTaskTimeEventArgs(ts));

            }
            catch (Exception)
            {
                clearTimer();
                throw;
            }
        }

        private string getTimerText(TimeSpan timeSpan)
        {
            return string.Format("Task #{0} [{1}h:{2}m:{3}s]",
                        _currentTaskDetails.TaskNr, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        protected virtual void OnCurrentTaskTimerTicked(CurrentTaskTimeEventArgs e)
        {
            if (CurrentTaskTimerTicked != null)
                CurrentTaskTimerTicked(this, e);
        }

        private void addSetupMenuItem()
        {
            var item = new ToolStripMenuItem("&Setup");
            item.Name = "SetupToolStripMenuItem";
            item.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            item.ForeColor = Color.Blue;
            item.Click += setupToolStripMenuItem_Click;
            menuStrip.Items.Add(item);
        }

        private void addTaskStatsMenuItem()
        {
            var item = new ToolStripMenuItem("Stat&istics");
            item.Name = "StatisticsToolStripMenuItem";
            item.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            item.ForeColor = Color.Blue;
            item.Click += statisticsToolStripMenuItem_Click;
            menuStrip.Items.Add(item);
        }

        private void togglePreviewBar()
        {
            var panelHeight = splitter.Height + 2;
            splitter.Visible = !splitter.Visible;
            lvw.Height += splitter.Visible ? -panelHeight : panelHeight;
            previewToolStripMenuItem.Text = splitter.Visible ? @"Hide Previe&w" : @"Show &Previe&w";
            previewTaskDetails(getSelectedTask());
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();

            ListView.Columns.Add(new iColumnHeader("Nr", "Number", 60));
            ListView.Columns.Add(new iColumnHeader("ParentTaskNr", "Parent", 60));
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Tag", 60));
            ListView.Columns.Add(new iColumnHeader("Priority", 70));
            ListView.Columns.Add(new iColumnHeader("Attachments", "A", 25));
            ListView.Columns.Add(new iColumnHeader("Comments", "C", 25));
            ListView.Columns.Add(new iColumnHeader("Status", 180));
        }

        protected virtual void OnTaskSearched(TaskSearchEventArgs e)
        {
            if (TaskSearched != null)
                TaskSearched(this, e);
        }

        private void hookEventHandlers()
        {
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
            uSearch.Search += uSearch_Search;
        }

        #endregion

        #region Setup Tool Stip menu item

        void setupToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            EventHandlerExecutor.Execute(processSetup);
        }

        void processSetup()
        {
            var f1 = new FOptions();
            f1.ShowDialog();
        }

        #endregion

        #region Statistics Tool Stip menu item

        void statisticsToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            EventHandlerExecutor.Execute(processStatistics);
        }

        void processStatistics()
        {
            var f1 = new FTaskStatistics();
            f1.ShowDialog();
        }

        #endregion

        #region Toggle search bar

        private void toggleSearchBar()
        {
            if (uSearch.Visible)
                hideSearchBar();
            else
                showSearchBar();
        }

        private void showSearchBar()
        {
            btnTaskNumber.Location = new Point(btnTaskNumber.Location.X, btnTaskNumber.Location.Y + uSearch.Height + 2);
            txtTaskNumber.Location = new Point(txtTaskNumber.Location.X, txtTaskNumber.Location.Y + uSearch.Height + 2);
            txt.Location = new Point(txt.Location.X, txt.Location.Y + uSearch.Height + 2);
            txtFullSearch.Location = new Point(txtFullSearch.Location.X, txtFullSearch.Location.Y + uSearch.Height + 2);
            btnFullSearch.Location = new Point(btnFullSearch.Location.X, btnFullSearch.Location.Y + uSearch.Height + 2);
            lvw.Height -= uSearch.Height + 2;
            lvw.Location = new Point(lvw.Location.X, lvw.Location.Y + uSearch.Height + 2);
            uSearch.Visible = true;
            searchToolStripMenuItem.Text = @"Hide Searc&h";
        }

        private void hideSearchBar()
        {
            btnTaskNumber.Location = new Point(btnTaskNumber.Location.X, btnTaskNumber.Location.Y - uSearch.Height - 2);
            txtTaskNumber.Location = new Point(txtTaskNumber.Location.X, txtTaskNumber.Location.Y - uSearch.Height - 2);
            txt.Location = new Point(txt.Location.X, txt.Location.Y - uSearch.Height - 2);
            txtFullSearch.Location = new Point(txtFullSearch.Location.X, txtFullSearch.Location.Y - uSearch.Height - 2);
            btnFullSearch.Location = new Point(btnFullSearch.Location.X, btnFullSearch.Location.Y - uSearch.Height - 2);
            lvw.Height += uSearch.Height + 2;
            lvw.Location = new Point(lvw.Location.X, lvw.Location.Y - uSearch.Height - 2);
            uSearch.Visible = false;
            searchToolStripMenuItem.Text = @"Show Searc&h";
        }

        #endregion

        #region Fill searched data

        void uSearch_Search(object sender, TaskSearchEventArgs e)
        {
            _criteria = e.Criteria;
            performSearch(e.Criteria);
            if (!ListView.HasItems())
                MessageBoxUtil.ShowMessage(
                    String.Format(Resources.NoTasksFoundForTheSearchCriteria, e.Criteria));
        }

        #endregion

        #region Selected

        protected override void OnItemSelected(PicklistItemEventArgs e)
        {
            OnTaskSelected(new TaskSelectedEventArgs(e.PicklistItem as Task));
            base.OnItemSelected(e);
        }

        protected virtual void OnTaskSelected(TaskSelectedEventArgs e)
        {
            if (TaskSelected != null)
                TaskSelected(this, e);
        }

        #endregion

        #region Open

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            var task = ((TaskListItem)e.PicklistItem).Task;
            showTaskForm(task);
            OnTaskOpened(new TaskSelectedEventArgs(task));
            base.OnItemOpened(e);
        }

        protected virtual void OnTaskOpened(TaskSelectedEventArgs e)
        {
            if (TaskOpened != null)
                TaskOpened(this, e);
        }

        #endregion

        #region Preview Task Details

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelectionChangedEvent, sender, e);
        }

        void processItemSelectionChangedEvent(object sender, EventArgs e)
        {
            var args = (ListViewItemSelectionChangedEventArgs)e;
            updateSelectedTaskUIStatus(args.IsSelected
                                        ? ((TaskListItem)args.Item.Tag).Task
                                        : null);

        }

        void updateSelectedTaskUIStatus(Task task)
        {
            setCommandButtonStates();
            previewTaskDetails(task);
        }

        #endregion

        #region Add Comment

        private void btnTaskComment_Click(object sender, EventArgs e)
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

            var task = getSelectedTask();
            var comment = TaskCommentEntity.New();
            comment.TaskId = task.Entity.Id;
            comment.Comment = args.Notes;
            comment.UserId = GravitySession.User.Entity.Id;

            new TaskComment(comment) { Task = task }.Save();
            OnCommentAdded(new TaskCommentEventArgs(comment));
        }

        private NotesFormArgs getTaskAddCommentFormArgs()
        {
            var task = getSelectedTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Comment on Task #{0}", task.GetTaskNumber());
            args.Title = string.Format("comment on '{0}'", task.Entity.Name);
            args.Required = true;
            return args;
        }

        protected virtual void OnCommentAdded(TaskCommentEventArgs e)
        {
            if (CommentAdded != null)
                CommentAdded(this, e);
        }

        #endregion

        #region Cancel task

        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancelTask);
        }

        void processCancelTask()
        {
            var task = getSelectedTask();
            if (!task.CanUpdateStatus(TaskUpdateAction.Cancel, GravitySession.User))
                return;

            var result = MessageBoxUtil.GetConfirmationYesNo(Resources.WantToCancelTask);
            if (result != DialogResult.Yes)
                return;

            var args = getTaskCancelReasonArgs();
            var notesForm = new FNotes(args);
            result = notesForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            task.Cancel(args.Notes, GravitySession.User);

            if (TaskExecution.GetCurrentTaskNr() == task.GetTaskNumber())
            {
                TaskExecution.ClearCurrentTask(TaskStatus.Cancelled.ToString());
                setCurrentTaskDetails();
            }

            if (task.Entity.Recurrence != null)
                TaskRecurrence.EvaluateRecurrence(task.Entity);

            removeSelectedTaskFromList();
            raiseTaskStatusUpdatedEvent(task);
        }

        private NotesFormArgs getTaskCancelReasonArgs()
        {
            var task = getSelectedTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Cancel reason of Task #{0}", task.GetTaskNumber());
            args.Title = string.Format("'{0}' task cancel reason", task.Entity.Name);
            args.Required = true;
            return args;
        }

        #endregion

        #region Make task done

        private void btnTaskDone_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompleteTask);
        }

        void processCompleteTask()
        {
            var task = getSelectedTask();
            if (!task.CanUpdateStatus(TaskUpdateAction.Complete, GravitySession.User))
                return;

            var result = MessageBoxUtil.GetConfirmationYesNo(Resources.SetTaskDone);
            if (result != DialogResult.Yes)
                return;

            task.Complete();

            if (TaskExecution.GetCurrentTaskNr() == task.GetTaskNumber())
            {
                TaskExecution.ClearCurrentTask(TaskStatus.Completed.ToString());
                setCurrentTaskDetails();
            }

            if (task.Entity.Recurrence != null)
                TaskRecurrence.EvaluateRecurrence(task.Entity);

            removeSelectedTaskFromList();
            raiseTaskStatusUpdatedEvent(task);
        }

        private void raiseTaskStatusUpdatedEvent(Task task)
        {
            OnTaskStatusUpdated(
                new TaskSavedEventArgs(task,
                    new CommandBarActionWrapper(CommandBarAction.Save)));
        }

        protected virtual void OnTaskStatusUpdated(TaskSavedEventArgs e)
        {
            if (TaskStatusUpdated != null)
                TaskStatusUpdated(this, e);
        }

        #endregion

        #region Show task description in separate window

        private void btnShowDescription_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showDescription);
        }

        private void showDescription()
        {
            new FNotes(getShowDescriptionArgs())
                .ShowDialog();
        }

        private NotesFormArgs getShowDescriptionArgs()
        {
            var task = getSelectedTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Task #{0} Description", task.GetTaskNumber());
            args.Title = task.Entity.Name;
            args.ReadOnly = true;
            args.Notes = task.Entity.Description;
            args.IsRtf = true;
            return args;
        }

        #endregion

        #region Show task comments in separate window

        private void btnShowComments_Click(object sender, EventArgs e)
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
            var task = getSelectedTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Task #{0} Comments", task.GetTaskNumber());
            args.Title = task.Entity.Name;
            args.ReadOnly = true;
            args.Notes = task.ToStringComments();
            return args;
        }

        #endregion

        #region Reopen task

        private void btnTaskReopen_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processReopenTask);
        }

        void processReopenTask()
        {
            var task = getSelectedTask();
            if (!task.CanUpdateStatus(TaskUpdateAction.Reopen, GravitySession.User))
                return;

            var result = MessageBoxUtil.GetConfirmationYesNo(Resources.WantToReopenTask);
            if (result != DialogResult.Yes)
                return;

            var args = getTaskReopenReasonArgs();
            var notesForm = new FNotes(args);
            result = notesForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            task.Reopen(args.Notes, GravitySession.User);

            updateSelectedTaskUIStatus(task);
            raiseTaskStatusUpdatedEvent(task);
        }

        private NotesFormArgs getTaskReopenReasonArgs()
        {
            var task = getSelectedTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Reopen reason of Task #{0}", task.GetTaskNumber());
            args.Title = string.Format("'{0}' task reopen reason", task.Entity.Name);
            args.Required = true;
            return args;
        }

        #endregion

        #region Update task progress

        private void btnUpdateProgress_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateProgress);
        }

        void updateProgress()
        {
            var task = getSelectedTask();
            if (task.Entity.CompletePct == (int)nudCompletePct.Value)
                return;

            task.Entity.CompletePct = (int)nudCompletePct.Value;
            task.UpdateProgress();

            updateTaskInList(task, getSelectedListViewItem());
            raiseTaskStatusUpdatedEvent(task);
        }

        #endregion

        #region Common

        private void setCommandButtonStates()
        {
            var taskIsSelected = ListView.HasOnlyOneItemSelected();

            btnCancelTask.Enabled = taskIsSelected;
            btnTaskDone.Enabled = taskIsSelected;
            btnTaskComment.Enabled = taskIsSelected;
            btnOK.Enabled = taskIsSelected;
            btnOpen.Enabled = taskIsSelected;
            btnTaskReopen.Enabled = taskIsSelected;
            btnUpdateProgress.Enabled = taskIsSelected;
            btnChecklist.Enabled = taskIsSelected;
            nudCompletePct.Enabled = taskIsSelected;
            newSubTaskToolStripMenuItem.Enabled = taskIsSelected;
            btnSetCurrentTask.Enabled = !_isMultipleLogin;

            if (taskIsSelected)
                setStatusCommandButtonStates();
        }

        private void setStatusCommandButtonStates()
        {
            var task = getSelectedTask();
            btnSetCurrentTask.Enabled = task.Entity.Status == TaskStatus.Pending && !_isMultipleLogin;
            btnTaskComment.Enabled = task.Entity.Status == TaskStatus.Pending;
            btnCancelTask.Enabled = task.CanCancel(GravitySession.User);
            btnTaskDone.Enabled = task.CanComplete(GravitySession.User);
            btnTaskReopen.Enabled = task.CanReopen(GravitySession.User);
            btnUpdateProgress.Enabled = task.CanComplete(GravitySession.User);
            nudCompletePct.Enabled = task.CanComplete(GravitySession.User);
            btnChecklist.Enabled = hasChecklistItemsForSelectedTask(task);
        }

        private bool hasChecklistItemsForSelectedTask(Task task)
        {
            return task.Entity.Checklist != null &&
                    task.Entity.Checklist.Items != null &&
                    task.Entity.Checklist.Items.Count > 0;
        }

        private void previewTaskDetails(Task task)
        {
            task = task ?? Task.New();
            nudCompletePct.Value = task.Entity.CompletePct;
            txtTaskInfo.Text = task.ToStringTaskInfo(GravitySession.User);
            setCurrentTaskButtonImage(task);
            if (!splitter.Visible)
                return;

            preview(task);
        }

        private void setCurrentTaskButtonImage(Task task)
        {
            btnSetCurrentTask.Image = task != null && _currentTaskDetails != null &&
                                        _currentTaskDetails.TaskNr != null &&
                                        task.GetTaskNumber() == _currentTaskDetails.TaskNr
                                                ? Resources.Pinned
                                                : Resources.UnPinned;
        }

        private void preview(Task task)
        {
            rtbDescription.RichText = task.Entity.Description;
            rtbComments.Text = task.ToStringComments();
            btnShowDescription.Enabled = rtbDescription.Text.Trim().Length > 0;
            btnShowComments.Enabled = rtbComments.Text.Trim().Length > 0;
        }

        private void performSearch(TaskSearchCriteria criteria)
        {
            Repository = new Tasks(criteria);
            FillList(true);
            updateTaskStatistics();
            setCommandButtonStates();
            previewTaskDetails(getSelectedTask());
            setStatusBarText(criteria.ToString());
            OnTaskSearched(new TaskSearchEventArgs(criteria));
        }

        private void updateTaskStatistics()
        {
            var repo = new TaskRepository();
            var taskStats = repo.GetTaskStatsByUser(GravitySession.User.Entity.Id);
            if (taskStats == null)
                return;

            taskStats.TotalInList = ListView.Items.Count;

            var mainForm = Parent as FMainBase;
            if (mainForm == null)
                return;

            mainForm.TaskStats =
                    new KeyValuePair<string, string>(
                            taskStats.ToString(), taskStats.ToToolTipString());
        }

        private void setStatusBarText(string text)
        {
            var mainForm = Parent as FMainBase;
            if (mainForm == null)
                return;

            mainForm.StatusBarText = text;
        }

        private Task getSelectedTask()
        {
            return ListView.HasOnlyOneItemSelected()
                    ? ((TaskListItem)ListView.SelectedItems[0].Tag).Task
                    : null;
        }

        private void removeSelectedTaskFromList()
        {
            if (_criteria.Status == TaskStatus.Pending)
            {
                var lvi = getSelectedListViewItem();
                var index = lvw.Items.IndexOf(lvi);
                lvw.Items.Remove(lvi);
                lvw.SelectItem(index + 1);
            }
        }

        private ListViewItem getSelectedListViewItem()
        {
            return ListView.HasOnlyOneItemSelected()
                            ? ListView.SelectedItems[0]
                            : null;
        }

        #endregion

        #region Show/hide Message box button

        public bool IsShowTaskMessageBoxButtonVisible()
        {
            return btnShowTaskMessageBox.Visible;
        }

        public bool IsMessageBoxOpen()
        {
            return messageBox.Visible;
        }

        public void RefreshMessageBox()
        {
            messageBox.RefreshList();
        }

        public void DisplayShowTaskMessageBoxButton()
        {
            btnShowTaskMessageBox.Visible = true;
        }

        #endregion

        #region Show message box

        private void btnShowTaskMessageBox_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processShowMessageBoxEvent);
        }

        void processShowMessageBoxEvent()
        {
            var result = messageBox.ShowDialog();
            if (result != DialogResult.OK)
                return;

            btnShowTaskMessageBox.Visible = false;
        }

        private void refreshList()
        {
            if (!string.IsNullOrWhiteSpace(txtFullSearch.Text))
                return;

            FillList(true);
            updateTaskStatistics();
            if (!ListView.HasItems())
                setCommandButtonStates();
        }

        #endregion

        #region Process shortcut keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var e = new KeyEventArgs(((Keys)((int)msg.WParam)) | ModifierKeys);
            return processKeyMessage(e);
        }

        private bool processKeyMessage(KeyEventArgs e)
        {
            if (processSetFocusToFullSearchKey(e))
                return true;

            if (processSearch(e))
                return true;

            if (processPreviewTaskKey(e))
                return true;

            if (processRefreshKey(e))
                return true;

            return false;
        }

        private bool processSetFocusToFullSearchKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Alt)
            {
                txtFullSearch.Focus();
                return true;
            }

            return false;
        }

        private bool processSearchBarKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
            {
                toggleSearchBar();
                uSearch.Focus();
                return true;
            }

            return false;
        }

        private bool processSearch(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.Control)
            {
                if (uSearch.Visible)
                    uSearch.btnSearch.PerformClick();

                return true;
            }

            return false;
        }

        private bool processPreviewTaskKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && e.Modifiers == Keys.None)
            {
                togglePreviewBar();
                return true;
            }

            return false;
        }

        private bool processRefreshKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && e.Modifiers == Keys.None)
            {
                refreshList();
                return true;
            }

            return false;
        }

        #endregion

        #region Menu strip actions

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(togglePreviewBar);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(toggleSearchBar);
        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showNewTaskForm);
        }

        void showNewTaskForm()
        {
            showTaskForm(Task.New());
        }

        private void showTaskForm(Task task)
        {
            var taskForm = new FTask(task);
            taskForm.TaskSaved += task_TaskSaved;

            taskForm.StartPosition = _taskWindowStartPosition;
            taskForm.WindowState = _taskWindowState;
            taskForm.Location = _taskWindowLocation;
            taskForm.Size = _taskWindowSize;

            taskForm.ShowDialog();
            taskForm.TaskSaved -= task_TaskSaved;

            _taskWindowStartPosition = taskForm.StartPosition;
            _taskWindowState = taskForm.WindowState;
            _taskWindowLocation = taskForm.Location;
            _taskWindowSize = taskForm.Size;
        }

        void task_TaskSaved(object sender, TaskSavedEventArgs e)
        {
            processTaskSavedAction(e);
        }

        void processTaskSavedAction(TaskSavedEventArgs e)
        {
            if (e.Task.WasNew)
            {
                var repo = new TaskRepository();
                var task = repo.GetFullDetailedTaskBy(e.Task.Entity.Id);
                lvw.Items.Insert(0, lvw.CreateListItem(new TaskListItem { Task = task }));
            }
            else
                updateTaskInList(e.Task, getListViewItemFromTask(e.Task));
        }

        ListViewItem getListViewItemFromTask(Task task)
        {
            return lvw.FindItemWithText(task.GetTaskNumber().PadLeft(12));
        }

        void updateTaskInList(Task task, ListViewItem lvi)
        {
            int index = lvw.Items.IndexOf(lvi);
            lvw.Items[index] = lvw.CreateListItem(new TaskListItem { Task = task });
            lvw.SelectItem(index);
        }

        #endregion

        #region Checklist viewing

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processTaskChecklist);
        }

        void processTaskChecklist()
        {
            var selectedTask = getSelectedTask();
            var taskChecklistForm = new FTaskChecklist(selectedTask);
            taskChecklistForm.ShowDialog();
        }

        #endregion

        #region New Subtask

        private void newSubTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showNewSubTaskForm);
        }

        void showNewSubTaskForm()
        {
            var task = Task.New();
            task.Parent = getSelectedTask();
            task.Entity.ParentId = task.Parent.Entity.Id;
            showTaskForm(task);
        }

        #endregion

        #region Set current task

        private void btnSetCurrentTask_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setCurrentTask);
        }

        void setCurrentTask()
        {
            var task = getSelectedTask();

            if (task == null && _currentTaskDetails != null && _currentTaskDetails.TaskNr != null)
                TaskExecution.RemoveCurrentTask(_currentTaskDetails.TaskNr);
            else
                TaskExecution.SetCurrentTask(task);

            setCurrentTaskDetails();
        }

        #endregion

        #region Halt current task when closing

        protected override void OnParentChanged(EventArgs e)
        {
            var parent = Parent as FMainBase;
            if (parent == null) return;
            parent.FormClosing += parent_FormClosing;
            setStatusBarText(new TaskSearchCriteria().ToString());
            updateTaskStatistics();
        }

        void parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(processFormClose, sender, e);
        }

        void processFormClose(object sender, EventArgs e)
        {
            var args = (FormClosingEventArgs)e;
            if (_reinitialize || _isMultipleLogin || args.Cancel)
                return;

            TaskExecution.HaltCurrentTask("Application closed");

            var settings = new Dictionary<string, object>();
            settings.Add(UserConfig.taskWindowStartPositionKey, _taskWindowStartPosition);
            settings.Add(UserConfig.taskWindowStateKey, _taskWindowState);
            settings.Add(UserConfig.taskWindowLocationKey, _taskWindowLocation);
            settings.Add(UserConfig.taskWindowSizeKey, _taskWindowSize);
            UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        #endregion

        #region Show reminder popup

        public void DisplayCurrentReminderWindow()
        {
            EventHandlerExecutor.Execute(processCurrentReminderWindow);
        }

        private void processCurrentReminderWindow()
        {
            reminderPopup.RefreshList();
            reminderPopup.DisplayReminder();
        }

        #endregion

        #region Show reminders

        private void btnReminders_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processReminders);
        }

        void processReminders()
        {
            var fReminders = new FReminders();
            fReminders.ShowDialog();
        }

        #endregion

        #region Show current task

        private void lblCurrentTaskInfo_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showCurrentTask);
        }

        void showCurrentTask()
        {
            if (lblCurrentTaskInfo.Tag == null)
                return;

            showTaskForm(lblCurrentTaskInfo.Tag as Task);
        }

        #endregion

        #region Search by task nr

        private void btnTaskNumber_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSearchTaskNumber);
        }

        private void processSearchTaskNumber()
        {
            if (string.IsNullOrWhiteSpace(txtTaskNumber.Text))
                return;

            var taskNr = Convert.ToInt32(txtTaskNumber.Text);
            if (taskNr == 0)
                return;

            var repo = new TaskRepository();
            var task = repo.GetTaskByNumber(taskNr);

            if (task == null)
                MessageBoxUtil.ShowMessage(string.Format(Resources.TaskNotFound, taskNr));
            else
                showTaskForm(task);
        }

        #endregion

        #region Full search on tasks

        private void txtFullSearch_KeyUp(object sender, KeyEventArgs e)
        {
            performFullSearchWhenEnterKey(e);
        }

        private void performFullSearchWhenEnterKey(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                btnFullSearch.PerformClick();
                txtFullSearch.Focus();
            }
        }

        private void btnFullSearch_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processFullSearchTask);
        }

        private void processFullSearchTask()
        {
            if (string.IsNullOrWhiteSpace(txtFullSearch.Text))
            {
                refreshList();
                return;
            }

            var repo = new TaskRepository();
            var tasks = repo.GetTasksContaining(txtFullSearch.Text.Trim());

            if (tasks == null || tasks.Count == 0)
            {
                if (showSuggestions())
                    return;

                MessageBoxUtil.ShowMessage(string.Format(Resources.NotTasksFound, txtFullSearch.Text.Trim()));
            }
            else
                lvw.FillData(tasks.Select(t => new TaskListItem { Task = t }));
        }

        private bool showSuggestions()
        {
            var repo = new TaskRepository();
            var suggestions = repo.GetSearchSuggestions(txtFullSearch.Text.Trim());

            if (suggestions.Count != 0)
            {
                var fSuggestions = new FSuggestions(txtFullSearch.Text.Trim());
                fSuggestions.Suggestions = suggestions.ToList();

                if (fSuggestions.ShowDialog() != DialogResult.OK)
                    return false;

                txtFullSearch.Text = fSuggestions.SelectedSuggestion;
                processFullSearchTask();
                return true;
            }
            return false;
        }

        #endregion

        #region SMS Pad

        private void smsPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showSmsPad);
        }

        private void showSmsPad()
        {
            var mPad = new FSmsPad(getSelectedTask());
            mPad.ShowDialog();
        }

        #endregion
    }
}
