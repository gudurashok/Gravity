﻿using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Insight.Domain.Common;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using InsightEntityListRepository = Insight.UC.Common.EntityListRepository;
using Insight.UC.Controls;

namespace Insight.Win.Forms
{
    public partial class FMain : FMainBase
    {
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

        private void selectCompanyPeriod()
        {
            var companyPeriod = PicklistFactory.CompanyPeriods.Form;
            companyPeriod.Initialize();
            companyPeriod.uPicklist.FillList(true);

            if (companyPeriod.ShowDialog() != DialogResult.OK)
                return;

            InsightSession.CompanyPeriod = ((CompanyPeriodListItem)companyPeriod.PicklistItems[0]).CompanyPeriod;
            SetFormTitle();
            RefreshAllLists();
        }

        protected override void RefreshAllLists()
        {
            foreach (var control in Controls.Cast<object>()
                                            .Where(control => (control as UVouchers) != null))
            {
                var uVouchers = ((UVouchers)control);
                uVouchers.InitializeList();
            }

            base.RefreshAllLists();
        }

        #region Initialization

        protected override void InitializeForm()
        {
            Hide();
            selectCompanyPeriod();

            if (InsightSession.CompanyPeriod == null)
            {
#if !DEBUG
                IsAppExit = true;
#endif
                Close();
                return;
            }

            base.InitializeForm();
            addCompanyPeriodMenuItem();
            MenuItems = InsightRepository.GetAllAppMenuItems();
            SetMenuStripItems();
            Show();

            if (GravitySession.User.Entity.IsAdmin)
                addSetupMenuItem();

            Application.HideSplash2();

            ShowDefaultForm("Tasks");
        }

        private void addCompanyPeriodMenuItem()
        {
            var item = new ToolStripMenuItem("Company Perio&d");
            item.Name = "CoPeriodToolStripMenuItem";
            item.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            item.Click += coPeriodMenuItem_Click;
            mainMenuStrip.Items.Add(item);
        }

        #region Change company period

        void coPeriodMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(selectCompanyPeriod);
        }

        #endregion

        private void addSetupMenuItem()
        {
            var item = new ToolStripMenuItem("&Setup");
            item.Name = "SetupToolStripMenuItem";
            item.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            item.ForeColor = Color.Blue;
            item.Click += setupToolStripMenuItem_Click;
            mainMenuStrip.Items.Add(item);
        }

        protected override void SetFormTitle()
        {
            Text = getFormTitle();
            lblTitle.Text = getTitle();
            lblAdditionalInfo.Text = getAdditionalInfo();
        }

        private static string getTitle()
        {
            var company = InsightSession.CompanyPeriod.Company.Entity;
            var coFinPeriod = InsightSession.CompanyPeriod.Period.Entity.Financial;
            return $"{company.Name} ({coFinPeriod.ToYearString()})";
        }

        private static string getAdditionalInfo()
        {
            return InsightSession.CompanyPeriod.Company.Party.ToStringLocation();
        }

        private string getFormTitle()
        {
            var company = InsightSession.CompanyPeriod.Company.Entity;
            var coFinPeriod = InsightSession.CompanyPeriod.Period.Entity.Financial;
            return $"{company.Name} [{coFinPeriod.ToYearString()}] " +
                   $"[{GravityApplication.GetProductName()}] [{getLoginUserName()}]";
        }

        private string getLoginUserName()
        {
            var user = GravitySession.User.Entity;
            return $"{user.Name} ({user.Designation})";
        }

        #endregion

        #region Set Tool Stip menu item

        void setupToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            EventHandlerExecutor.Execute(processSetup);
        }

        void processSetup()
        {
            var optionsForm = new FOptions(new InsightEntityListRepository());
            optionsForm.ShowDialog();
        }

        #endregion

        #region Polling timer tick

        protected override void ProcessPollingTimerTick()
        {
        }

        #endregion
    }
}

