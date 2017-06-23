using System.Collections.Generic;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyContactsAndProfessions : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UPartyContactsAndProfessions()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            uPartyContacts.Initialize();
            uPartyProfessions.Initialize();
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
            uPartyContacts.DataSource = _party.Entity.Contacts;
            uPartyProfessions.DataSource = _party.Entity.Professions;
        }

        public void Save()
        {
            _party.Entity.Contacts = uPartyContacts.DataSource as IList<PartyContact>;
            _party.Entity.Professions = uPartyProfessions.DataSource as IList<string>;
        }

        public void RefreshLists()
        {
            uPartyContacts.RefreshForm();
            uPartyProfessions.RefreshForm();
        }
    }
}
