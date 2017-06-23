using System.Collections.Generic;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UEmailsAndIMs : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UEmailsAndIMs()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            uPartyEmails.Initialize();
            uPartyIMs.Initialize();
        }

        public override object DataSource
        {
            get
            {
                return _party;
            }
            set
            {
                _party = value as Party;
                fillForm();
            }
        }

        private void fillForm()
        {
            uPartyEmails.DataSource = _party.Entity.Emails;
            uPartyIMs.DataSource = _party.Entity.InstantMessengers;
        }

        public void Save()
        {
            _party.Entity.Emails = uPartyEmails.DataSource as IList<Email>;
            _party.Entity.InstantMessengers = uPartyIMs.DataSource as IList<InstantMessenger>;
        }

        public void RefreshLists()
        {
            uPartyEmails.RefreshForm();
            uPartyIMs.RefreshForm();
        }
    }
}
