using System;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;
using Synergy.UC.Properties;

namespace Synergy.UC.Controls
{
    public partial class UCurrentTaskDuration : UFormBase
    {
        private TaskExecutionEntity _taskExecution;
        public event EventHandler DurationSet;

        public UCurrentTaskDuration()
        {
            InitializeComponent();
        }

        public override object DataSource
        {
            get
            {
                return _taskExecution;
            }
            set
            {
                _taskExecution = value as TaskExecutionEntity;
            }
        }

        public void Initialize(string taskNr)
        {
            lblMessage.Text = string.Format(Resources.CurrentTaskPreviousDuration, taskNr);
        }

        protected override void OnLoad(EventArgs e)
        {
            dtpDuration.Value = DateTime.Today.Date;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var executions = _taskExecution.Executions.Where(ex => !ex.StoppedAt.HasValue);

            foreach (var execution in executions)
            {
                var stopTime = getStoppedTime(execution);
                if (stopTime == null)
                    return;

                execution.StoppedAt = stopTime;
                execution.Notes = "System Recovered";

                var repo = new TaskRepository();
                repo.Save(_taskExecution);
            }

            OnDurationSet(EventArgs.Empty);
        }

        private DateTime? getStoppedTime(ExecutionEntity execution)
        {
            var totalDuration = execution.StartedAt + getDuration();

            if (execution.StartedAt == totalDuration)
                return DateTime.Now;

            if (totalDuration > DateTime.Now)
            {
                var dialogResult = MessageBoxUtil.GetConfirmationOKCancel(Resources.ExceedingCurrentTaskDuration);
                return dialogResult != DialogResult.OK ? (DateTime?)null : DateTime.Now;
            }

            return totalDuration;
        }

        private TimeSpan getDuration()
        {
            return (dtpDuration.Value - DateTime.Today.Date).Duration();
        }

        protected virtual void OnDurationSet(EventArgs e)
        {
            if (DurationSet != null)
                DurationSet(this, e);
        }
    }
}
