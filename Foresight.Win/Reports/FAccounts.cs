using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Foresight.Logic.DataAccess;
using Foresight.Win.Common;
using Insight.Domain.Enums;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class FAccounts : Form
    {
        #region Declarations

        private UTrialBalanceReport _list;
        public bool IsPartyGroupingSelected { get; private set; }

        #endregion

        #region Constructor

        public FAccounts()
            : this(new List<string>()) { }

        public FAccounts(IList<string> selectedAccountIds, bool multiSelect = false)
            : this(selectedAccountIds, multiSelect, AccountTypes.All) { }

        public FAccounts(IList<string> selectedAccountIds, bool multiSelect,
                         AccountTypes accountTypes, bool partyGrouping = false)
        {
            InitializeComponent();
            loadAccountList();

            _list.SelectedAccountIds = selectedAccountIds;
            _list.MultiSelect = multiSelect;
            _list.AccountTypes = accountTypes;
            
            if (partyGrouping)
                _list.ShowPartyGroups();
        }

        #endregion

        #region Event Handlers

        private void FAccounts_Activated(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDialogResult);
        }

        void processDialogResult()
        {
            DialogResult = DialogResult.None;
        }


        private void FAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            EventHandlerExecutor.Execute(processEscapeKey, sender, e);
        }

        void processEscapeKey(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;

            if (args.KeyCode == Keys.Escape)
                Close();
        }

        private void FAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(processCloseReason, sender, e);
        }

        void processCloseReason(object sender, EventArgs e)
        {
            var args = e as FormClosingEventArgs;
            if (args.CloseReason == CloseReason.UserClosing)
                DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processListSelection);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedAccounts);
        }

        void processSelectedAccounts()
        {
            _list.SelectedAccountIds = new List<string>();
            DialogResult = DialogResult.OK;
            Hide();
        }

        #endregion

        #region Public Methods

        public IList<string> GetSelectedAccountIds()
        {
            return _list.SelectedAccountIds;
        }

        #endregion

        #region Private Methods

        private void loadAccountList()
        {
            var command = ForesightDatabaseFactory.GetInstance()
                                .GetCommandByNr(ForesightConstants.LedgerReportNr);
            _list = new UTrialBalanceReport(command);
            Controls.Add(_list);
            _list.BringToFront();
            _list.Dock = DockStyle.Fill;
            _list.Show();
        }

        private void processListSelection()
        {
            _list.ProjectSelectedAccounts();
            IsPartyGroupingSelected = _list.IsPartyGroupingSelected();

            DialogResult = _list.SelectedAccountIds.Count == 0 ? DialogResult.Cancel : DialogResult.OK;
            Hide();
        }

        #endregion
    }
}
