using System;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Picklists;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.FormControls;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Events;

namespace Synergy.UC.Controls
{
    public partial class USearchBar : UBaseForm
    {
        #region Declarations

        public event EventHandler<TaskSearchEventArgs> Search;

        #endregion

        #region Constructor

        public USearchBar()
        {
            InitializeComponent();
            setAnchorManually();
        }

        private void setAnchorManually()
        {
            const AnchorStyles anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPriority.Anchor = anchor;
            cmbPriority.Anchor = anchor;
            lblOrderBy.Anchor = anchor;
            cmbOrderBy.Anchor = anchor;
            lblGroupBy.Anchor = anchor;
            cmbGroupBy.Anchor = anchor;
            btnSearch.Anchor = anchor;
            btnReset.Anchor = anchor;
            cmbLocation.Anchor = cmbLocation.Anchor | anchor;
            cmbTaskType.Anchor = cmbTaskType.Anchor | anchor;
            cmbProject.Anchor = cmbProject.Anchor | anchor;
        }

        #endregion

        #region Initialize

        public void Initialize()
        {
            loadDropdowns();
            hookEventHandlers();
            txbAssigned.PickList = PicklistFactory.Users.Form;
        }

        private void loadDropdowns()
        {
            EnumUtil.LoadEnumListItems(cmbStatus, typeof(TaskStatus), TaskStatus.Pending);
            EnumUtil.LoadEnumListItems(cmbAssigned, typeof(SearchIn), SearchIn.None);
            EnumUtil.LoadEnumListItems(cmbDateFieldName, typeof(DatePeriodField), DatePeriodField.None);
            EnumUtil.LoadEnumListItems(cmbPriority, typeof(Priority), Priority.None);
            EnumUtil.LoadEnumListItems(cmbOrderBy, typeof(TaskOrderByField), TaskOrderByField.None);
            EnumUtil.LoadEnumListItems(cmbGroupBy, typeof(TaskGroupByField), TaskGroupByField.None);

            var repo = new TaskRepository();
            cmbLocation.Databind("Id", "Name", repo.GetAllLocations(), -1);
            cmbTaskType.Databind("Id", "Name", repo.GetAllTaskTypes(), -1);
            cmbProject.Databind("Id", "Name", repo.GetAllProjects(), -1);
        }

        private void hookEventHandlers()
        {
            cmbDateFieldName.SelectedIndexChanged += datePeriod_SelectedIndexChanged;
            cmbAssigned.SelectedIndexChanged += cmbAssigned_SelectedIndexChanged;
        }

        #endregion

        #region Assignment control status

