using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Gravity.Root.Controls;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using Gravity.Root.Common;

#if !DEBUG
using Gravity.Root.Properties;
#endif

namespace Gravity.Root.Forms
{
    public partial class FMainBase : FFormBase
    {
        #region Declarations

        public KeyValuePair<string, string> TaskStats
        {
            set
            {
                lblTaskStats.Text = value.Key;
                toolTip.SetToolTip(lblTaskStats, value.Value);
            }
        }

        public string StatusBarText
        {
            set
            {
                statusStripBar.Items.Clear();
                statusStripBar.Items.Add(value);
            }
        }

        protected ScalableApplicationBase Application;
        protected UBaseForm AppActiveControl;
        protected IList<AppMenuItemEntity> MenuItems;

#if !DEBUG
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _exitToolStripMenuItem;
        public bool IsAppExit;
#endif

        #endregion

        #region Constructor

        protected FMainBase()
        {
            InitializeComponent();
        }

        public FMainBase(ScalableApplicationBase application)
            : this()
        {
            Application = application;
        }

        #endregion

        #region Loading

        void FMainBase_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(InitializeForm);
        }

        protected virtual void InitializeForm()
        {
            hideCoGroupSelectionMenuItemIfEmbedded();
            mainMenuStrip.BringToFront();
            lnkUsers.BringToFront();
            lnkUsers.Visible = GravitySession.User.Entity.IsAdmin;
            lnkFeedback.BringToFront();
            lnkRefresh.BringToFront();
            lnkAbout.BringToFront();
            lnkExit.BringToFront();

            displayLoginUserName();
            SetFormTitle();
            setupPollingTimer();
#if !DEBUG
            setupNotifyIcon();
#endif
        }

        private void hideCoGroupSelectionMenuItemIfEmbedded()
        {
            companyGroupToolStripMenuItem.Visible = false; //TODO: (AppConfig.AppGenus != Genus.Embedded);
        }

        protected void SetMenuStripItems()
        {
            foreach (var menuItem in MenuItems)
                mainMenuStrip.Items.Add(getMenuStripItem(menuItem));
        }

        private ToolStripMenuItem getMenuStripItem(AppMenuItemEntity menuItem)
        {
            if (string.IsNullOrEmpty(menuItem.Name))
                throw new ValidationException("Under construction");

            return createInstance(menuItem);
        }

        private ToolStripMenuItem createInstance(AppMenuItemEntity menuItem)
        {
            var item = new ToolStripMenuItem();
            item.Name = string.Format("{0}ToolStripMenuItem", menuItem.Name);
            item.Text = menuItem.Caption;
            item.Font = menuItem.Font;
            item.ShortcutKeys = menuItem.ShortcutKeys;
            item.Tag = menuItem;
            item.Click += menuItem_Click;
            return item;
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            mainMenuStrip.HighlightMenuItem((ToolStripItem)sender);
            var itemEntity = (AppMenuItemEntity)((ToolStripMenuItem)sender).Tag;
            if (findControlByName(itemEntity.UIControlName) != null)
                return;

            AppActiveControl = getUIInstanceOf(itemEntity);
            setControlLayout();
        }

        private UBaseForm getUIInstanceOf(AppMenuItemEntity menuItem)
        {
            if (string.IsNullOrEmpty(menuItem.UIControlName))
                throw new ValidationException("Under construction");

            var path = string.Format("{0}\\{1}", AppConfig.AppPath, menuItem.UIAssembly);
            var asm = Assembly.LoadFrom(path);
            var entityListControl = asm.CreateInstance(string.Format("{0}.{1}", menuItem.UIControlPath, menuItem.UIControlName), true) as UPicklist;

            if (entityListControl != null)
            {
                entityListControl.Initialize();
                entityListControl.MakeList();
            }

            return entityListControl;
        }

        private void displayLoginUserName()
        {
            lblUserName.Text = getLoginUserName();
        }

        private UBaseForm findControlByName(string name)
        {
            if (AppActiveControl != null)
                AppActiveControl.Visible = false;

            AppActiveControl = (UBaseForm)Controls.Find(name, false).FirstOrDefault();

            if (AppActiveControl != null)
                AppActiveControl.Visible = true;

            return AppActiveControl;
        }

        private void setControlLayout()
        {
            if (AppActiveControl == null) return;

            AppActiveControl.BorderStyle = BorderStyle.FixedSingle;
            AppActiveControl.Location = new Point(-1, mainMenuStrip.Location.Y + mainMenuStrip.Height - 3);
            AppActiveControl.Width = ClientSize.Width + 2;
            AppActiveControl.Height = ClientSize.Height + 1 - pnlHeader.Height - (mainMenuStrip.Height - 3) - statusStripBar.Height;
            AppActiveControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AppActiveControl.Visible = true;
            Controls.Add(AppActiveControl);
            AppActiveControl.BringToFront();
        }

        #endregion

        #region Polling Timer

        private void setupPollingTimer()
        {
            pollingTimer = new Timer();
            pollingTimer.Interval = AppConfig.ListRefreshPollingIntervalInMilliseconds;
            pollingTimer.Tick += pollingTimer_Tick;
            pollingTimer.Start();
        }

        void pollingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ProcessPollingTimerTick();
            }
            catch (Exception ex)
            {
                processPollingTimerTickException(ex);
            }
        }

        private void processPollingTimerTickException(Exception ex)
        {
            pollingTimer.Stop();
            MessageBoxUtil.ShowError(ex);
            GravitySession.Application.SkipSaveUserConfig = true;
#if !DEBUG
            IsAppExit = true;
#endif
            Close();
        }

        protected virtual void ProcessPollingTimerTick()
        {
            //TODO: must be overriden by child if needed
        }

        #endregion

