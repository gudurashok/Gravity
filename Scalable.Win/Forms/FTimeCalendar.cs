using System;
using System.Windows.Forms;
using Scalable.Win.Events;

namespace Scalable.Win.Forms
{
    public partial class FTimeCalendar : FFormBase
    {
        public DateTime? SelectedDate { get; private set; }
        
        public FTimeCalendar()
        {
            InitializeComponent();
            setTitle();
        }

        private void setTitle()
        {
            lblTitle.Text = @"Select Date Time";
        }

        private void uTimeCalender_DateTimeSelected(object sender, DateTimeEventArgs e)
        {
            SelectedDate = e.SelectedDateTime;
            DialogResult = DialogResult.OK;
        }
    }
}
