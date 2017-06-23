using System;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.Domain.ViewModel;
using Synergy.UC.Forms;

namespace Synergy.UC.Controls
{
    public partial class UMessageBox : UPicklist
    {
        #region Declarations

        public event EventHandler Close;

        #endregion

        #region Constructor

        public UMessageBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialization

        public override void Initialize()
        {
            MakeList();
            SearchProperty = "TaskName";
            buildColumns();
            Repository = new TaskMessages();
            FillList();
            hookEventHandlers();
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("TaskNumber", "Nr.", 60));
            ListView.Columns.Add(new iColumnHeader("TaskName", "Task name", true));
            ListView.Columns.Add(new iColumnHeader("Type", "Update type", 90));
            ListView.Columns.Add(new iColumnHeader("ByUserName", "From", 100));
            ListView.Columns.Add(new iColumnHeader("DateTime", "Date and Time", 135));
        }

        private void hookEventHandlers()
        {
            ListView.SelectedIndexChanged += ListView_SelectedIndexChanged;
        }

        #endregion

        #region Open selected task

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            EventHandlerExecutor.Execute(openSelectedTask);
        }

        private void openSelectedTask()
        {
            var task = getSelectedMessageTask();
            var taskForm = new FTask(task);
            taskForm.ShowDialog();
        }

        private Task getSelectedMessageTask()
        {
            var message = getSelectedTaskMessage();
            return Task.GetTaskBy(message.Entity.TaskId);
        }

        #endregion

        #region Read single message

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteSelectedMessage);
        }

        private void deleteSelectedMessage()
        {
            TaskMessage.DeleteMessageOfCurrentUser(getSelectedTaskMessage());
            refreshList();

            if (!ListView.HasItems())
                OnClose(new EventArgs());
        }

        #endregion

        #region Read all messages

        private void btnDismissAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteAllMessages);
        }

        private void deleteAllMessages()
        {
            TaskMessage.DeleteAllMessagesOfCurrentUser();
            OnClose(new EventArgs());
        }

        #endregion

        #region Acknowledge single message

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(acknowledgeSelectedMessage);
        }

        private void acknowledgeSelectedMessage()
        {
            TaskMessage.SendAcknowledgement(getSelectedTaskMessage());
            deleteSelectedMessage();
        }

        #endregion

        #region Acknowledge all messages

        private void btnAcknowledgeAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(acknowledgeAllMessages);
        }

        private void acknowledgeAllMessages()
        {
            TaskMessage.SendAcknowledgementForAllMessages();
            TaskMessage.DeleteAllNonAcknowledgementMessages();
            OnClose(new EventArgs());
        }

        #endregion

        #region Enable/disable buttons

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setCommandButtonsState);
        }

        #endregion

        #region Common

        private void refreshList()
        {
            FillList(true);
            setCommandButtonsState();
        }

        private TaskMessage getSelectedTaskMessage()
        {
            return new TaskMessage(((MessageListItem)ListView.SelectedItems[0].Tag).Entity);
        }

        private void setCommandButtonsState()
        {
            if (!ListView.HasAnyItemsSelected())
            {
                btnOK.Enabled = false;
                btnDismiss.Enabled = false;
                btnAcknowledge.Enabled = false;
                btnAcknowledgeAll.Enabled = false;
                btnComment.Enabled = false;
                return;
            }

            btnOK.Enabled = true;
            btnDismiss.Enabled = true;

            var message = getSelectedTaskMessage();
            btnAcknowledge.Enabled = message.Entity.Type != TaskUpdateType.Acknowledged;
            btnAcknowledgeAll.Enabled = isNotAllAcknowledgements();
            btnComment.Enabled = getSelectedMessageTask().Entity.Status == TaskStatus.Pending;
        }

        private bool isNotAllAcknowledgements()
        {
            return ListView.Items.Cast<ListViewItem>()
                       .Count(lvi => (((MessageListItem)lvi.Tag)).Entity.Type != TaskUpdateType.Acknowledged) > 0;
        }

        protected virtual void OnClose(EventArgs e)
        {
            if (Close != null)
                Close(this, e);
        }

        #endregion

        private void btnComment_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddComment);
        }

        void processAddComment()
        {
            var args = getTaskNotesArgs();
            var notesForm = new FNotes(args);
            var result = notesForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var task = getSelectedMessageTask();
            var comment = TaskCommentEntity.New();
            comment.TaskId = task.Entity.Id;
            comment.Comment = args.Notes;
            comment.UserId = GravitySession.User.Entity.Id;

            new TaskComment(comment) { Task = task }.Save();
        }

        private NotesFormArgs getTaskNotesArgs()
        {
            var task = getSelectedMessageTask();
            var args = new NotesFormArgs();
            args.Caption = string.Format("Comment on Task #{0}", task.GetTaskNumber());
            args.Title = string.Format("comment on '{0}'", task.Entity.Name);
            args.Required = true;
            return args;
        }
    }
}
