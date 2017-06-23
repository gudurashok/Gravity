using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class ChartOfAccountListItem
    {
        public ChartOfAccount ChartOfAccount { get; set; }

        public string Name
        {
            get { return ChartOfAccount.Entity.Name; }
        }

        public string Type
        {
            get { return ChartOfAccount.Entity.Type.ToString(); }
        }

        public string Parent
        {
            get { return ChartOfAccount.Parent.Entity.Name; }
        }
    }
}
