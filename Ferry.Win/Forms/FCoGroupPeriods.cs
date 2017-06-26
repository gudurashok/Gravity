using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ferry.Logic.Base;
using Ferry.Logic.Model;
using Ferry.Win.Properties;
using System.IO;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Scalable.Win.Controls;
using Scalable.Win.Forms;
using Scalable.Shared.Common;
using Insight.Domain.Repositories;
using Gravity.Root.Common;
using Mingle.Domain.Entities;
using Mingle.Domain.Repositories;
using Scalable.Shared.Model;
using Mingle.Domain.Model;

namespace Ferry.Win.Forms
{
    public partial class FCoGroupPeriods : FFormBase
    {
        #region Declaratrions

        private IList<SourceCompanyPeriod> _companyPeriods;
        private IList<SourceCompanyGroup> _companyGroups;
        private readonly iFolderBrowser _importPathBrowser;
        private CompanyImporter _companyImporter;
        private InsightRepository _insightRepo;

        #endregion

        #region Properties

        public InsightRepository InsightRepo
        {
            get { return _insightRepo ?? (_insightRepo = new InsightRepository()); }
        }

        #endregion

        #region Constructor

        public FCoGroupPeriods()
        {
            _importPathBrowser = new iFolderBrowser(Resources.SelectImportDataFolder, this);
            InitializeComponent();
        }

        #endregion

        #region Initialize form

        protected override void OnLoad(EventArgs e)
        {
            EventHandlerExecutor.Execute(processLoad, this, e);
        }

        void processLoad(object sender, EventArgs e)
        {
            base.OnLoad(e);
            InitializeForm();
        }

        protected virtual void InitializeForm()
        {
            createCoGroupListColumns();
            createCoPeriodListColumns();
        }

        private void createCoGroupListColumns()
        {
            lvwCoGroups.Columns.Clear();
            lvwCoGroups.Columns.Add(new iColumnHeader("Name", true));
            lvwCoPeriods.ResizeColumns();
        }

        private void createCoPeriodListColumns()
        {
            lvwCoPeriods.Columns.Clear();
            lvwCoPeriods.Columns.Add(new iColumnHeader("CompanyName", true));
            lvwCoPeriods.Columns.Add(new iColumnHeader("Date period", 100));
            lvwCoPeriods.ResizeColumns();
        }

        #endregion

        #region Process import source

