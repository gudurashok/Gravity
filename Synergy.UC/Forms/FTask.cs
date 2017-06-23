using System;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Synergy.Domain.Model;
using Synergy.UC.Events;

namespace Synergy.UC.Forms
{
    public partial class FTask : FFormBase
    {
        #region Declarations

        private Task _task;

        public event EventHandler<TaskSavedEventArgs> TaskSaved;

        #endregion

        #region Constructors

        public FTask()
        {
            InitializeComponent();
        }

        public FTask(Task task)
            : this()
        {
            _task = task;
        }

        #endregion

        #region Load

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            setFormTitle();
            uTask.Initialize();
            uTask.DataSource = _task;
            uTask.TaskSaved += uTask_TaskSaved;
        }

        private void setFormTitle()
        {
            Text = string.Format("Task: {0}", getFormTitle());
            lblTitle.Text = getTitleText();
        }

        private string getFormTitle()
        {
            return _task.IsNew() ? "New Task" : string.Format("#{0} ", _task.GetTaskNumber());
        }

        private string getTitleText()
        {
            return _task.IsNew() ? "Enter new task details" : _task.Entity.Name;
        }

        #endregion

        #region Task Save

        private void uTask_TaskSaved(object sender, TaskSavedEventArgs e)
        {
            processTaskSavedAction(e);
        }

        void processTaskSavedAction(TaskSavedEventArgs e)
        {
            _task = e.Task;

            if (e.Action.IsClose())
                Close();
            else
                setFormTitle();

            OnTaskSaved(e);
        }

        void OnTaskSaved(TaskSavedEventArgs taskSavedEventArgs)
        {
            if (TaskSaved != null)
                TaskSaved(this, taskSavedEventArgs);
        }

        #endregion
    }
}
