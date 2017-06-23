using System;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Events;

namespace Scalable.Win.FormControls
{
    public partial class UTimeCalendar : UserControl
    {
        public event EventHandler<DateTimeEventArgs> DateTimeSelected;
        private DateTime selectedDate;

        public UTimeCalendar()
        {
            InitializeComponent();
            monthCalendar.SetDate(DateTime.Now);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OnDateTimeSelected(new DateTimeEventArgs(selectedDate));
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            EventHandlerExecutor.Execute(setDateTime, sender, e);
        }

        void setDateTime(object sender, EventArgs e)
        {
            var args = (DateRangeEventArgs)e;

            selectedDate = args.End.Date;
            setTimePart();
        }

        protected virtual void OnDateTimeSelected(DateTimeEventArgs e)
        {
            if (DateTimeSelected != null)
                DateTimeSelected(this, e);
        }

        private void dateTimePicker_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setTimePart);
        }

        private void setTimePart()
        {
            selectedDate = dateTimePicker.Checked
                               ? new DateTime(selectedDate.Date.Year, selectedDate.Date.Month,
                                                selectedDate.Date.Day, dateTimePicker.Value.Hour,
                                                dateTimePicker.Value.Minute, dateTimePicker.Value.Second)
                               : selectedDate.Date;
        }
    }
}
