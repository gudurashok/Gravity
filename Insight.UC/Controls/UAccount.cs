using System;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Mingle.Domain.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Insight.Domain.Common;

namespace Insight.UC.Controls
{
    public partial class UAccount : UFormBase, ISetup
    {
        private Account _account;
        public event EventHandler<EventArgs> ItemSaved;

        public UAccount()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            DataSource = Account.New();
            txbParty.PickList = Mingle.UC.Picklists.PicklistFactory.Parties.Form;
            txbParty.ItemSelected += txbParty_ItemSelected;
            txbChartOfAccount.PickList = PicklistFactory.ChartOfAccounts.Form;
            txbGroup.PickList = PicklistFactory.Accounts.Form;
        }

        void txbParty_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;

            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Text = txbParty.Value == null ? null : ((PartyListItem)txbParty.Value).Party.Entity.Name;
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _account;
            }
            set
            {
                _account = value as Account;
                fillForm();
            }
        }

        private void fillObject()
        {
            _account.Entity.Name = txtName.Text;
            fillPartyObject();
            fillChartOfAccountObject();
            fillGroup();
            fillOpeningBalance();
        }

        private void fillOpeningBalance()
        {
            _account.OpeningBalance.Amount = Convert.ToDecimal(ntbOpeningBalance.Text);
            _account.OpeningBalance.Date = InsightSession.CompanyPeriod.Period.Entity.Financial.From;
        }

        private void fillChartOfAccountObject()
        {
            _account.ChartOfAccount = txbChartOfAccount.Value == null
                                          ? null
                                          : ((ChartOfAccountListItem)txbChartOfAccount.Value).ChartOfAccount;
            _account.Entity.ChartOfAccountId = txbChartOfAccount.Value == null
                                                   ? null
                                                   : ((ChartOfAccountListItem)txbChartOfAccount.Value).ChartOfAccount.Entity.Id;
        }

        private void fillPartyObject()
        {
            _account.Party = txbParty.Value == null
                                 ? null
                                 : ((PartyListItem)txbParty.Value).Party;
            _account.Entity.PartyId = txbParty.Value == null
                                          ? null
                                          : ((PartyListItem)txbParty.Value).Party.Entity.Id;
        }

        private void fillGroup()
        {
            _account.Group = txbGroup.Value == null
                                 ? null
                                 : ((AccountListItem)txbGroup.Value).Account;
            _account.Entity.GroupId = txbGroup.Value == null
                                          ? null
                                          : ((AccountListItem)txbGroup.Value).Account.Entity.Id;
        }

        private void fillForm()
        {
            txtName.Text = _account.Entity.Name;
            txbParty.Value = getParty();
            txbChartOfAccount.Value = getChartOfAccount();
            txbGroup.Value = getGroup();
            var openingBalance = _account.GetOpeningBalance();
            ntbOpeningBalance.Text = openingBalance.ToString();
            ntbOpeningBalance.Value = Convert.ToDouble(openingBalance);
        }

        private PartyListItem getParty()
        {
            return _account.Party == null
                        ? null
                        : new PartyListItem { Party = _account.Party };
        }

        private ChartOfAccountListItem getChartOfAccount()
        {
            return _account.ChartOfAccount == null
                        ? null
                        : new ChartOfAccountListItem { ChartOfAccount = _account.ChartOfAccount };
        }

        private AccountListItem getGroup()
        {
            return _account.Group == null
                        ? null
                        : new AccountListItem { Account = _account.Group };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveAccount);
        }

        private void saveAccount()
        {
            ((Account)DataSource).Save();
            OnAccountSaved(new EventArgs());
        }

        protected virtual void OnAccountSaved(EventArgs e)
        {
            ItemSaved?.Invoke(this, e);
        }
    }
}

