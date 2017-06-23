using System.Windows.Forms;
using Gravity.Root.Forms;
using Scalable.Win.Common;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Controls;
using Synergy.UC.Forms;
using MingleSysConfig = Mingle.Domain.Model.SysConfig;

namespace Synergy.Win.Forms
{
    public partial class FMain : FMainBase
    {
        //private FRadar radar;

        #region Constructor

        private FMain()
        {
            InitializeComponent();
        }

        public FMain(ScalableApplicationBase application)
            : this()
        {
            Application = application;
        }

        #endregion

        #region Initialization

        protected override void InitializeForm()
        {
            base.InitializeForm();
            var repo = new TaskRepository();
            MenuItems = repo.GetAllAppMenuItems();
            SetMenuStripItems();
            ShowDefaultForm("Tasks");
            checkForNewMessages();
            //radar = new FRadar();
            //radar.Show();
            Application.HideSplash2();
        }

        private void checkForNewMessages()
        {
            if (!TaskMessage.HasAnyNewMessagesForCurrentUser())
                return;

            ((UTasks)AppActiveControl).DisplayShowTaskMessageBoxButton();
#if !DEBUG
            showBalloonTip();
#endif
        }

        #endregion

        #region Set form title

        protected override void SetFormTitle()
        {
            base.SetFormTitle();
            lblAdditionalInfo.Text = MingleSysConfig.CoGroupParty.ToStringLocation();

            //var repo = new TaskRepository();
            //MessageBox.Show(repo.GetTaskCountByUser(GravitySession.User.Entity.Id).ToString());
        }

        #endregion

        //void uTasks_TaskSearched(object sender, TaskSearchEventArgs e)
        //{
        //    EventHandlerExecutor.Execute(displaySearchCriteria, sender, e);
        //}

        //void displaySearchCriteria(object sender, EventArgs e)
        //{
        //    var args = e as TaskSearchEventArgs;
        //    toolStripStatusLabel.Text = args.Criteria.ToString();
        //}

        #region Process message box operations

        protected override void ProcessPollingTimerTick()
        {
            var tasks = AppActiveControl as UTasks;

            if (tasks == null)
                return;

            processMessages(tasks);
            processReminders();

            base.ProcessPollingTimerTick();
        }

        private void processReminders()
        {
            checkForNewReminders();
        }

        private void checkForNewReminders()
        {
            if (!TaskReminder.HaveAnyNewRemindersForCurrentUser())
                return;

            ((UTasks)AppActiveControl).DisplayCurrentReminderWindow();
        }

        private void processMessages(UTasks tasks)
        {
            if (tasks.IsShowTaskMessageBoxButtonVisible())
            {
                if (!tasks.IsMessageBoxOpen())
                    return;

                tasks.RefreshMessageBox();
                return;
            }

            checkForNewMessages();
        }

        #endregion

        #region Create new FAbout form

        protected override Form getAboutForm()
        {
            return new FAbout();
        }

        #endregion

        #region Show Balloon tip

#if !DEBUG
        private void showBalloonTip()
        {
            showBalloonTip(@"You have new messages.");
        }
#endif

        #endregion
    }
}