        private void cmbAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setAssignedControlStatus);
        }

        void setAssignedControlStatus()
        {
            var assignment = cmbAssigned.SelectedIndex == -1
                                ? SearchIn.None
                                : (SearchIn)cmbAssigned.SelectedValue;
            txbAssigned.Enabled = assignment != SearchIn.None;
        }

        #endregion

        #region Date period control state

        private void datePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setDatePeriodControlState);
        }

        private void setDatePeriodControlState()
        {
            var enable = enableDatePeriod();
            dtpFromDate.Enabled = enable;
            dtpFromTime.Enabled = enable;
            dtpToDate.Enabled = enable;
            dtpToTime.Enabled = enable;
        }

        private bool enableDatePeriod()
        {
            var value = cmbDateFieldName.SelectedIndex == -1
                            ? DatePeriodField.None
                            : (DatePeriodField)cmbDateFieldName.SelectedValue;
            return value != DatePeriodField.None;
        }

        #endregion

        #region Create search criteria

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSearch);
        }

        void processSearch()
        {
            var criteria = new TaskSearchCriteria();
            criteria.Status = cmbStatus.SelectedIndex == -1 ? TaskStatus.All : (TaskStatus)cmbStatus.SelectedValue;
            criteria.Priority = cmbPriority.SelectedIndex == -1 ? Priority.None : (Priority)cmbPriority.SelectedValue;
            criteria.OrderBy = cmbOrderBy.SelectedIndex == -1 ? TaskOrderByField.None : (TaskOrderByField)cmbOrderBy.SelectedValue;
            criteria.GroupBy = cmbGroupBy.SelectedIndex == -1 ? TaskGroupByField.None : (TaskGroupByField)cmbGroupBy.SelectedValue;
            criteria.LocationId = cmbLocation.SelectedIndex == -1 ? null : cmbLocation.SelectedValue.ToString();
            criteria.LocationName = cmbLocation.SelectedIndex == -1 ? null : cmbLocation.Text;
            criteria.TaskTypeId = cmbTaskType.SelectedIndex == -1 ? null : cmbTaskType.SelectedValue.ToString();
            criteria.TaskTypeName = cmbTaskType.SelectedIndex == -1 ? null : cmbTaskType.Text;
            criteria.ProjectId = cmbProject.SelectedIndex == -1 ? null : cmbProject.SelectedValue.ToString();
            criteria.ProjectName = cmbProject.SelectedIndex == -1 ? null : cmbProject.Text;
            criteria.SearchIn = cmbAssigned.SelectedIndex == -1 ? SearchIn.None : (SearchIn)cmbAssigned.SelectedValue;
            criteria.SearchUserId = txbAssigned.Value == null ? null : ((UserEntity)txbAssigned.Value).Id;
            criteria.SearchUser = txbAssigned.Value == null ? null : (UserEntity)txbAssigned.Value;
            criteria.DatePeriodField = cmbDateFieldName.SelectedIndex == -1 ? DatePeriodField.None : (DatePeriodField)cmbDateFieldName.SelectedValue;
            if (criteria.DatePeriodField != DatePeriodField.None) criteria.Period = getDatePeriod();
            OnSearch(new TaskSearchEventArgs(criteria));
        }

        private DatePeriod getDatePeriod()
        {
            var result = new DatePeriod();
            result.From = getFromDateTime();
            result.To = dtpToTime.Checked
                            ? getToDateTime()
                            : getToDateTime()
                                .AddDays(1)
                                .AddMilliseconds(-1);
            return result;
        }

        private DateTime getFromDateTime()
        {
            return new DateTime(dtpFromDate.Value.Year,
                                dtpFromDate.Value.Month,
                                dtpFromDate.Value.Day,
                                dtpFromTime.Checked ? dtpFromTime.Value.Hour : 0,
                                dtpFromTime.Checked ? dtpFromTime.Value.Minute : 0,
                                0);
        }

        private DateTime getToDateTime()
        {
            return new DateTime(dtpToDate.Value.Year,
                                dtpToDate.Value.Month,
                                dtpToDate.Value.Day,
                                dtpToTime.Checked ? dtpToTime.Value.Hour : 0,
                                dtpToTime.Checked ? dtpToTime.Value.Minute : 0,
                                0);
        }

        protected virtual void OnSearch(TaskSearchEventArgs e)
        {
            if (Search != null)
                Search(this, e);
        }

        #endregion

        #region Reset search criteria

        private void btnReset_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(resetSearchBar);
        }

        void resetSearchBar()
        {
            var criteria = new TaskSearchCriteria();
            EnumUtil.SetEnumListItem(cmbStatus, criteria.Status);
            EnumUtil.SetEnumListItem(cmbPriority, criteria.Priority);
            EnumUtil.SetEnumListItem(cmbOrderBy, criteria.OrderBy);
            EnumUtil.SetEnumListItem(cmbGroupBy, criteria.GroupBy);
            cmbLocation.SelectedIndex = -1;
            cmbTaskType.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            EnumUtil.SetEnumListItem(cmbAssigned, criteria.SearchIn);
            EnumUtil.SetEnumListItem(cmbDateFieldName, criteria.DatePeriodField);
            OnSearch(new TaskSearchEventArgs(criteria));
        }

        #endregion
    }
}
