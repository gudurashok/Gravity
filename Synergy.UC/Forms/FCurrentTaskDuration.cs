using System;
using System.Windows.Forms;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FCurrentTaskDuration : FFormBase
    {
        private readonly string _taskNr;
        
        public FCurrentTaskDuration()
        {
            InitializeComponent();
            _taskNr = TaskExecution.GetCurrentTaskNr();
            initialize();
        }

        private void initialize()
        {
            setFormTiTle();
            uCurrentTaskDuration.Initialize(_taskNr);
            uCurrentTaskDuration.DurationSet += uCurrentTaskDuration_DurationSet;
        }

        private void setFormTiTle()
        {
            Text = string.Format("Task #{0} previous duration", _taskNr);
            lblTitle.Text = string.Format("Enter Task #{0} previous duration", _taskNr);
        }

        public FCurrentTaskDuration(TaskExecutionEntity entity)
            : this()
        {
            uCurrentTaskDuration.DataSource = entity;
        }

        void uCurrentTaskDuration_DurationSet(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
