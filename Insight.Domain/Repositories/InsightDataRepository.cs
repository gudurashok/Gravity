using System;
using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Mingle.Domain.Repositories;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class InsightDataRepository : RepositoryBase, IInsightDataRepository
    {
        CompanyPeriod _companyPeriod;

        public InsightDataRepository(CompanyPeriod companyPeriod)
        {
            _companyPeriod = companyPeriod;
        }

        public IList<ChartOfAccountEntity> GetAllChatOfAccounts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<ChartOfAccountEntity>()
                        .OrderBy(c => c.Name)
                        .ToList();
            }
        }

        public IList<AccountEntity> GetAllAccounts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<AccountEntity>()
                        .OrderBy(c => c.Name)
                        .ToList();
            }
        }

        public IList<DaybookEntity> GetAllDaybooks()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<DaybookEntity>()
                        .OrderBy(c => c.Name)
                        .ToList();
            }
        }

        public IList<CashReceiptEntity> GetAllCashReceipts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CashReceiptEntity>()
                        .Where(doc => doc.CompanyPeriodId == _companyPeriod.Entity.Id)
                        .OrderBy(doc => doc.DaybookId)
                        .OrderBy(doc => doc.Date)
                        .OrderBy(doc => doc.Id)
                        .ToList();
            }
        }

        public IList<CashPaymentEntity> GetAllCashPayments()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CashPaymentEntity>()
                        .Where(doc => doc.CompanyPeriodId == _companyPeriod.Entity.Id)
                        .OrderBy(doc => doc.DaybookId)
                        .OrderBy(doc => doc.Date)
                        .OrderBy(doc => doc.Id)
                        .ToList();
            }
        }

        public IList<BankReceiptEntity> GetAllBankReceipts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<BankReceiptEntity>()
                        .Where(doc => doc.CompanyPeriodId == _companyPeriod.Entity.Id)
                        .OrderBy(doc => doc.DaybookId)
                        .OrderBy(doc => doc.Date)
                        .OrderBy(doc => doc.Id)
                        .ToList();
            }
        }

        public IList<BankPaymentEntity> GetAllBankPayments()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<BankPaymentEntity>()
                        .Where(doc => doc.CompanyPeriodId == _companyPeriod.Entity.Id)
                        .OrderBy(doc => doc.DaybookId)
                        .OrderBy(doc => doc.Date)
                        .OrderBy(doc => doc.Id)
                        .ToList();
            }
        }

        public IList<JournalVoucherEntity> GetAllJournalVouchers()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<JournalVoucherEntity>()
                        .Where(doc => doc.CompanyPeriodId == _companyPeriod.Entity.Id)
                        .OrderBy(doc => doc.DaybookId)
                        .OrderBy(doc => doc.Date)
                        .OrderBy(doc => doc.Id)
                        .ToList();
            }
        }
    }
}
