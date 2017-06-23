using System;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UChartOfAccount : UFormBase, ISetup
    {
        private ChartOfAccount _chartOfAccount;
        public event EventHandler<EventArgs> ItemSaved;
        private ChartOfAccountType _type;

        public UChartOfAccount()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            _type = ChartOfAccountType.Liability;
            EnumUtil.LoadEnumListItems(cmbCoaType, typeof(ChartOfAccountType),
                                        _type, (int)ChartOfAccountType.None);
            DataSource = ChartOfAccount.New();
            txbParentCoa.PickList = PicklistFactory.ChartOfAccountsOfType(_type).Form;
            txbParentCoa.ItemSelected += txbParentCoa_ItemSelected;
        }

        void txbParentCoa_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;

            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Text = txbParentCoa.Value == null ? null : ((ChartOfAccountListItem)txbParentCoa.Value).Name;
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _chartOfAccount;
            }
            set
            {
                _chartOfAccount = value as ChartOfAccount;
                fillForm();
            }
        }

        private void fillObject()
        {
            _chartOfAccount.Entity.Name = txtName.Text;
            _chartOfAccount.Entity.Type = getType();
            _chartOfAccount.Entity.ParentId = getParentId();
        }

        private ChartOfAccountType getType()
        {
            return cmbCoaType.SelectedIndex == -1
                       ? ChartOfAccountType.Liability
                       : (ChartOfAccountType)cmbCoaType.SelectedValue;
        }

        private string getParentId()
        {
            return txbParentCoa.Value == null
                       ? null
                       : ((ChartOfAccountListItem)txbParentCoa.Value).ChartOfAccount.Entity.Id;
        }

        private void fillForm()
        {
            txtName.Text = _chartOfAccount.Entity.Name;
            EnumUtil.SetEnumListItem(cmbCoaType, _chartOfAccount.Entity.Type);
            processCoaType();
            txbParentCoa.Value = getChartOfAccountListItem();
        }

        private ChartOfAccountListItem getChartOfAccountListItem()
        {
            return _chartOfAccount.Parent == null
                       ? null
                       : new ChartOfAccountListItem { ChartOfAccount = _chartOfAccount.Parent };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveChartOfAccount);
        }

        private void saveChartOfAccount()
        {
            ((ChartOfAccount)DataSource).Save();
            OnChartOfAccountSaved(new EventArgs());
        }

        protected virtual void OnChartOfAccountSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }

        private void cmbCoaType_Leave(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCoaType);
        }

        void processCoaType()
        {
            if (cmbCoaType.SelectedValue == null)
                cmbCoaType.SelectedIndex = 0;

            if (_type == (ChartOfAccountType)cmbCoaType.SelectedValue)
                return;

            _type = (ChartOfAccountType)cmbCoaType.SelectedValue;
            txbParentCoa.PickList = PicklistFactory.ChartOfAccountsOfType(_type).Form;
        }
    }
}
