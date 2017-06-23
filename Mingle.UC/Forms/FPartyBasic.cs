using System;
using Mingle.Domain.Model;
using Mingle.UC.Events;
using Scalable.Shared.Common;
using Scalable.Win.Forms;

namespace Mingle.UC.Forms
{
    public partial class FPartyBasic : FFormBase
    {
        #region Declarations

        private Party _party;

        #endregion

        #region Constructor

        private FPartyBasic()
        {
            InitializeComponent();
        }

        public FPartyBasic(Party party)
            : this()
        {
            _party = party;
        }

        #endregion

        #region Load

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(initialize);
        }

        void initialize()
        {
            setFormTitle();
            uParty.DataSource = _party;
            uParty.Initialize();
            uParty.PartySelected += uParty_PartySelected;
            uParty.PartySaved += uParty_PartySaved;
        }

        void uParty_PartySelected(object sender, PartySelectedEventArgs e)
        {
            _party = e.Party;
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = string.Format("Party: {0}", getFormTitle());
            lblTitle.Text = getTitleText();
            lblTitle2.Text = _party.Entity.Addresses.Count > 0 ? _party.Entity.Addresses[0].ToString() : string.Empty;
        }

        private string getFormTitle()
        {
            return _party.IsNew() ? "New Party" : _party.Entity.Name;
        }

        private string getTitleText()
        {
            return _party.IsNew() ? "Enter new party details as given below" : _party.ToStringWithSalutation();
        }

        #endregion

        #region Save

        private void uParty_PartySaved(object sender, PartySavedEventArgs e)
        {
            processPartySavedAction(e);
        }

        private void processPartySavedAction(PartySavedEventArgs e)
        {
            _party = e.Party;

            if (e.Action.IsClose())
                Close();
            else if (e.Action.IsNew() || e.Action.IsOnlySave())
                setFormTitle();
        }

        #endregion
    }
}