        private void btnImportFrom_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processImportFrom, sender, e);
        }

        void processImportFrom(object sender, EventArgs e)
        {
            if (_importPathBrowser.Show() == string.Empty) return;
            _companyImporter = new CompanyImporter(_importPathBrowser.SelectedPath, true);
            processProviderDataPath();
        }

        private void processProviderDataPath()
        {
            _companyGroups = _companyImporter.GetAllCompanyGroups();
            if (noCompanyGroupsFound())
                return;

            fillCompanyGroups();
            displaySourceProviderInfo();
        }

        private bool noCompanyGroupsFound()
        {
            return _companyGroups.Count == 0;
        }

        private void fillCompanyGroups()
        {
            lvwCoGroups.FillData(_companyGroups, true);
        }

        private void displaySourceProviderInfo()
        {
            txtImportFrom.Text = _importPathBrowser.SelectedPath;
            lblProviderName.Text = EnumUtil.GetEnumDescription(_companyImporter.Provider);
        }

        #endregion

        #region Process selected company group

        private void lvwCoGroups_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedCoGroup, sender, e);
        }

        private void processSelectedCoGroup(object sender, EventArgs e)
        {
            var args = e as ItemCheckedEventArgs;
            if (args.Item.Checked)
                loadCompanyPeriodsOfGroup(args.Item.Tag as SourceCompanyGroup);

            fillSelectedGroupPeriods();
        }

        private void loadCompanyPeriodsOfGroup(SourceCompanyGroup group)
        {
            var result = _companyImporter.GetCompanyPeriodsFor(group);
            if (result.Count == 0)
                return;

            _companyPeriods = result;
        }

        private void fillSelectedGroupPeriods()
        {
            var selectedPeriods = getCurrentSelectedCompanies();
            fillSelectedGroupCompanies();
            recheckSelectedPeriods(selectedPeriods);
        }

        private IList<ListViewItem> getCurrentSelectedCompanies()
        {
            return lvwCoPeriods.CheckedItems.Cast<ListViewItem>().ToList();
        }

        private void fillSelectedGroupCompanies()
        {
            lvwCoPeriods.Items.Clear();

            foreach (ListViewItem lvi in lvwCoGroups.CheckedItems)
                fillCompanyPeriods(_companyPeriods
                                    .Where(cp => cp.GroupCode == getSelectedGroupCode(lvi))
                                    .ToList());
        }

        private string getSelectedGroupCode(ListViewItem lvi)
        {
            return ((SourceCompanyGroup)lvi.Tag).Code;
        }

        private void fillCompanyPeriods(IEnumerable<SourceCompanyPeriod> periods)
        {
            var repo = new InsightRepository();
            foreach (var cp in periods)
            {
                findCompanyPeriodId(cp, repo);
                var lvi = lvwCoPeriods.Items.Add(cp.CompanyName);
                lvi.Tag = cp;
                lvi.SubItems.Add(cp.Period.ToYearString());
                if (!cp.IsNew()) disableCompanyPeriod(lvi, Color.DarkGray);
                if (!dataFolderExists(cp)) disableCompanyPeriod(lvi, Color.LightGray);
            }
        }

        private void findCompanyPeriodId(SourceCompanyPeriod cp, InsightRepository repo)
        {
            if (!cp.IsNew())
                return;

            cp.Id = repo.GetCompanyPeriodIdByNameAndFinPeriod(cp.CompanyName, cp.Period);
        }

        private bool dataFolderExists(SourceCompanyPeriod cp)
        {
            return Directory.Exists(cp.SourceDataPath);
        }

        private void recheckSelectedPeriods(IList<ListViewItem> selectedPeriods)
        {
            foreach (ListViewItem lvi in lvwCoPeriods.Items)
                lvi.Checked = shouldCheckCoPeriodItem(selectedPeriods, lvi);
        }

        private bool shouldCheckCoPeriodItem(IEnumerable<ListViewItem> selectedPeriods, ListViewItem lvi)
        {
            return selectedPeriods.Any(selectedItem => selectedItem.Text == lvi.Text
                            && selectedItem.SubItems[1].Text == lvi.SubItems[1].Text);
        }

        #endregion

        #region Process selected period

        private void lvwCoPeriods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedPeriod, sender, e);
        }

        void processSelectedPeriod(object sender, EventArgs e)
        {
            var args = e as ItemCheckEventArgs;

            if (args.NewValue == CheckState.Unchecked)
                return;

            var cp = lvwCoPeriods.Items[args.Index].Tag as SourceCompanyPeriod;

            if (companyPeriodAlreadyTaken(cp) || companyDataFolderNotFound(cp))
                args.NewValue = CheckState.Unchecked;
        }

        private bool companyPeriodAlreadyTaken(SourceCompanyPeriod cp)
        {
            if (cp == null || cp.IsNew())
                return false;

            MessageBoxUtil.ShowMessage(Resources.CompanyPeriodAlreadyTaken);
            return true;
        }

        private bool companyDataFolderNotFound(SourceCompanyPeriod cp)
        {
            if (cp == null || Directory.Exists(cp.SourceDataPath))
                return false;

            MessageBoxUtil.ShowMessage(
                string.Format(Resources.CompanyDataFolderNotFound, cp.SourceDataPath));
            return true;
        }

        #endregion

        #region Save

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSave, sender, e);
        }

        void processSave(object sender, EventArgs e)
        {
            saveSelectedCompanyPeriods();
            clearSavedCompanyPeriods();
            MessageBoxUtil.ShowMessage(Resources.CoGroupSavedSuccessfully);
        }

        private IEnumerable<string> getSelectedCompanyNames()
        {
            return (from ListViewItem lvi in lvwCoPeriods.CheckedItems
                    select lvi.Tag).OfType<SourceCompanyPeriod>()
                                   .OrderBy(x => x.CompanyName)
                                   .Distinct()
                                   .Select(scp => scp.CompanyName)
                                   .ToList();
        }

        private void saveSelectedCompanyPeriods()
        {
            foreach (var companyName in getSelectedCompanyNames())
            {
                var partyId = createParty(companyName);

                foreach (var scp in (from ListViewItem lvi in lvwCoPeriods.CheckedItems
                                     select lvi.Tag).OfType<SourceCompanyPeriod>()
                                                    .Where(x => x.CompanyName == companyName))
                {

                    var companyId = createCompany(scp.CompanyCode, scp.CompanyName, partyId);
                    var periodId = createDatePeriod(scp.Period);
                    var companyPeriod = new CompanyPeriodEntity();
                    companyPeriod.CompanyId = companyId;
                    companyPeriod.PeriodId = periodId;
                    companyPeriod.SourceDataPath = scp.SourceDataPath;
                    companyPeriod.SourceDataProvider = _companyImporter.Provider;
                    InsightRepo.Save(companyPeriod);
                }
            }
        }

        private string createParty(string partyName)
        {
            var party = PartyEntity.New();
            party.Name = Name = partyName;
            InsightRepo.Save(party);
            return party.Id;
        }

        private string createCompany(string code, string name, string partyId)
        {
            var company = new CompanyEntity { Code = code, Name = name, PartyId = partyId };
            company.PartyId = partyId;
            InsightRepo.Save(company);
            return company.Id;
        }

        private string createDatePeriod(DatePeriod period)
        {
            var result = InsightRepo.GetFiscalDatePeriodByPeriod(period, true);
            return result.Entity.Id;
        }

        private void clearSavedCompanyPeriods()
        {
            foreach (ListViewItem lvi in lvwCoPeriods.CheckedItems)
            {
                lvi.Checked = false;
                disableCompanyPeriod(lvi, Color.DarkGray);
            }
        }

        private void disableCompanyPeriod(ListViewItem lvi, Color backColor)
        {
            lvi.UseItemStyleForSubItems = false;
            lvi.BackColor = backColor;
            lvi.ForeColor = Color.White;

            foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
            {
                lvsi.BackColor = backColor;
                lvsi.ForeColor = Color.White;
            }
        }

        #endregion
    }
}
