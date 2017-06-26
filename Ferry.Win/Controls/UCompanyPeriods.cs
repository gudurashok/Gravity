﻿using System;
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

            var co = dbContext.GetCompanyByCode(companyPeriod.Company.GetCodeCreatedFromId());
            companyPeriod.Foresight.CompanyId = Convert.ToInt32(co.Entity.Id);

            dbContext.SaveCompanyPeriod(companyPeriod, coGroup.Entity.ForesightGroupId);
            updateForesightCompanyPeriodIdInInsight(companyPeriod);
            dbContext.Commit();
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

        private void btnEditPeriod_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditPeriod);
        }

        void processEditPeriod()
        {
            var repo = new InsightRepository();
            var cp = repo.GetCompanyPeriodById(getSelectedCompanyPeriod().Entity.Id);
            saveCompanyPeriod(cp);
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
            //_dbc.DeleteCompanyPeriod(getSelectedCompanyPeriod());
            FillList(true);
        }

        private bool shouldDeleteCompanyPeriod()
        {
            var cp = getSelectedCompanyPeriod();

            //if (_dbc.IsCompanyPeriodImporting(cp))
            //{
            //    ScalableUtil.ShowMessage(Resources.CompanyPeriodAlreadyImportingCannotDelete);
            //    return false;
            //}

            //_dbc.CheckIsCompanyPeriodImported(cp);

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
            var importer = new FImporter(getSelectedCompanyPeriods());
            importer.ShowDialog();
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
            //_dbc.ClearUnfinishedImports(getExecutingProcessesExpr());

            if (args.NewValue != CheckState.Checked)
                return;

            if (!shouldImportCompanyPeriod(getSelectedCompanyPeriod(ListView.Items[args.Index])))
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
            //if (_dbc.IsCompanyPeriodImporting(cp))
            //{
            //    ScalableUtil.ShowMessage(
            //                Resources.CompanyPeriodAlreadyImportingCannotImport);
            //    return false;
            //}

            //_dbc.CheckIsCompanyPeriodImported(cp);

            //if (cp.IsImported)
            //    return ScalableUtil.GetConfirmationYesNo(
            //                Resources.PeriodIsAlreadyImported) == DialogResult.Yes;

            //return true;


            return true; //TODO: Should be removed when uncommented above code block
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

        private void enableCompanyPeriodButtons()
        {
            var cp = getSelectedCompanyPeriod();
            btnCreatePeriod.Visible = cp.Entity.SourceDataProvider == SourceDataProvider.Insight;
            if (cp.Entity.SourceDataProvider == SourceDataProvider.Insight)
            {
                btnCreatePeriod.Enabled = cp.Entity.ForesighId == 0;
                btnEditPeriod.Enabled = false;
                btnDeletePeriod.Enabled = false;
            }
            else
            {
                btnEditPeriod.Enabled = true;
                btnDeletePeriod.Enabled = true;
            }

            ParentForm.AcceptButton = btnOK;
        }

        private void disableCompanyPeriodButtons()
        {
            btnCreatePeriod.Visible = false;
            btnEditPeriod.Enabled = false;
            btnDeletePeriod.Enabled = false;
            ParentForm.AcceptButton = btnAddPeriods;
        }
    }
}
