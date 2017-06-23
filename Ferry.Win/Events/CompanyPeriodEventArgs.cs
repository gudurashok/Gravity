using System;
using System.Windows.Forms;
using Insight.Domain.Model;

namespace Ferry.Win.Events
{
    public class CompanyPeriodEventArgs : EventArgs
    {
        public CompanyPeriod CompanyPeriod { get; set; }
        public DialogResult Result { get; set; }

        public CompanyPeriodEventArgs(CompanyPeriod companyPeriod)
        {
            CompanyPeriod = companyPeriod;
            Result = DialogResult.None;
        }
    }
}
