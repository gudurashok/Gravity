using System;
using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;

namespace Synergy.UC.Controls
{
    public partial class URecurrence : UFormBase
    {
        #region Internal Declarations

        public event EventHandler RecurrenceSaved;
        public event EventHandler RecurrenceRemoved;
        public RecurrenceEntity Recurrence;

        #endregion

        #region Constructors

        public URecurrence()
        {
            InitializeComponent();
        }

        #endregion

        #region Initailization

        public void Initialize(RecurrenceEntity recurrence)
        {
            loadDropdowns();
            btnRemoveRecurrence.Enabled = recurrence != null;
            Recurrence = recurrence ?? new RecurrenceEntity();
            fillForm();
            setPatternPanelStates();
            setControlsValue();
            hookBasicEventHandlers();

            if (Recurrence.DaysOfWeek == 0)
                setSelectedDaysOfWeek();

            hookOtherEventHandlers();
        }

        void rbRegenNewTask_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(regenNewTask, sender);
        }

        void regenNewTask(object sender)
        {
            var rb = sender as iRadioButton;
            setEndByState(rb != null && !rb.Checked);
            setDuplicateTaskState(rb != null && !rb.Checked);

            if (!rbEndBy.Enabled && rbEndBy.Checked)
                rbNoEnd.Checked = true;
        }

