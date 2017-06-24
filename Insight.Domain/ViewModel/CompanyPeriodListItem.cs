using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class CompanyPeriodListItem
    {
        public CompanyPeriod CompanyPeriod { get; set; }

        public string Company
        {
            get { return CompanyPeriod.Company.Entity.Name; }
        }

        public string Period
        {
            get { return CompanyPeriod.Period.Entity.Name; }
        }

        public string Path
        {
            get { return CompanyPeriod.Entity.SourceDataPath; }
        }

        public string Provider
        {
            get { return CompanyPeriod.Entity.SourceDataProvider.ToString(); }
        }

        public string Imported
        {
            get { return CompanyPeriod.Entity.IsImported ? "Yes" : "No"; }
        }
    }
}
