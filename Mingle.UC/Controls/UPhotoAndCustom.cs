using System.Collections.Generic;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPhotoAndCustom : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UPhotoAndCustom()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            uPartyCustom.Initialize();
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
            uPictureAndNotes.DataSource = _party;
            uPartyCustom.DataSource = _party.Entity.CustomProperties;
        }

        public void Save()
        {
            uPictureAndNotes.Save();
            _party.Entity.CustomProperties = uPartyCustom.DataSource as IList<CustomProperty>;
        }

        public void RefreshLists()
        {
            uPartyCustom.RefreshForm();
        }
    }
}
