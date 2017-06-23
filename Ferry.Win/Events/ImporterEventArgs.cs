using System;
using System.Collections.Generic;
using Insight.Domain.Model;

namespace Ferry.Win.Events
{
    public class ImporterEventArgs : EventArgs
    {
        public IList<CompanyPeriod> SelectedCompanyPeriods { get; set; }

        public ImporterEventArgs(IList<CompanyPeriod> selectedCompanyPeriods)
        {
            SelectedCompanyPeriods = selectedCompanyPeriods;
        }
    }
}
