using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ferry.Logic.Base;
using Ferry.Logic.Model;
using Ferry.Win.Properties;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Forms;
using Scalable.Shared.Common;

namespace Ferry.Win.Forms
{
    public partial class FCompanyPeriod : FFormBase
    {
        #region Declarations

        private SourceCompanyPeriod _selectedScp;
        private readonly CompanyPeriod _cp;
        private readonly iFolderBrowser _importPathBrowser;
        private CompanyImporter _companyImporter;
        private IList<Company> _companies;

        #endregion

        #region Constructors

        public FCompanyPeriod(CompanyPeriod cp)
        {
            InitializeComponent();
            _cp = cp;
            _importPathBrowser = new iFolderBrowser(Resources.SelectImportCompanyDataFolder, this);
        }

        #endregion

        #region Initialize form

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(initializeForm);
        }

        private void initializeForm()
        {
            var repo = new InsightRepository();
            //_companies = repo.GetAllCompanies();

            fillCompanies();
            btnDataSourceBrowser.Enabled = _cp.IsNew();
            if (!_cp.IsNew())
                fillForm(_cp);
        }

        //    _selectedScp = transformCompanyPeriodToSourceCompanyPeriod();

        //private SourceCompanyPeriod transformCompanyPeriodToSourceCompanyPeriod()
        //{
        //    return new SourceCompanyPeriod
        //               {
        //                   CompanyCode = _cp.Company.Code,
        //                   CompanyName = _cp.Company.Name,
        //                   Period = _cp.Period.Financial,
        //                   SourceDataPath = _cp.SourceDataPath
        //               };
        //}

        private void fillCompanies()
        {
            cmbCompany.DataSource = _companies;
        }

        #endregion

        #region Source data process

        private void btnDataSourceBrowser_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSourceData);
        }

        private void processSourceData()
        {
            if (_importPathBrowser.Show() == string.Empty) return;
            _companyImporter = new CompanyImporter(_importPathBrowser.SelectedPath, false);
            processProviderDataPath();
        }

        private void processProviderDataPath()
        {
            _selectedScp = _companyImporter.GetCompanyPeriod();
            fillForm(_selectedScp);
        }

        #endregion

        #region Delete company

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteCompany);
        }

        private void deleteCompany()
        {
            if (companyNotSelected())
                cmbCompany.Text = string.Empty;
            else
            {
                var repo = new InsightRepository();
                repo.DeleteCompany(cmbCompany.SelectedItem as Company);
                _companies.Remove(cmbCompany.SelectedItem as Company);
                clearCompanies();
                fillCompanies();
            }
        }

        private bool companyNotSelected()
        {
            return cmbCompany.SelectedIndex == -1;
        }

        private void clearCompanies()
        {
            cmbCompany.DataSource = null;
        }

        #endregion

        #region Process save

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSave, sender, e);
        }

        private void processSave(object sender, EventArgs e)
        {
            //if (!isDataValid())
            //    return;

            fillObject();
            DialogResult = DialogResult.OK;
            Close();
        }

        //private bool isDataValid()
        //{
        //    if (string.IsNullOrEmpty(txtDataPath.Text))
        //    {
        //        MessageBoxUtil.ShowMessage(Resources.SelectDataPath);
        //        return false;
        //    }

        //    return true;
        //}

        private void fillObject()
        {
            _cp.Company = fillCompany();

            if (!_cp.IsNew())
                return;

            _cp.Entity.SourceDataPath = txtDataPath.Text;

            var repo = new InsightRepository();
            _cp.Period = repo.GetFiscalDatePeriodByPeriodName(_selectedScp.Period, true);
            _cp.Entity.SourceDataProvider = _companyImporter.Provider;
        }

        private Company fillCompany()
        {
            var enteredCompanyName = cmbCompany.Text.Trim();
            findEnteredCompanyName();

            if (companyNotSelected())
                return new Company(new CompanyEntity
                                   {
                                       Code = _selectedScp.CompanyCode,
                                       Name = enteredCompanyName,
                                   });

            return cmbCompany.SelectedItem as Company;
        }

        private void findEnteredCompanyName()
        {
            cmbCompany.SelectedIndex = cmbCompany.FindStringExact(cmbCompany.Text.Trim(), -1);
        }

        #endregion

        #region Common

        private void fillForm(CompanyPeriod cp)
        {
            txtDataPath.Text = cp.Entity.SourceDataPath;
            cmbCompany.Text = cp.Company.Entity.Name;
            lblDatePeriod.Text = cp.Period.ToString();
            lblProvider.Text = EnumUtil.GetEnumDescription(cp.Entity.SourceDataProvider);
        }

        private void fillForm(SourceCompanyPeriod scp)
        {
            txtDataPath.Text = scp.SourceDataPath;
            cmbCompany.Text = scp.CompanyName;
            lblDatePeriod.Text = scp.Period.ToYearString();
            lblProvider.Text = EnumUtil.GetEnumDescription(_companyImporter.Provider);
        }

        #endregion
    }
}
