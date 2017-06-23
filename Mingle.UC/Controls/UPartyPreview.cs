using Mingle.Domain.Model;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyPreview : UBaseForm
    {
        #region Constructor

        public UPartyPreview()
        {
            InitializeComponent();
        }

        #endregion

        #region Fillform
        public void FillForm(Party party)
        {
            txtName.Text = party.ToStringWithSalutation();
            txtShortName.Text = party.Entity.ShortName;
            txtNatureOfContact.Text = party.ToStringNatureOfContacts();
            txtEmail.Text = party.ToStringEmailIds();
            txtIM.Text = party.ToStringIMIds();
            txtReferences.Text = party.ToStringAllReferencedContacts();
            rtbAddress.Text = party.ToStringAddresss();
            rtbNotes.Text = party.Entity.Notes;
            toolTip.SetToolTip(rtbAddress, party.ToStringAddresssWithLabels());
            toolTip.SetToolTip(lblAddress, party.ToStringAddresssWithLabels());
        }

        #endregion
    }
}