        private void rbRepeatFrom_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setRepeatFromPanelStates);
        }

        private void setRepeatFromPanelStates()
        {
            grbPattern.Enabled = rbRepeatFromDueDate.Checked;
            dtpStartDate.Enabled = rbRepeatFromDueDate.Checked;
            chkDuplicateIfUnDone.Enabled = rbRepeatFromDueDate.Checked;
        }

        private void rbPatternType_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setPatternPanelStates);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSaveRecurrence);
        }

        void processSaveRecurrence()
        {
            fillObject();
            OnRecurrenceSaved(new EventArgs());
        }

        private void btnRemoveRecurrence_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(raiseRecurrenceRemovedEvent);
        }

        void raiseRecurrenceRemovedEvent()
        {
            OnRecurrenceRemoved(new EventArgs());
        }

        #region UI Interaction Event Handlers

        private void txtDailyInterval_TextChanged(object sender, EventArgs e)
        {
            rbDailyInterval.Checked = true;
        }

        private void txtDailyRegenNewTaskInterval_TextChanged(object sender, EventArgs e)
        {
            rbDailyRegenNewTask.Checked = true;
        }

        private void txtWeeklyInterval_TextChanged(object sender, EventArgs e)
        {
            rbWeeklyInterval.Checked = true;
        }

        private void chkDayOfWeek_CheckedChanged(object sender, EventArgs e)
        {
            rbWeeklyInterval.Checked = true;

            if (noDaySelected() || Recurrence.Type != RecurrenceType.Weekly)
                return;

            refreshForm();
        }

        private bool noDaySelected()
        {
            return !chkSunday.Checked
                    && !chkMonday.Checked
                    && !chkTuesday.Checked
                    && !chkWednesday.Checked
                    && !chkThursday.Checked
                    && !chkFriday.Checked
                    && !chkSaturday.Checked;
        }

        private void txtWeeklyRegenNewTaskInterval_TextChanged(object sender, EventArgs e)
        {
            rbWeeklyRegenNewTask.Checked = true;
        }

        private void txtMonthlyInterval_TextChanged(object sender, EventArgs e)
        {
            rbMonthlyInterval.Checked = true;
        }

        private void txtMonthlyDayOfMonth_TextChanged(object sender, EventArgs e)
        {
            rbMonthlyInterval.Checked = true;
        }

        private void txtMonthlyInterval2_TextChanged(object sender, EventArgs e)
        {
            rbMonthlyDayOfWeek.Checked = true;
        }

        private void cmbMonthlyDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbMonthlyDayOfWeek.Checked = true;
        }

        private void cmbMonthlyDayOfWeekIndexType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbMonthlyDayOfWeek.Checked = true;
        }

        private void txtMonthlyRegenNewTaskInterval_TextChanged(object sender, EventArgs e)
        {
            rbMonthlyRegenNewTask.Checked = true;
        }

        private void cmbYearlyIntervalMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbYearlyInterval.Checked = true;
        }

        private void txtYearlyInterval_TextChanged(object sender, EventArgs e)
        {
            rbYearlyInterval.Checked = true;
        }

        private void cmbYearlyMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbYearlyDayOfWeek.Checked = true;
        }

        private void cmbYearlyDayOfWeekIndexType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbYearlyDayOfWeek.Checked = true;
        }

        private void cmbYearlyDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbYearlyDayOfWeek.Checked = true;
        }

        private void txtYearlyRegenNewTaskInterval_TextChanged(object sender, EventArgs e)
        {
            rbYearlyRegenNewTask.Checked = true;
        }

        private void txtOccurrences_TextChanged(object sender, EventArgs e)
        {
            rbOccurrences.Checked = true;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            rbEndBy.Checked = true;
        }

        #endregion

        #endregion

        #region Internal Methods

        private void hookBasicEventHandlers()
        {
            #region Events for switching panels

            rbRepeatFromDueDate.CheckedChanged += rbRepeatFrom_CheckedChanged;
            rbRepeatFromDateCompleted.CheckedChanged += rbRepeatFrom_CheckedChanged;

            rbDaily.CheckedChanged += rbPatternType_CheckedChanged;
            rbWeekly.CheckedChanged += rbPatternType_CheckedChanged;
            rbMonthly.CheckedChanged += rbPatternType_CheckedChanged;
            rbYearly.CheckedChanged += rbPatternType_CheckedChanged;

            #endregion

            #region Events for weekdays

            chkSunday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkMonday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkTuesday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkWednesday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkThursday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkFriday.CheckedChanged += chkDayOfWeek_CheckedChanged;
            chkSaturday.CheckedChanged += chkDayOfWeek_CheckedChanged;

            #endregion

            #region Events for Regenerating tasks

            rbDailyRegenNewTask.CheckedChanged += rbRegenNewTask_CheckedChanged;
            rbWeeklyRegenNewTask.CheckedChanged += rbRegenNewTask_CheckedChanged;
            rbMonthlyRegenNewTask.CheckedChanged += rbRegenNewTask_CheckedChanged;
            rbYearlyRegenNewTask.CheckedChanged += rbRegenNewTask_CheckedChanged;

            #endregion
        }

        private void hookOtherEventHandlers()
        {
            #region Events for refreshing form with new Date calculations

            rbDailyInterval.Leave += radioButton_Leave;
            rbEveryWeekday.Leave += radioButton_Leave;

            rbWeeklyInterval.Leave += radioButton_Leave;

            rbMonthlyInterval.Leave += radioButton_Leave;
            rbMonthlyDayOfWeek.Leave += radioButton_Leave;

            rbYearlyInterval.Leave += radioButton_Leave;
            rbYearlyDayOfWeek.Leave += radioButton_Leave;

            txtDailyInterval.Leave += control_Leave;

            txtMonthlyDayOfMonth.Leave += control_Leave;
            txtMonthlyInterval.Leave += control_Leave;

            cmbMonthlyDayOfWeek.Leave += control_Leave;
            cmbMonthlyDayOfWeekIndexType.Leave += control_Leave;
            txtMonthlyInterval2.Leave += control_Leave;

            cmbYearlyIntervalMonth.Leave += control_Leave;
            txtYearlyInterval.Leave += control_Leave;

            cmbYearlyDayOfWeek.Leave += control_Leave;
            cmbYearlyDayOfWeekIndexType.Leave += control_Leave;
            cmbYearlyMonth.Leave += control_Leave;

            dtpStartDate.Leave += control_Leave;
            txtOccurrences.Leave += control_Leave;

            #endregion
        }

        private void radioButton_Leave(object sender, EventArgs e)
        {
            if (((iRadioButton)sender).Checked)
                EventHandlerExecutor.Execute(setControlsValue);

            refreshForm();
        }

        private void setControlsValue()
        {
            setSelectedDaysOfWeek();

            txtMonthlyDayOfMonth.Text = dtpStartDate.Value.Day.ToString();

            getDayOfWeek(cmbMonthlyDayOfWeek);
            getDayOfWeekIndexType(cmbMonthlyDayOfWeekIndexType);

            cmbYearlyIntervalMonth.SelectedIndex = dtpStartDate.Value.Month - 1;
            txtYearlyInterval.Text = dtpStartDate.Value.Day.ToString();

            getDayOfWeek(cmbYearlyDayOfWeek);
            getDayOfWeekIndexType(cmbYearlyDayOfWeekIndexType);
            cmbYearlyMonth.SelectedIndex = dtpStartDate.Value.Month - 1;

        }

        private void getDayOfWeek(iComboBox comboBox)
        {
            var count = 0;
            var day = dtpStartDate.Value.Day;

            while (day > 0)
            {
                day = day - 7;
                count++;
            }

            comboBox.SelectedIndex = count - 1;
        }

        private void getDayOfWeekIndexType(iComboBox comboBox)
        {
            comboBox.SelectedIndex =
                comboBox.Items.IndexOf(
                    comboBox.Items.Cast<KeyValuePair<int, string>>()
                        .FirstOrDefault(i => i.Value == dtpStartDate.Value.DayOfWeek.ToString()));
        }

        private void control_Leave(object sender, EventArgs e)
        {
            if ((sender as iTextBox) != null && string.IsNullOrWhiteSpace(((iTextBox)sender).Text))
                ((iTextBox)sender).Text = @"0";

            if ((sender as iComboBox) != null && ((iComboBox)sender).SelectedIndex == -1)
                ((iComboBox)sender).SelectedIndex = 0;

            EventHandlerExecutor.Execute(refreshForm);
        }

        private void setEndByState(bool enabled)
        {
            rbEndBy.Enabled = enabled;
            dtpEndDate.Enabled = enabled;
        }

        private void setDuplicateTaskState(bool enabled)
        {
            chkDuplicateIfUnDone.Enabled = enabled;
            chkDuplicateIfUnDone.Checked = chkDuplicateIfUnDone.Enabled;
        }

        private void loadDropdowns()
        {
            EnumUtil.LoadEnumListItems(cmbMonthlyDayOfWeek, typeof(DayOfWeekType));
            EnumUtil.LoadEnumListItems(cmbMonthlyDayOfWeekIndexType, typeof(DayOfWeekIndexType));
            EnumUtil.LoadEnumListItems(cmbYearlyIntervalMonth, typeof(MonthName));
            EnumUtil.LoadEnumListItems(cmbYearlyDayOfWeek, typeof(DayOfWeekType));
            EnumUtil.LoadEnumListItems(cmbYearlyDayOfWeekIndexType, typeof(DayOfWeekIndexType));
            EnumUtil.LoadEnumListItems(cmbYearlyMonth, typeof(MonthName));
        }

        private void setPatternPanelStates()
        {
            resetPatternPanels();
            pnlDaily.Visible = rbDaily.Checked;
            pnlWeekly.Visible = rbWeekly.Checked;
            pnlMonthly.Visible = rbMonthly.Checked;
            pnlYearly.Visible = rbYearly.Checked;
            setRecurrenceType();
        }

        private void setRecurrenceType()
        {
            if (rbDaily.Checked)
                Recurrence.Type = RecurrenceType.Daily;
            if (rbWeekly.Checked)
                Recurrence.Type = RecurrenceType.Weekly;
            if (rbMonthly.Checked)
                Recurrence.Type = RecurrenceType.Monthly;
            if (rbYearly.Checked)
                Recurrence.Type = RecurrenceType.Yearly;
        }

        private void resetPatternPanels()
        {
            rbDailyInterval.Checked = true;
            rbWeeklyInterval.Checked = true;
            rbMonthlyInterval.Checked = true;
            rbYearlyInterval.Checked = true;
        }

        #region fill Form Methods

        private void fillForm()
        {
            if (Recurrence.RepeatFrom == RecurrenceRepeatFrom.DueDate)
                rbRepeatFromDueDate.Checked = true;
            else
                rbRepeatFromDateCompleted.Checked = true;

            setRepeatFromPanelStates();

            if (Recurrence.Type == RecurrenceType.Daily)
            {
                rbDaily.Checked = true;
                fillFormDailyPattern();
            }
            else if (Recurrence.Type == RecurrenceType.Weekly)
            {
                rbWeekly.Checked = true;
                fillFormWeeklyPattern();
            }
            else if (Recurrence.Type == RecurrenceType.Monthly)
            {
                rbMonthly.Checked = true;
                fillFormMonthlyPattern();
            }
            else
            {
                rbYearly.Checked = true;
                fillFormYearlyPattern();
            }

            fillFormRecurrenceRange();
        }

        private void fillFormDailyPattern()
        {
            if (Recurrence.IsRegenerated)
            {
                txtDailyRegenNewTaskInterval.Text = Recurrence.Interval.ToString();
                rbDailyRegenNewTask.Checked = true;
            }
            else if (Recurrence.Interval == -1)
                rbEveryWeekday.Checked = true;
            else
            {
                txtDailyInterval.Text = Recurrence.Interval.ToString();
                rbDailyInterval.Checked = true;
            }
        }

        private void fillFormWeeklyPattern()
        {
            if (Recurrence.IsRegenerated)
            {
                txtWeeklyRegenNewTaskInterval.Text = Recurrence.Interval.ToString();
                rbWeeklyRegenNewTask.Checked = true;
            }
            else
            {
                txtWeeklyInterval.Text = Recurrence.Interval.ToString();
                setSelectedDaysOfWeek();
                rbWeeklyInterval.Checked = true;
            }
        }

        private void setSelectedDaysOfWeek()
        {
            var isNew = Recurrence.DaysOfWeek == -1;
            chkSunday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Sunday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Sunday);
            chkMonday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Monday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Monday);
            chkTuesday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Tuesday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Tuesday);
            chkWednesday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Wednesday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Wednesday);
            chkThursday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Thursday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Thursday);
            chkFriday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Friday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Friday);
            chkSaturday.Checked = isDayOfWeekSelected((int)DaysOfWeek.Saturday) || (isNew && DateTime.Today.DayOfWeek == DayOfWeek.Saturday);
        }

        private bool isDayOfWeekSelected(int day)
        {
            if (Recurrence.DaysOfWeek == -1)
                return false;

            return (Recurrence.DaysOfWeek & day) == day;
        }

        private void fillFormMonthlyPattern()
        {
            if (Recurrence.IsRegenerated)
            {
                txtMonthlyRegenNewTaskInterval.Text = Recurrence.Interval.ToString();
                rbMonthlyRegenNewTask.Checked = true;
            }
            else if (Recurrence.DayOfMonth == -1)
            {
                cmbMonthlyDayOfWeek.SelectedIndex = (int)Recurrence.DayOfWeek;
                cmbMonthlyDayOfWeekIndexType.SelectedIndex = (int)Recurrence.DayOfWeekIndex;
                txtMonthlyInterval2.Text = Recurrence.Interval.ToString();
                rbMonthlyDayOfWeek.Checked = true;
            }
            else
            {
                txtMonthlyDayOfMonth.Text = Recurrence.DayOfMonth.ToString();
                txtMonthlyInterval.Text = Recurrence.Interval.ToString();
                rbMonthlyInterval.Checked = true;
            }
        }

        private void fillFormYearlyPattern()
        {
            if (Recurrence.IsRegenerated)
            {
                txtYearlyRegenNewTaskInterval.Text = Recurrence.Interval.ToString();
                cmbYearlyIntervalMonth.SelectedIndex = (int)Recurrence.Month - 1;
                rbYearlyRegenNewTask.Checked = true;
            }
            else if (Recurrence.DayOfMonth == -1)
            {
                cmbYearlyDayOfWeek.SelectedIndex = (int)Recurrence.DayOfWeek;
                cmbYearlyDayOfWeekIndexType.SelectedIndex = (int)Recurrence.DayOfWeekIndex;
                cmbYearlyMonth.SelectedIndex = (int)Recurrence.Month - 1;
                rbYearlyDayOfWeek.Checked = true;
            }
            else
            {
                txtYearlyInterval.Text = Recurrence.Interval.ToString();
                rbYearlyInterval.Checked = true;
            }
        }

        private void fillFormRecurrenceRange()
        {
            setRecurrenceStartDate();
            setRecurrenceEndDate();

            if (Recurrence.RangeType == RecurrenceRangeType.NoEnd)
                rbNoEnd.Checked = true;
            else if (Recurrence.RangeType == RecurrenceRangeType.Occurrences)
            {
                txtOccurrences.Text = Recurrence.Occurences.ToString();
                rbOccurrences.Checked = true;
            }
            else
            {
                rbEndBy.Checked = true;
                dtpEndDate.Value = Recurrence.EndDate;
            }

            chkDuplicateIfUnDone.Checked = Recurrence.Duplicate;
        }

        private void refreshForm()
        {
            dtpStartDate.Value = DateTime.Today;
            fillObject();
            fillForm();
        }

        private void setRecurrenceStartDate()
        {
            dtpStartDate.Value = Recurrence.StartDate;
        }

        private void setRecurrenceEndDate()
        {
            if (rbEndBy.Checked)
                return;

            var date = dtpStartDate.Value.Date;
            var task = new TaskEntity();
            task.Recurrence = Recurrence;
            task.Status = TaskStatus.Completed;

            for (int i = 1; i < Convert.ToInt32(txtOccurrences.Text); i++)
            {
                task.DueDate = date;
                date = TaskRecurrence.GetRecurrenceDueDate(task).Value;
            }

            dtpEndDate.Value = date;
        }

        #endregion

        #region fill Object Methods

        private void fillObject()
        {
            if (rbRepeatFromDueDate.Checked)
                Recurrence.RepeatFrom = RecurrenceRepeatFrom.DueDate;
            else
                Recurrence.RepeatFrom = RecurrenceRepeatFrom.DateCompleted;

            Recurrence.IsRegenerated = false;
            Recurrence.DaysOfWeek = -1;

            if (rbDaily.Checked)
            {
                Recurrence.Type = RecurrenceType.Daily;
                fillObjectDailyPattern();
            }
            else if (rbWeekly.Checked)
            {
                Recurrence.Type = RecurrenceType.Weekly;
                fillObjectWeeklyPattern();
            }
            else if (rbMonthly.Checked)
            {
                Recurrence.Type = RecurrenceType.Monthly;
                fillObjectMonthlyPattern();
            }
            else if (rbYearly.Checked)
            {
                Recurrence.Type = RecurrenceType.Yearly;
                fillObjectYearlyPattern();
            }

            fillObjectRecurrenceRange();
        }

        private void fillObjectDailyPattern()
        {
            if (rbDailyInterval.Checked)
                Recurrence.Interval = Convert.ToInt32(txtDailyInterval.Text);
            else if (rbEveryWeekday.Checked)
                Recurrence.Interval = -1;
            else
            {
                Recurrence.IsRegenerated = true;
                Recurrence.Interval = Convert.ToInt32(txtDailyRegenNewTaskInterval.Text);
            }
        }

        private void fillObjectWeeklyPattern()
        {
            if (rbWeeklyInterval.Checked)
            {
                Recurrence.Interval = Convert.ToInt32(txtWeeklyInterval.Text);
                Recurrence.DaysOfWeek = getSelectedDaysOfWeek();
            }
            else
            {
                Recurrence.IsRegenerated = true;
                Recurrence.Interval = Convert.ToInt32(txtWeeklyRegenNewTaskInterval.Text);
            }
        }

        private int getSelectedDaysOfWeek()
        {
            var result = 0;

            if (chkSunday.Checked)
                result |= (int)DaysOfWeek.Sunday;

            if (chkMonday.Checked)
                result |= (int)DaysOfWeek.Monday;

            if (chkTuesday.Checked)
                result |= (int)DaysOfWeek.Tuesday;

            if (chkWednesday.Checked)
                result |= (int)DaysOfWeek.Wednesday;

            if (chkThursday.Checked)
                result |= (int)DaysOfWeek.Thursday;

            if (chkFriday.Checked)
                result |= (int)DaysOfWeek.Friday;

            if (chkSaturday.Checked)
                result |= (int)DaysOfWeek.Saturday;

            return result;
        }

        private void fillObjectMonthlyPattern()
        {
            if (rbMonthlyInterval.Checked)
            {
                Recurrence.DayOfMonth = Convert.ToInt32(txtMonthlyDayOfMonth.Text);
                Recurrence.Interval = Convert.ToInt32(txtMonthlyInterval.Text);
            }
            else if (rbMonthlyDayOfWeek.Checked)
            {
                Recurrence.DayOfMonth = -1;
                Recurrence.DayOfWeek = (DayOfWeekType)cmbMonthlyDayOfWeek.SelectedIndex;
                Recurrence.DayOfWeekIndex = (DayOfWeekIndexType)cmbMonthlyDayOfWeekIndexType.SelectedIndex;
                Recurrence.Interval = Convert.ToInt32(txtMonthlyInterval2.Text);
            }
            else
            {
                Recurrence.DayOfMonth = dtpStartDate.Value.Date.Day;
                Recurrence.IsRegenerated = true;
                Recurrence.Interval = Convert.ToInt32(txtMonthlyRegenNewTaskInterval.Text);
            }
        }

        private void fillObjectYearlyPattern()
        {
            if (rbYearlyInterval.Checked)
            {
                Recurrence.DayOfMonth = dtpStartDate.Value.Date.Day;
                Recurrence.Month = (MonthName)cmbYearlyIntervalMonth.SelectedIndex + 1;
                Recurrence.Interval = Convert.ToInt32(txtYearlyInterval.Text);
            }
            else if (rbYearlyDayOfWeek.Checked)
            {
                Recurrence.DayOfMonth = -1;
                Recurrence.DayOfWeek = (DayOfWeekType)cmbYearlyDayOfWeek.SelectedIndex;
                Recurrence.DayOfWeekIndex = (DayOfWeekIndexType)cmbYearlyDayOfWeekIndexType.SelectedIndex;
                Recurrence.Month = (MonthName)cmbYearlyMonth.SelectedIndex + 1;
            }
            else
            {
                Recurrence.DayOfMonth = dtpStartDate.Value.Date.Day;
                Recurrence.IsRegenerated = true;
                Recurrence.Interval = Convert.ToInt32(txtYearlyRegenNewTaskInterval.Text);
            }
        }

        private void fillObjectRecurrenceRange()
        {
            var recurrenceDueDate = TaskRecurrence.GetRecurrenceDueDate(new TaskEntity { Recurrence = Recurrence, DueDate = dtpStartDate.Value.Date });

            if (recurrenceDueDate != null)
                dtpStartDate.Value = recurrenceDueDate.Value.Date;

            Recurrence.StartDate = dtpStartDate.Value;

            if (rbNoEnd.Checked)
                Recurrence.RangeType = RecurrenceRangeType.NoEnd;
            else if (rbOccurrences.Checked)
            {
                Recurrence.RangeType = RecurrenceRangeType.Occurrences;
                Recurrence.Occurences = Convert.ToInt32(txtOccurrences.Text);
            }
            else if (rbEndBy.Checked)
                Recurrence.RangeType = RecurrenceRangeType.EndByDate;

            Recurrence.EndDate = dtpEndDate.Value;
            Recurrence.Duplicate = chkDuplicateIfUnDone.Checked;
        }

        #endregion

        #endregion

        #region Event Handlers

        protected virtual void OnRecurrenceRemoved(EventArgs e)
        {
            if (RecurrenceRemoved != null)
                RecurrenceRemoved(this, e);
        }

        protected virtual void OnRecurrenceSaved(EventArgs e)
        {
            if (RecurrenceSaved != null)
                RecurrenceSaved(this, e);
        }

        #endregion
    }
}
