using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class AccountListItem
    {
        public Account Account { get; set; }

        public string Name
        {
            get { return Account.Entity.Name; }
        }

        public string Party
        {
            get { return Account.Party.Entity.Name; }
        }

        public string ChartOfAccount
        {
            get { return Account.ChartOfAccount.Entity.Name; }
        }

        public string Group
        {
            get { return Account.Group.Entity.Name; }
        }
    }
}
