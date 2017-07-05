using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ferry.Win.Forms;
using Ferry.Win.Properties;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Insight.Domain.Repositories;
using Scalable.Win.FormControls;
using Insight.Domain.ViewModel;
using Insight.Domain.Enums;
using Foresight.Logic.DataAccess;
using Gravity.Root.Common;
using Ferry.Logic.Insight;

namespace Ferry.Win.Controls
{
    public partial class UCompanyPeriods : UPicklist
    {
        public UCompanyPeriods()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            btnOpen.Hide();
            SearchProperty = "Company";
            buildList();
        }

        private void buildList()
        {
            initializeListView();
            buildColumns();
            Repository = CompanyPeriods.NewLoadAllDataSourceCompanies();
            FillList(true);
            setCompanyPeriodViewState();
        }

        private void initializeListView()
        {
            ListView.CheckBoxes = true;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Company", true));
            ListView.Columns.Add(new iColumnHeader("Period", 75));
            ListView.Columns.Add(new iColumnHeader("Provider", 55));
            ListView.Columns.Add(new iColumnHeader("Imported", 55));
        }

        private void setCompanyPeriodViewState()
        {
            if (!ListView.HasItems())
                disableCompanyPeriodButtons();
        }

        private void btnCreatePeriod_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCreateForsightCompanyPeriod);
        }

        private void processCreateForsightCompanyPeriod()
        {
            btnCreatePeriod.Enabled = false;
            createInsightCompanyPeriodInForesight(getSelectedCompanyPeriod());
        }

        private void createInsightCompanyPeriodInForesight(CompanyPeriod companyPeriod)
        {
            var coGroup = GravitySession.CompanyGroup;
            var dbContext = new DataContext(coGroup);
            dbContext.BeginTransaction();

            var period = dbContext.GetDatePeriodByFinPeriod(companyPeriod.Period);
            if (period == null)
                companyPeriod.Foresight.PeriodId = dbContext.AddDatePeriod(companyPeriod.Period);
            else
                companyPeriod.Foresight.PeriodId = Convert.ToInt32(period.Entity.Id);

            var foresightCo = getForesightCompany(dbContext, companyPeriod.Company);
            companyPeriod.Foresight.CompanyId = Convert.ToInt32(foresightCo.Entity.Id);
            companyPeriod.Entity.ForesighId = dbContext.SaveCompanyPeriod(companyPeriod);

            updateForesightCompanyPeriodIdInInsight(companyPeriod);
            dbContext.Commit();
            MessageBoxUtil.ShowMessage("Foresight company of this period successfully created.");
        }

        private Company getForesightCompany(DataContext dbc, Company insightCo)
        {
            var foresightCo = dbc.GetCompanyByCode(insightCo.GetCodeCreatedFromId());
            if (foresightCo != null)
                return foresightCo;

            insightCo.Entity.Code = insightCo.GetCodeCreatedFromId();
            var id = dbc.InsertCompany(insightCo.Entity,
                                        GravitySession.CompanyGroup.Entity.ForesightGroupId);
            return new Company(new CompanyEntity
            {
                Id = id.ToString(),
                Code = insightCo.Entity.Code,
                Name = insightCo.Entity.Name
            });
        }

        private void updateForesightCompanyPeriodIdInInsight(CompanyPeriod companyPeriod)
        {
            var repo = (Repository as CompanyPeriods);
            repo.Save(companyPeriod.Entity);
        }

        private void btnAddPeriods_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddPeriods);
        }

        void processAddPeriods()
        {
            var fCoGroupPeriods = new FCoGroupPeriods();
            fCoGroupPeriods.ShowDialog();
            FillList(true);
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddPeriod);
        }

        void processAddPeriod()
        {
            saveCompanyPeriod(createNewCompanyPeriod());
        }

        private CompanyPeriod createNewCompanyPeriod()
        {
            var cp = CompanyPeriod.New();
            cp.Company = new Company(new CompanyEntity());
            cp.Period = new FiscalDatePeriod(new FiscalDatePeriodEntity());
            return cp;
        }

        private void btnDeletePeriod_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDeletePeriod);
        }

        void processDeletePeriod()
        {
            if (!shouldDeleteCompanyPeriod())
                return;

            Cursor = Cursors.WaitCursor;
            var cp = getSelectedCompanyPeriod();
            var dbc = new DataContext(GravitySession.CompanyGroup);
            dbc.DeleteCompanyPeriod(cp);
            var repo = (Repository as CompanyPeriods);
            repo.DeleteById(cp.Entity.Id);
            FillList(true);
            Cursor = Cursors.Default;
        }

        private bool shouldDeleteCompanyPeriod()
        {
            var cp = getSelectedCompanyPeriod();
            setForesightCompanyPeriod(cp);
            var dbc = new DataContext(GravitySession.CompanyGroup);
            if (dbc.IsCompanyPeriodImporting(cp))
            {
                MessageBoxUtil.ShowMessage(Resources.CompanyPeriodAlreadyImportingCannotDelete);
                return false;
            }

            dbc.CheckIsCompanyPeriodImported(cp);
            if (cp.Entity.IsImported)
                return MessageBoxUtil.GetConfirmationYesNo(Resources.DeleteImportedCompanyPeriod) == DialogResult.Yes;

            return MessageBoxUtil.GetConfirmationYesNo(Resources.DeleteCompanyPeriod) == DialogResult.Yes;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processImportPeriods);
        }

        void processImportPeriods()
        {
            importSelectedCompanyPeriods();
            FillList(true);
        }

        private void importSelectedCompanyPeriods()
        {
            var provider = getCheckedItemCompanyProvider();
            if (provider == SourceDataProvider.Insight)
            {
                performInsightDataImport();
                return;
            }

            var importer = new FImporter(getSelectedCompanyPeriods());
            importer.ShowDialog();
        }

        private void performInsightDataImport()
        {
            var statusForm = new FStatusMessage();

            try
            {
                var companyPerdiods = getSelectedCompanyPeriods();
                foreach (var companyPeriod in companyPerdiods
                                    .Where(cp => cp.Entity.ForesighId != 0))
                {
                    statusForm.SetStatusMessage($"Importing: {companyPeriod.ToStringNameAndPeriod()}");
                    statusForm.Refresh();
                    var importer = new InsightDataImporter(GravitySession.CompanyGroup, companyPeriod);
                    importer.Execute();
                    statusForm.Close();
                    MessageBoxUtil.ShowMessage("Data importing completed.");
                }
            }
            catch (Exception ex)
            {
                statusForm.Close();
                MessageBoxUtil.ShowError(ex);
            }
        }

        private IList<CompanyPeriod> getSelectedCompanyPeriods()
        {
            return (from ListViewItem lvi in ListView.CheckedItems
                    select getSelectedCompanyPeriod(lvi)).ToList();
        }

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedPeriod);
        }

        private void processSelectedPeriod()
        {
            displayPeriodDataPath();
            setPeriodButtonsState();
        }

        private void displayPeriodDataPath()
        {
            txtPeriodDataPath.Clear();
            if (ListView.SelectedItems.Count == 0) return;
            txtPeriodDataPath.Text = getSelectedCompanyPeriod().Entity.SourceDataPath;
        }

        private void setPeriodButtonsState()
        {
            if (onlyOnePeriodSelected())
                enableCompanyPeriodButtons();
            else
                disableCompanyPeriodButtons();
        }

        private bool onlyOnePeriodSelected()
        {
            return ListView.SelectedItems.Count == 1;
        }

        private void ListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            EventHandlerExecutor.Execute(processCheckPeriod, sender, e);
        }

        private void processCheckPeriod(object sender, EventArgs e)
        {
            var args = e as ItemCheckEventArgs;
            var cp = getSelectedCompanyPeriod(ListView.Items[args.Index]);
            if (cp.Entity.SourceDataProvider != SourceDataProvider.Insight)
            {
                var dbc = new DataContext(GravitySession.CompanyGroup);
                dbc.ClearUnfinishedImports(getExecutingProcessesExpr());
            }

            if (args.NewValue != CheckState.Checked)
                return;

            if (cp.Entity.SourceDataProvider != SourceDataProvider.Insight)
                if (!shouldImportCompanyPeriod(cp))
                    args.NewValue = CheckState.Unchecked;
        }

        private string getExecutingProcessesExpr()
        {
            var sb = new StringBuilder();
            foreach (var p in WinProcessUtil.GetExecutingProcesses())
                sb.Append("ProcessId <> ").Append(p.Id.ToString()).Append(" AND ");

            sb.Replace(" AND ", "", (sb.Length - 5), 5);
            return sb.ToString();
        }

        private bool shouldImportCompanyPeriod(CompanyPeriod cp)
        {
            setForesightCompanyPeriod(cp);
            var dbc = new DataContext(GravitySession.CompanyGroup);
            if (dbc.IsCompanyPeriodImporting(cp))
            {
                MessageBoxUtil.ShowMessage(Resources.CompanyPeriodAlreadyImportingCannotImport);
                return false;
            }

            dbc.CheckIsCompanyPeriodImported(cp);
            if (cp.Entity.IsImported)
                return MessageBoxUtil.GetConfirmationYesNo(Resources.PeriodIsAlreadyImported) == DialogResult.Yes;

            return true;
        }

        private void ListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            EventHandlerExecutor.Execute(setImportButtonState);
        }

        private void setImportButtonState()
        {
            btnOK.Enabled = shouldEnableImportButton();
        }

        private bool shouldEnableImportButton()
        {
            if (ListView.CheckedItems.Count > 0)
            {
                var provider = getCheckedItemCompanyProvider();
                if (provider == SourceDataProvider.Insight)
                {
                    var selectedCompanyPeriods = getSelectedCompanyPeriods();
                    var insightCoCount = selectedCompanyPeriods.Count(cp =>
                            cp.Entity.SourceDataProvider == SourceDataProvider.Insight &&
                            cp.Entity.ForesighId != 0);

                    return insightCoCount != 0;
                }

                return provider != SourceDataProvider.None;
            }

            return false;
        }

        private SourceDataProvider getCheckedItemCompanyProvider()
        {
            var selectedCompanyPeriods = getSelectedCompanyPeriods();
            var insightCoCount = selectedCompanyPeriods.Count(cp =>
               cp.Entity.SourceDataProvider == SourceDataProvider.Insight);

            if (selectedCompanyPeriods.Count == insightCoCount)
                return SourceDataProvider.Insight;

            var nonInsightCoCount = selectedCompanyPeriods.Count(cp =>
               cp.Entity.SourceDataProvider != SourceDataProvider.Insight);

            return selectedCompanyPeriods.Count == nonInsightCoCount
                                                ? SourceDataProvider.Tcs
                                                : SourceDataProvider.None;
        }

        private void saveCompanyPeriod(CompanyPeriod cp)
        {
            if (getCompanyPeriodInfo(cp) != DialogResult.OK)
                return;

            Cursor = Cursors.WaitCursor;

            var repo = new InsightRepository();
            if (cp.IsNew())
                repo.Save(cp);

            //TODO:...
            //    else
            //        _dbc.SaveCompanyPeriod(getSelectedCompanyPeriod(), cp);

            FillList(true);
        }

        private DialogResult getCompanyPeriodInfo(CompanyPeriod cp)
        {
            var coPeriodForm = new FCompanyPeriod(cp);
            return coPeriodForm.ShowDialog();
        }

        private CompanyPeriod getSelectedCompanyPeriod()
        {
            return getSelectedCompanyPeriod(ListView.SelectedItems[0]);
        }

        private CompanyPeriod getSelectedCompanyPeriod(ListViewItem lvi)
        {
            return (lvi.Tag as CompanyPeriodListItem).CompanyPeriod;
        }

        private void setForesightCompanyPeriod(CompanyPeriod cp)
        {
            var dbc = new DataContext(GravitySession.CompanyGroup);
            cp.Foresight = dbc.GetForesightCompanyPeriod(cp.Entity.ForesighId);
        }

        private void enableCompanyPeriodButtons()
        {
            var cp = getSelectedCompanyPeriod();
            btnCreatePeriod.Visible = cp.Entity.SourceDataProvider == SourceDataProvider.Insight;
            if (cp.Entity.SourceDataProvider == SourceDataProvider.Insight)
            {
                btnCreatePeriod.Enabled = cp.Entity.ForesighId == 0;
                btnDeletePeriod.Enabled = false;
            }
            else
            {
                btnDeletePeriod.Enabled = true;
            }

            ParentForm.AcceptButton = btnOK;
        }

        private void disableCompanyPeriodButtons()
        {
            btnCreatePeriod.Visible = false;
            btnDeletePeriod.Enabled = false;
            ParentForm.AcceptButton = btnAddPeriods;
        }
    }
}
