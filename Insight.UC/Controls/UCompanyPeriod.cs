using System;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UCompanyPeriod : UFormBase, ISetup
    {
        private CompanyPeriod _companyPeriod;
        public event EventHandler<EventArgs> ItemSaved;

        public UCompanyPeriod()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txbCompany.PickList = PicklistFactory.Companies.Form;
            txbFiscalDatePeriod.PickList = PicklistFactory.FiscalDatePeriods.Form;
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _companyPeriod;
            }
            set
            {
                _companyPeriod = value as CompanyPeriod;
                fillForm();
            }
        }

        private void fillObject()
        {
            _companyPeriod.Company = getCompanyEntity();
            _companyPeriod.Entity.CompanyId = _companyPeriod.Company == null ? null : _companyPeriod.Company.Entity.Id;
            _companyPeriod.Period = getFiscalDatePeriodEntity();
            _companyPeriod.Entity.PeriodId = _companyPeriod.Period == null ? null : _companyPeriod.Period.Entity.Id;
        }

        private FiscalDatePeriod getFiscalDatePeriodEntity()
        {
            return txbFiscalDatePeriod.Value == null ? null : ((FiscalDatePeriodListItem)txbFiscalDatePeriod.Value).FiscalDatePeriod;
        }

        private Company getCompanyEntity()
        {
            return txbCompany.Value == null ? null : ((CompanyListItem)txbCompany.Value).Company;
        }

        private void fillForm()
        {
            txbCompany.Value = getCompany();
            txbFiscalDatePeriod.Value = getFiscalDatePeriod();
        }

        private CompanyListItem getCompany()
        {
            return _companyPeriod.Company == null ? null : new CompanyListItem { Company = _companyPeriod.Company };
        }

        private FiscalDatePeriodListItem getFiscalDatePeriod()
        {
            return _companyPeriod.Period == null ? null : new FiscalDatePeriodListItem { FiscalDatePeriod = _companyPeriod.Period };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveCompanyPeriod);
        }

        private void saveCompanyPeriod()
        {
            ((CompanyPeriod)DataSource).Save();
            OnCompanyPeriodSaved(new EventArgs());
        }

        protected virtual void OnCompanyPeriodSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }
    }
}
