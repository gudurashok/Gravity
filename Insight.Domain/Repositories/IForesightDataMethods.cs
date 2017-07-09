using Insight.Domain.Entities;
using Insight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Domain.Repositories
{
    public interface IInsightDataRepository
    {
        IList<ChartOfAccountEntity> GetAllChatOfAccounts();
        IList<AccountEntity> GetAllAccounts();
        IList<DaybookEntity> GetAllDaybooks();
        IList<AccountOpeningBalanceEntity> GetAccountOpeningBalances();
        IList<CashReceiptEntity> GetAllCashReceipts();
        IList<CashPaymentEntity> GetAllCashPayments();
        IList<BankReceiptEntity> GetAllBankReceipts();
        IList<BankPaymentEntity> GetAllBankPayments();
        IList<JournalVoucherEntity> GetAllJournalVouchers();
    }
}
