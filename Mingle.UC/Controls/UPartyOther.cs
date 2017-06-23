using System;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyOther : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UPartyOther()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            uPersonOther.Initialize();
        }

        public void Save()
        {
            uOrganizationOther.Save();
            uPersonOther.Save();
        }

        public void RefreshLists()
        {
            uPersonOther.RefreshForm();
        }

        public override object DataSource
        {
            get { return _party; }
            set
            {
                _party = value as Party;
                fillForm();
            }
        }

        private void fillForm()
        {
            uOrganizationOther.DataSource = _party;
            uPersonOther.DataSource = _party;
            swapControl();
        }

        private void swapControl()
        {
            uPersonOther.Visible = isPerson();
            uOrganizationOther.Visible = !isPerson();
        }

        private bool isPerson()
        {
            return _party.Entity.Type == PartyType.Person;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            EventHandlerExecutor.Execute(swapControl);
        }
    }
}
