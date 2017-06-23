using System.Collections.Generic;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UWebsitesAndDates : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UWebsitesAndDates()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            uPartyWebsites.Initialize();
            uPartyDates.Initialize();
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
            uPartyWebsites.DataSource = _party.Entity.Websites;
            uPartyDates.DataSource = _party.Entity.Dates;
        }

        public void Save()
        {
            _party.Entity.Websites = uPartyWebsites.DataSource as IList<Website>;
            _party.Entity.Dates = uPartyDates.DataSource as IList<PartyDate>;
        }

        public void RefreshLists()
        {
            uPartyWebsites.RefreshForm();
            uPartyDates.RefreshForm();
        }
    }
}
