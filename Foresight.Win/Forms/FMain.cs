using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Foresight.Win.Reports;
using System.Reflection;
using Gravity.Root.Enums;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Gravity.Root.Forms;
using Gravity.Root.Common;

namespace Foresight.Win.Forms
{
    public partial class FMain : FFormBase
    {
        #region Declarations

        private FCompanyGroups _coGroupsForm { get; set; }

        #endregion

        #region Properties

        public bool IsClosing { get; set; }

        #endregion

        #region Constructors

        public FMain(FCompanyGroups groupForm)
        {
            InitializeComponent();
            _coGroupsForm = groupForm;
        }

        #endregion

        #region Event Handlers

        private void FMain_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            lblUserName.Text = GravitySession.User.Entity.Name;
            populateReportsCommandBar();
            lvwCommandBar.SelectTopItem();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(processCloseReason, sender, e);
        }

        void processCloseReason(object sender, EventArgs e)
        {
            var args = e as FormClosingEventArgs;
            if (args.CloseReason != CloseReason.UserClosing)
                return;

            args.Cancel = MessageBoxUtil.GetConfirmationYesNo("Want to exit Foresight?") == DialogResult.No;
        }

        private void FMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHandlerExecutor.Execute(_coGroupsForm.Close);
        }

        private void FMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                closeActiveTabIfControlF4(e);
            }
            catch (Exception ex)
            {
                ExceptionProcessor.Process(ex);
            }
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processShowDialog);
        }

        void processShowDialog()
        {
            new FAbout().ShowDialog(this);
        }

        private void updateLedgersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyPeriods);
        }

        void processCompanyPeriods()
        {
            new FLedgerUpdater(ForesightSession.Dbc.GetCompanyPeriods()).ShowDialog(this);
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCompanyGroups);
        }

        void processCompanyGroups()
        {
            _coGroupsForm.Show();
            Hide();
        }

        private void pnlCommandBar_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandBarWidth);
        }

        void processCommandBarWidth()
        {
            lvwCommandBar.Columns[0].Width = lvwCommandBar.Width - 5;
        }

        private void lvwCommandBar_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(executeCommand);
        }

        private void lvwCommandBar_KeyDown(object sender, KeyEventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandBarModifierKey, sender, e);
        }

        void processCommandBarModifierKey(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;
            if (lvwCommandBar.SelectedItems.Count == 0)
                return;

            if (args.Modifiers != Keys.None)
                return;

            if (args.KeyCode == Keys.Enter)
                executeCommand();
        }

        #endregion

        //#region Public Methods

        //public void InitializeForm(bool isGroupChanged)
        //{
        //    if (isGroupChanged)
        //        tabMain.TabPages.Clear();

        //    setFormTitle();
        //    lvwCommandBar.SelectTopItem(true);
        //}

        //#endregion

        #region Internal Methods

        private void populateReportsCommandBar()
        {
            var reports = ForesightDatabaseFactory.GetInstance().GetAllCommands();

            foreach (var report in (from r in reports where r.IsActive select r))
                lvwCommandBar.Items.Add(report.Name).Tag = report;
        }

        private void closeActiveTabIfControlF4(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F4 || tabMain.TabCount == 0 || !e.Control || e.Shift || e.Alt)
                return;

            tabMain.TabPages.Remove(tabMain.SelectedTab);
        }

        private void setFormTitle()
        {
            Text = string.Format("{0} - {1}", 
                                ForesightSession.CompanyGroup.Entity.Name, 
                                GravityApplication.GetProductName());
            
            lblTitle.Text = ForesightSession.CompanyGroup.Entity.Name;
        }

        private Command getSelectedCommand()
        {
            return lvwCommandBar.SelectedItems[0].Tag as Command;
        }

        private void executeCommand()
        {
            var command = getSelectedCommand();

            if (command.Type == AppCommandType.Report)
            {
                if (isReportAlreadyOpened(command))
                    tabMain.SelectedTab = tabMain.TabPages[command.Nr.ToString()];
                else
                    showReport(createReportTabPage(command), getReportInstance(command));
            }
            else
            {
                var form = getUIInstanceOf(command);
                form.Show(this);
            }
        }

        private bool isReportAlreadyOpened(Command command)
        {
            return tabMain.TabPages.ContainsKey(command.Nr.ToString());
        }

        private TabPage createReportTabPage(Command command)
        {
            tabMain.TabPages.Add(command.Nr.ToString(), command.Name.PadRight(command.Name.Length + 10));
            return tabMain.TabPages[command.Nr.ToString()];
        }

        private void showReport(TabPage tab, UReportBase report)
        {
            tab.Controls.Add(report);
            report.BringToFront();
            report.Dock = DockStyle.Fill;
            report.Show();
            tabMain.SelectedTab = tab;
        }

        private UReportBase getReportInstance(Command command)
        {
            if (string.IsNullOrEmpty(command.UIControlName))
                throw new ValidationException("Under construction");

            return UReportBase.CreateInstance(command);
        }

        private Form getUIInstanceOf(Command command)
        {
            if (string.IsNullOrEmpty(command.UIControlName))
                throw new ValidationException("Under construction");

            var asm = Assembly.GetExecutingAssembly();
            return asm.CreateInstance("Foresight.Win.Reports." + command.UIControlName, true) as Form;
        }

        #endregion
    }
}
