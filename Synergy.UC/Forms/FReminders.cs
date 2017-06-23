using Scalable.Shared.Common;
using Scalable.Win.Forms;

namespace Synergy.UC.Forms
{
    public partial class FReminders : FFormBase
    {
        public FReminders()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            uReminders.Initialize();
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = @"All Reminders";
            lblTitle.Text = @"All reminders";
        }

        private void FReminders_Activated(object sender, System.EventArgs e)
        {
            EventHandlerExecutor.Execute(processFormActivated);
        }

        void processFormActivated()
        {
            uReminders.RefreshForm();
        }
    }
}