#if !DEBUG

        #region SysTray Notify Icon

        private void setupNotifyIcon()
        {
            _notifyIcon = new NotifyIcon(components);
            _contextMenuStrip = new ContextMenuStrip(components);
            _exitToolStripMenuItem = new ToolStripMenuItem();

            _notifyIcon.ContextMenuStrip = _contextMenuStrip;
            _notifyIcon.Icon = Resources.notifyIcon;
            _notifyIcon.Text = string.Format("{0} - User: {1} ", GravityApplication.GetProductName(), GravitySession.User.Entity.Name);
            _notifyIcon.Visible = true;

            _contextMenuStrip.Items.AddRange(new ToolStripItem[] {
            _exitToolStripMenuItem});
            _contextMenuStrip.Name = "contextMenuStrip";
            _contextMenuStrip.Size = new Size(153, 48);

            _exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            _exitToolStripMenuItem.Size = new Size(152, 22);
            _exitToolStripMenuItem.Text = @"&Exit";

            _notifyIcon.MouseClick += niSynergy_MouseClick;
            _exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            lnkExit.LinkClicked += lnkExit_LinkClicked;
        }

        private void niSynergy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
        }

        private void showBalloonTip()
        {
            showBalloonTip(string.Format("{0} has been minimized", GravityApplication.GetProductName()));
        }

        protected void showBalloonTip(string text)
        {
            _notifyIcon.BalloonTipTitle = GravityApplication.GetProductName();
            _notifyIcon.BalloonTipText = text;
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.ShowBalloonTip(1000);
        }

        #endregion

        #region Exit Program

        private void lnkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processAppExist);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAppExist);
        }

        private void processAppExist()
        {
            if (MessageBoxUtil.GetConfirmationYesNo(
                        string.Format(Resources.WantToExistApp,
                                GravityApplication.GetProductName())) == DialogResult.No)
                return;

            IsAppExit = true;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(ProcessFormClosing, this, e);
            base.OnFormClosing(e);
        }

        private void ProcessFormClosing(object sender, EventArgs e)
        {
            var args = (FormClosingEventArgs)e;
            if (IsAppExit || args.CloseReason != CloseReason.UserClosing)
                return;

            args.Cancel = true;
            Hide();
            showBalloonTip();
        }

        #endregion

#endif

        #region Show Company Groups

        private void companyGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processShowCompanyGroups);
        }

        private void processShowCompanyGroups()
        {
            //GravitySession.InitializeRootStoreManager();
            var coGroupsForm = new FCompanyGroups();
            coGroupsForm.uCompanyGroups.CoGroupSelected += uCompanyGroups_CoGroupSelected;
            var result = coGroupsForm.ShowDialog();
            coGroupsForm.uCompanyGroups.CoGroupSelected -= uCompanyGroups_CoGroupSelected;
            if (result == DialogResult.OK)
                resetCoGroupInfo();
            //else
            //    GravitySession.OpenCompanyGroupDatabase();
        }

        private void resetCoGroupInfo()
        {
            SetFormTitle();
            OnCoGroupOpened();
        }

        private void uCompanyGroups_CoGroupSelected(object sender, CoGroupSelectedEventArgs e)
        {
            OnCoGroupSelected(e);
        }

        protected virtual void OnCoGroupSelected(CoGroupSelectedEventArgs e)
        {
            var coGroupForm = new FCompanyGroupBase(e.CompanyGroup);
            coGroupForm.ShowDialog();
        }

        #endregion

        #region Show About

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processShowAbout);
        }

        void processShowAbout()
        {
            getAboutForm().ShowDialog(this);
        }

        protected virtual Form getAboutForm()
        {
            return new FAbout();
        }

        #endregion

        #region Feedback

        private void lnkFeedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processFeedback);
        }

        void processFeedback()
        {
            new FUserFeedback().Show();
        }

        #endregion

        #region Refresh

        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(OnRefreshList);
        }

        protected virtual void OnCoGroupOpened()
        {
            OnRefreshList();
        }

        protected virtual void OnRefreshList()
        {
            var result = AppActiveControl as UListView;

            if (result != null)
                result.FillList(true);
        }

        protected void RefreshAllLists()
        {
            foreach (var control in Controls.Cast<object>().Where(control => (control as UListView) != null))
                ((UListView)control).FillList(true);
        }

        #endregion

        #region Common

        private string getLoginUserName()
        {
            return string.Format("{0} ({1})",
                                GravitySession.User.Entity.Name,
                                GravitySession.User.Entity.Designation);
        }

        protected virtual void SetFormTitle()
        {
            Text = string.Format("{0} - {1} [{2}]",
                                GravitySession.CompanyGroup.Entity.Name,
                                GravityApplication.GetProductName(),
                                getLoginUserName());

            lblTitle.Text = GravitySession.CompanyGroup.Entity.Name;
        }

        protected void ShowDefaultForm(string name)
        {
            var item = mainMenuStrip.Items
                        .Cast<ToolStripItem>()
                        .SingleOrDefault(i => i.Name.StartsWith(name));
            if (item == null) return;
            item.PerformClick();
            AppActiveControl.Select();
        }

        #endregion

        #region User creation options

        private void lnkUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processUsers);
        }

        void processUsers()
        {
            if (findControlByName("Users") != null)
                return;

            var users = new UUsers();
            users.Name = "Users";
            users.Initialize();
            users.MakeList();
            AppActiveControl = users;
            setControlLayout();
        }

        #endregion
    }
}
