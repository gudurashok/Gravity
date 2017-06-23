using System;
using System.Media;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Synergy.UC.Properties;

namespace Synergy.UC.Forms
{
    public partial class FReminderPopup : FFormBase
    {
        private Timer _timer;
        private SoundPlayer player;

        public FReminderPopup()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            setFormTitle();
            uReminderPopUp.Initialize();
            uReminderPopUp.Snooze += uReminder_Snooze;
            uReminderPopUp.Close += uReminder_Close;
            uReminderPopUp.StopSound += uReminderPopUp_StopSound;
            uReminderPopUp.ReminderItemOpened += uReminderPopUp_ReminderItemOpened;
            initializeReminderPlayer();
        }

        void uReminderPopUp_ReminderItemOpened(object sender, EventArgs e)
        {
            TopMost = false;
        }

        void uReminderPopUp_StopSound(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void initializeReminderPlayer()
        {
            player = new SoundPlayer();
            player.Stream = Resources.ALARM;
        }

        private void uReminder_Snooze(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSnooze);
        }

        private void processSnooze()
        {
            Hide();
            startTimer();
            player.Stop();
        }

        private void startTimer()
        {
            if (uReminderPopUp.SnoozeMinutes == 0)
                return;

            _timer = new Timer { Interval = uReminderPopUp.SnoozeMinutes * 60 * 1000 };
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSnoozeTimer);
        }

        private void processSnoozeTimer()
        {
            if (uReminderPopUp.SnoozeMinutes == 0)
                return;

            clearSnooze();
            refreshList();

            if (!uReminderPopUp.ListView.HasItems())
                return;

            DisplayReminder();
        }

        public void DisplayReminder()
        {
            Show();
            player.PlayLooping();
        }

        private void clearSnooze()
        {
            if (_timer != null)
                _timer.Tick -= timer_Tick;

            uReminderPopUp.SnoozeMinutes = 0;
        }

        private void uReminder_Close(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(Close);
        }

        private void setFormTitle()
        {
            Text = @"Your task reminders";
            lblTitle.Text = @"Task reminders";
        }

        protected override void OnActivated(EventArgs e)
        {
            EventHandlerExecutor.Execute(refreshList);
        }

        public void RefreshList()
        {
            EventHandlerExecutor.Execute(refreshList);
        }

        private void refreshList()
        {
            Cursor = Cursors.Default;
            uReminderPopUp.RefreshList();
            if (!uReminderPopUp.ListView.HasItems()) Close();
            if (_timer == null) return;
            clearSnooze();
        }

        private void FReminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(processClosing, sender, e);
        }

        void processClosing(object sender, EventArgs e)
        {
            player.Stop();
            var args = (FormClosingEventArgs)e;
            args.Cancel = true;
            uReminderPopUp.btnSnooze.PerformClick();
        }
    }
}
