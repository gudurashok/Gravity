using System;
using Insight.Domain.Model;
using Insight.UC.Common;
using Mingle.Domain.ViewModel;
using Mingle.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UCompany : UFormBase, ISetup
    {
        private Company _company;
        public event EventHandler<EventArgs> ItemSaved;

        public UCompany()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            DataSource = Company.New();
            txbParty.PickList = PicklistFactory.Parties.Form;
            txbParty.ItemSelected += txbParty_ItemSelected;
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
                return _company;
            }
            set
            {
                _company = value as Company;
                fillForm();
            }
        }

        private void fillObject()
        {
            _company.Entity.Name = txtName.Text;
            _company.Party = txbParty.Value == null ? null : ((PartyListItem)txbParty.Value).Party;
            _company.Entity.PartyId = txbParty.Value == null ? null : ((PartyListItem)txbParty.Value).Party.Entity.Id;
        }

        private void fillForm()
        {
            txtName.Text = _company.Entity.Name;
            txbParty.Value = getParty();
        }

        private PartyListItem getParty()
        {
            return _company.Party == null ? null : new PartyListItem { Party = _company.Party };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveCompany);
        }

        private void saveCompany()
        {
            ((Company)DataSource).Save();
            OnCompanySaved(new EventArgs());
        }

        protected virtual void OnCompanySaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }
    }
}
