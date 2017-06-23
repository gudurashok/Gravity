using System;
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

        #region Initialization

        protected override void InitializeForm()
        {
            Hide();
            selectCompanyPeriod();

            if (InsightSession.CompanyPeriod == null)
            {
                Close();
                return;
            }

            base.InitializeForm();
            addCompanyPeriodMenuItem();
            var repo = new InsightRepository();
            MenuItems = repo.GetAllAppMenuItems();
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
            Text = getText();
            lblTitle.Text = getTitle();
            lblAdditionalInfo.Text = getAditionalInfo();
        }

        private static string getTitle()
        {
            return string.Format("{0} ({1})", InsightSession.CompanyPeriod.Company.Entity.Name,
                                 InsightSession.CompanyPeriod.Period.Entity.Financial.ToYearString());

        }

        private static string getAditionalInfo()
        {
            return InsightSession.CompanyPeriod.Company.Party.ToStringLocation();
        }

        private string getText()
        {
            return string.Format("{0} [{1}] [{2}] [{3}]",
                                 InsightSession.CompanyPeriod.Company.Entity.Name,
                                 InsightSession.CompanyPeriod.Period.Entity.Financial.ToYearString(),
                                 GravityApplication.GetProductName(),
                                 getLoginUserName());
        }

        private string getLoginUserName()
        {
            return string.Format("{0} ({1})",
                                GravitySession.User.Entity.Name,
                                GravitySession.User.Entity.Designation);
        }

        #endregion

        #region Set Tool Stip menu item

        void setupToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            EventHandlerExecutor.Execute(processSetup);
        }

        void processSetup()
        {
            var f1 = new FOptions(new InsightEntityListRepository());
            f1.ShowDialog();
        }

        #endregion

        #region Polling timer tick

        protected override void ProcessPollingTimerTick()
        {
        }

        #endregion
    }
}

