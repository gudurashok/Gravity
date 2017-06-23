using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class CompanyListItem
    {
        public Company Company { get; set; }

        public string Name
        {
            get { return Company.Entity.Name; }
        }

        public string Code
        {
            get { return Company.Entity.Code; }
        }

        public string Party
        {
            get { return Company.Party.ToString(); }
        }
    }
}
