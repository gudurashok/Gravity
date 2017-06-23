using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.Domain.Repositories;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UAddress : UBaseForm
    {
        #region Declarations

        private PartyAddress _partyAddress;
        private PartyRepository _repo;

        #endregion

        #region Constructor

        public UAddress()
        {
            InitializeComponent();
        }

        #endregion

        #region Intialize

        public void Initialize()
        {
            _repo = new PartyRepository();
            fillDropDowns();
            hookEventhandlers();
        }

        private void fillDropDowns()
        {
            fillStates();
            fillCountries();
        }

        private void fillStates()
        {
            var oldValue = cmbState.Text;
            cmbState.DataSource = null;
            cmbState.DataSource = ReferenceList.GetList(ListType.States);
            cmbState.Text = oldValue;
        }

        private void fillCountries()
        {
            var oldValue = cmbCountry.Text;
            cmbCountry.DataSource = null;
            cmbCountry.DataSource = ReferenceList.GetList(ListType.Countries);
            cmbCountry.Text = oldValue;
        }

        private void hookEventhandlers()
        {
            txtArea.Search += txtArea_Search;
            txtLandmark.Search += txtLandmark_Search;
            txtCity.Search += txtCity_Search;
        }

        #endregion

        #region Search criteria

        void txtArea_Search(object sender, PicklistSearchEventArgs e)
        {
            var result = _repo.GetArea(e.SearchText);
            e.Result = new PicklistSearchResult(result ?? e.SearchText, result);
        }

        void txtLandmark_Search(object sender, PicklistSearchEventArgs e)
        {
            var result = _repo.GetLandmark(e.SearchText);
            e.Result = new PicklistSearchResult(result ?? e.SearchText, result);
        }

        void txtCity_Search(object sender, PicklistSearchEventArgs e)
        {
            var result = _repo.GetCity(e.SearchText);
            e.Result = new PicklistSearchResult(result ?? e.SearchText, result);
        }

        #endregion

        #region Datasource

        public override object DataSource
        {
            get
            {
                fillObject();
                return _partyAddress;
            }
            set
            {
                _partyAddress = value as PartyAddress;
                fillForm();
            }
        }

        private void fillForm()
        {
            txtStreet.Text = _partyAddress.Address.Street;
            txtArea.Text = _partyAddress.Address.Area;
            txtLandmark.Text = _partyAddress.Address.Landmark;
            txtCity.Text = _partyAddress.Address.City;
            cmbState.Text = _partyAddress.Address.State;
            cmbCountry.Text = _partyAddress.Address.Country;
            txtPinCode.Text = _partyAddress.Address.PinCode;
        }

        private void fillObject()
        {
            _partyAddress.Address.Street = txtStreet.Text;
            _partyAddress.Address.Area = txtArea.Text;
            _partyAddress.Address.Landmark = txtLandmark.Text;
            _partyAddress.Address.City = txtCity.Text;
            _partyAddress.Address.State = cmbState.Text;
            _partyAddress.Address.Country = cmbCountry.Text;
            _partyAddress.Address.PinCode = txtPinCode.Text;
        }

        #endregion

        public PartyAddress GetCopy()
        {
            _partyAddress = _partyAddress.GetCopy();
            return (PartyAddress) DataSource;
        }

        public void RefreshLists()
        {
            fillDropDowns();
        }
    }
}
