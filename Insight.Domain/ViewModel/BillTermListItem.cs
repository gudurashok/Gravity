using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class BillTermListItem
    {
        public BillTerm BillTerm { get; set; }

        public string Name
        {
            get { return BillTerm.Daybook.Entity.Name; }
        }

        public string Code
        {
            get { return BillTerm.Entity.Code.ToString(); }
        }

        public string Description
        {
            get { return BillTerm.Entity.Description; }
        }
    }
}
