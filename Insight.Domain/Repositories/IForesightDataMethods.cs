using Insight.Domain.Entities;
using Insight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Domain.Repositories
{
    public interface IForesightDataMethods
    {
        IList<AccountEntity> GetAllAccounts();
        IList<ChartOfAccountEntity> GetAllChatOfAccounts();
    }
}
