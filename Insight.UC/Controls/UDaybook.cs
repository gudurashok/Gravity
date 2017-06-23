using System;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UDaybook : UFormBase, ISetup
    {
        private Daybook _daybook;
        public event EventHandler<EventArgs> ItemSaved;

        public UDaybook()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txbAccount.PickList = PicklistFactory.Accounts.Form;
            EnumUtil.LoadEnumListItems(cmbDaybookType, typeof(DaybookType), DaybookType.Unknown);
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _daybook;
            }
            set
            {
                _daybook = value as Daybook;
                fillForm();
            }
        }

        private void fillObject()
        {
            _daybook.Entity.Name = txtName.Text;
            _daybook.Entity.Type = getType();
            fillAccount();
        }

        private DaybookType getType()
        {
            return cmbDaybookType.SelectedIndex == -1
                       ? DaybookType.Unknown
                       : (DaybookType)cmbDaybookType.SelectedValue;
        }

        private void fillAccount()
        {
            _daybook.Account = txbAccount.Value == null
                                 ? null
                                 : ((AccountListItem)txbAccount.Value).Account;
            _daybook.Entity.AccountId = txbAccount.Value == null
                                          ? null
                                          : ((AccountListItem)txbAccount.Value).Account.Entity.Id;
        }

        private void fillForm()
        {
            txtName.Text = _daybook.Entity.Name;
            EnumUtil.SetEnumListItem(cmbDaybookType, _daybook.Entity.Type);
            txbAccount.Value = getAccount();
        }

        private AccountListItem getAccount()
        {
            return _daybook.Account == null
                        ? null
                        : new AccountListItem { Account = _daybook.Account  };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveDaybook);
        }

        private void saveDaybook()
        {
            ((Daybook)DataSource).Save();
            OnDaybookSaved(new EventArgs());
        }

        protected virtual void OnDaybookSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }
    }
}
