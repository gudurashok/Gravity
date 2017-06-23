using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class FCompanyPeriods : Form
    {
        #region Internal Declarations

        private IList<CompanyPeriod> _selectedCoPeriods;
        private readonly CompanyPeriodType _listType;

        #endregion

        #region Constructor

        public FCompanyPeriods(IList<CompanyPeriod> selectedCoPeriods)
            : this(selectedCoPeriods, CompanyPeriodType.Both)
        {
        }

        public FCompanyPeriods(IList<CompanyPeriod> selectedCoPeriods, CompanyPeriodType listType)
        {
            InitializeComponent();
            _selectedCoPeriods = selectedCoPeriods;
            _listType = listType;
        }

        #endregion

        #region Event Handlers

        private void FCompanyPeriods_Load(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        void initialize()
        {
            buildColumns();
            fillListItems(readCompanyPeriods());
        }

        private void FCompanyPeriods_Activated(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDialogResult);
        }

        void processDialogResult()
        {
            DialogResult = DialogResult.None;
        }

        private void FCompanyPeriods_Resize(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(listAutoResize);
        }

        private void FCompanyPeriods_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandlerExecutor.Execute(processCloseReason, sender, e);
        }

        void processCloseReason(object sender, EventArgs e)
        {
            var args = e as FormClosingEventArgs;
            if (args.CloseReason == CloseReason.UserClosing)
                DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processProjectSelectedItems);
        }

        void processProjectSelectedItems()
        {
            projectSelectedItems();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processInvertSelection);
        }

        void processInvertSelection()
        {
            foreach (ListViewItem lvi in lvw.Items)
                lvi.Checked = !lvi.Checked;
        }

        private void FCompanyPeriods_KeyDown(object sender, KeyEventArgs e)
        {
            EventHandlerExecutor.Execute(processEscapeKey, sender, e);
        }

        void processEscapeKey(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;
            if (args.KeyCode == Keys.Escape)
                Close();
        }

        #endregion

        #region Private Methods

        private void buildColumns()
        {
            lvw.Columns.Clear();

            if (showCompany())
                lvw.Columns.Add("Company", 110);

            if (showPeriod())
                lvw.Columns.Add("Period", 65);

            listAutoResize();
        }

        private bool showPeriod()
        {
            return (_listType & CompanyPeriodType.Period) == CompanyPeriodType.Period;
        }

        private bool showCompany()
        {
            return (_listType & CompanyPeriodType.Company) == CompanyPeriodType.Company;
        }

        private void listAutoResize()
        {
            var colTotalWidth = 0;

            if (_listType == CompanyPeriodType.Both)
                colTotalWidth += 65;

            var findForm = lvw.FindForm();
            if (findForm != null) lvw.Columns[0].Width = findForm.Width - colTotalWidth - 35;
        }

        private IList<CompanyPeriod> readCompanyPeriods()
        {
            var companyPeriods = ForesightSession.Dbc.GetCompanyPeriods(true);
            return companyPeriods;
        }

        private void fillListItems(IList<CompanyPeriod> listItems)
        {
            lvw.Items.Clear();

            if (_listType == CompanyPeriodType.Both)
            {
                foreach (var cp in listItems)
                    lvw.Items.Add(createListItem(cp));

                return;
            }

            if (_listType == CompanyPeriodType.Company)
            {
                foreach (var cp in listItems.Select(c => c.Company.Entity.Id)
                                            .Distinct()
                                            .Select(companyId => listItems.First(c => c.Company.Entity.Id == companyId)))
                    lvw.Items.Add(createListItem(cp));

                return;
            }

            if (_listType == CompanyPeriodType.Period)
                foreach (var cp in listItems.Select(c => c.Period.Entity.Id)
                                            .Distinct()
                                            .Select(periodId => listItems.First(c => c.Period.Entity.Id == periodId)))
                    lvw.Items.Add(createListItem(cp));
        }

        private ListViewItem createListItem(CompanyPeriod cp)
        {
            var lvi = new ListViewItem();
            lvi.Tag = cp;

            if (showCompany())
                lvi.Text = cp.Company.Entity.Name;

            if (showPeriod())
                if (showCompany())
                    lvi.SubItems.Add(cp.Period.Entity.Name);
                else
                    lvi.Text = cp.Period.Entity.Financial.To.Year.ToString();

            lvi.Checked = shouldCheck(cp);
            return lvi;
        }

        private bool shouldCheck(CompanyPeriod cp)
        {
            return _selectedCoPeriods.SingleOrDefault(scp => scp.Entity.Id == cp.Entity.Id) != null;
        }

        private void projectSelectedItems()
        {
            _selectedCoPeriods = new List<CompanyPeriod>();

            for (var index = 0; index < lvw.CheckedItems.Count; index++)
                _selectedCoPeriods.Add(lvw.CheckedItems[index].Tag as CompanyPeriod);
        }

        #endregion

        #region Public Methods

        public IList<CompanyPeriod> GetSelectedCoPeriods()
        {
            return _selectedCoPeriods;
        }

        #endregion
    }
}
