using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class DaybookListItem
    {
        public Daybook Daybook { get; set; }

        public string Name
        {
            get { return Daybook.Entity.Name; }
        }

        public string Type
        {
            get { return Daybook.Entity.Type.ToString(); }
        }

        public string Account
        {
            get { return Daybook.Account == null ? string.Empty : Daybook.Account.Entity.Name; }
        }
    }
}
