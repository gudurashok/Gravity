using Mingle.Domain.Model;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UOrganizationOther : UBaseForm
    {
        private Party _party;

        public UOrganizationOther()
        {
            InitializeComponent();
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
            txtAbbreviation.Text = _party.Entity.Abbreviation;
        }

        public void Save()
        {
            _party.Entity.Abbreviation = txtAbbreviation.Text.Trim();
        }
    }
}
