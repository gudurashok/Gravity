using System;
using System.Collections.Generic;
using System.Linq;
using Ferry.Logic.Model;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Gravity.Root.Common;

namespace Ferry.Logic.Insight
{
    public class InsightDataExtractor
    {
        readonly CompanyPeriod _companyPeriod;
        readonly IInsightDataRepository _insightDataRepository;
        readonly DataContext _targetDbContext;
        IList<ChartOfAccount> _cachedTargetChartOfAccounts;
        IList<Daybook> _cachedTargetDaybooks;

        public IList<ChartOfAccountMapper> ChartOfAccountsMapper;
        public IList<ChartOfAccountEntity> SourceChartOfAccounts;
        public IList<AccountEntity> SourceAccounts;
        public IList<DaybookEntity> SourceDaybooks;

        public IList<CashReceiptEntity> SourceCashReceipts;
        public IList<CashPaymentEntity> SourceCashPayments;
        public IList<BankReceiptEntity> SourceBankReceipts;
        public IList<BankPaymentEntity> SourceBankPayments;
        public IList<JournalVoucherEntity> SourceJournalVouchers;

        public IList<ForesightChartOfAccount> TargetChartOfAccounts;
        public IList<ForesightAccount> TargetAccounts;
        public IList<ForesightDaybook> TargetDaybooks;

        public InsightDataExtractor(CompanyPeriod companyPeriod, DataContext targetDbContext)
        {
            _companyPeriod = companyPeriod;
            _targetDbContext = targetDbContext;
            _insightDataRepository = new InsightDataRepository(_companyPeriod);
        }

        public void Extract()
        {
            extractMasters();
            transformMasters();
            extractTransactions();
        }

        private void extractMasters()
        {
            readChartOfAccountsMapper();
            readSourceChartOfAccounts();
            readSourceAccounts();
            reaadSourceDaybooks();
        }

        private void readChartOfAccountsMapper()
        {
            ChartOfAccountsMapper = ForesightDatabaseFactory
                                    .GetInstance()
                                    .GetChartOfAccountsMapper();
        }

        private void readSourceChartOfAccounts()
        {
            SourceChartOfAccounts = _insightDataRepository.GetAllChatOfAccounts();
        }

        private void readSourceAccounts()
        {
            SourceAccounts = _insightDataRepository.GetAllAccounts();
        }

        private void reaadSourceDaybooks()
        {
            SourceDaybooks = _insightDataRepository.GetAllDaybooks();
        }

        private void extractTransactions()
        {
            readSourceTransactions();
        }

        private void readSourceTransactions()
        {
            readCashReceipts();
            readCashPayments();
            readBankReceipts();
            readBankPayments();
            readJournalVouchers();
        }

        private void readCashReceipts()
        {
            SourceCashReceipts = _insightDataRepository.GetAllCashReceipts();
        }

        private void readCashPayments()
        {
            SourceCashPayments = _insightDataRepository.GetAllCashPayments();
        }

        private void readBankReceipts()
        {
            SourceBankReceipts = _insightDataRepository.GetAllBankReceipts();
        }

        private void readBankPayments()
        {
            SourceBankPayments = _insightDataRepository.GetAllBankPayments();
        }

        private void readJournalVouchers()
        {
            SourceJournalVouchers = _insightDataRepository.GetAllJournalVouchers();
        }

        private void transformMasters()
        {
            _cachedTargetChartOfAccounts = _targetDbContext.GetChartOfAccounts();
            transformChartOfAccounts();
            transformAccounts();

            _cachedTargetDaybooks = _targetDbContext.GetDaybooks();
            transformDaybooks();
        }

        private void transformChartOfAccounts()
        {
            TargetChartOfAccounts = new List<ForesightChartOfAccount>();
            foreach (var sourceChartOfAccount in SourceChartOfAccounts)
                transformChartOfAccount(sourceChartOfAccount);
        }

        private void transformChartOfAccount(ChartOfAccountEntity sourceChartOfAccount)
        {
            ChartOfAccountEntity parentCoa = null;

            if (string.IsNullOrWhiteSpace(sourceChartOfAccount.ParentId))
            {
                parentCoa = new ChartOfAccountEntity
                {
                    Name = sourceChartOfAccount.Type.ToString().ToUpper(),
                    Type = ChartOfAccountType.None,
                };
            }
            else
            {
                parentCoa = SourceChartOfAccounts
                            .Where(coa => coa.Id == sourceChartOfAccount.ParentId)
                            .SingleOrDefault();

                transformChartOfAccount(parentCoa);
            }

            var foresightCoa = getForesightChartOfAccount(parentCoa, null);
            getForesightChartOfAccount(sourceChartOfAccount, foresightCoa);
        }

        private ForesightChartOfAccount getForesightChartOfAccount(
                                ChartOfAccountEntity sourceChartOfAccount,
                                ForesightChartOfAccount parentCoa)
        {
            var coa = _cachedTargetChartOfAccounts
                        .Where(c => c.Entity.Name == sourceChartOfAccount.Name)
                        .SingleOrDefault();

            ForesightChartOfAccount result = null;
            if (coa == null)
                result = insertChartOfAccount(sourceChartOfAccount, parentCoa);
            else
                result = new ForesightChartOfAccount
                {
                    Entity = sourceChartOfAccount,
                    ForesightId = Convert.ToInt32(coa.Entity.Id),
                    ParentForesightId = coa.Parent == null ? 0 : Convert.ToInt32(coa.Parent.Entity.Id),
                };

            TargetChartOfAccounts.Add(result);
            return result;
        }

        private ForesightChartOfAccount insertChartOfAccount(
                            ChartOfAccountEntity entity, ForesightChartOfAccount parentCoa)
        {
            var coa = new ChartOfAccount(new ChartOfAccountEntity());
            coa.Entity.Name = entity.Name;
            entity.Nr = _cachedTargetChartOfAccounts.Count > 0
                            ? _cachedTargetChartOfAccounts.Max(tca => tca.Entity.Nr) + 1
                            : 1;
            coa.Entity.Nr = entity.Nr;
            if (parentCoa != null)
            {
                var parentEntity = new ChartOfAccountEntity
                {
                    Id = parentCoa.ForesightId.ToString(),
                    Name = parentCoa.Entity.Name,
                    Nr = parentCoa.Entity.Nr,
                };
                coa.Parent = new ChartOfAccount(parentEntity);
            }
            _targetDbContext.SaveChartOfAccount(coa);
            _cachedTargetChartOfAccounts.Add(coa);
            return new ForesightChartOfAccount()
            {
                Entity = entity,
                ForesightId = Convert.ToInt32(coa.Entity.Id),
                ParentForesightId = parentCoa == null ? 0 : Convert.ToInt32(parentCoa.ParentForesightId),
            };
        }

        private void transformAccounts()
        {
            TargetAccounts = new List<ForesightAccount>();
            fillForesightAccounts(getAccountGroups());
            fillForesightAccounts(getAccounts());
        }

        private IEnumerable<AccountEntity> getAccountGroups()
        {
            return SourceAccounts
                .Where(a => string.IsNullOrWhiteSpace(a.GroupId) || a.Id == a.GroupId);
        }

        private IEnumerable<AccountEntity> getAccounts()
        {
            return SourceAccounts.Where(a => !string.IsNullOrWhiteSpace(a.GroupId) && a.Id != a.GroupId);
        }

        private void fillForesightAccounts(IEnumerable<AccountEntity> sourceAccounts)
        {
            foreach (var sourceAccount in sourceAccounts)
                getForesightAccount(sourceAccount);
        }

        private ForesightAccount getForesightAccount(AccountEntity sourceAccount)
        {
            var targetAccount = _targetDbContext.GetAccountByNameAndAddress(sourceAccount);
            ForesightAccount result = null;
            if (targetAccount == null)
                result = insertAccount(sourceAccount);
            else
                result = new ForesightAccount
                {
                    Entity = sourceAccount,
                    ForesightId = Convert.ToInt32(targetAccount.Entity.Id),
                };

            TargetAccounts.Add(result);
            return result;
        }

        private ForesightAccount insertAccount(AccountEntity account)
        {
            var coa = TargetChartOfAccounts
                        .Where(ca => ca.Entity.Id == account.ChartOfAccountId)
                        .SingleOrDefault();

            var newAccount = new AccountEntity
            {
                Id = account.Id,
                Code = account.Code,
                ChartOfAccountId = coa.ForesightId.ToString(),
                Name = account.Name,
                GroupId = account.GroupId,
                PartyId = account.PartyId,
                AddressLine1 = account.AddressLine1,
                AddressLine2 = account.AddressLine2,
                City = account.City,
                State = account.State,
                Pin = account.Pin,
                IsActive = account.IsActive,
            };

            _targetDbContext.SaveAccount(newAccount);

            return new ForesightAccount()
            {
                Entity = account,
                ForesightId = Convert.ToInt32(newAccount.Id),
            };
        }

        private void transformDaybooks()
        {
            TargetDaybooks = new List<ForesightDaybook>();
            foreach (var daybook in SourceDaybooks)
                getForesightDaybook(daybook);
        }

        private ForesightDaybook getForesightDaybook(DaybookEntity sourceDaybook)
        {
            var targetDaybook = _cachedTargetDaybooks
                        .Where(c => c.Entity.Type == sourceDaybook.Type &&
                               c.Entity.Name == sourceDaybook.Name)
                        .SingleOrDefault();

            ForesightDaybook result = null;
            if (targetDaybook == null)
                result = insertDaybook(sourceDaybook);
            else
                result = new ForesightDaybook
                {
                    Entity = sourceDaybook,
                    ForesightId = Convert.ToInt32(targetDaybook.Entity.Id),
                };

            TargetDaybooks.Add(result);
            return result;
        }

        private ForesightDaybook insertDaybook(DaybookEntity daybookEntity)
        {
            var account = TargetAccounts
                        .Where(a => a.Entity.Id == daybookEntity.AccountId)
                        .SingleOrDefault();

            var accountId = account == null ? "0" : account.ForesightId.ToString();

            var bookEntity = new DaybookEntity
            {
                Id = daybookEntity.Id,
                Type = daybookEntity.Type,
                Code = daybookEntity.Id.Substring(daybookEntity.Id.LastIndexOf("/") + 1),
                Name = daybookEntity.Name,
                AccountId = accountId,
            };

            var daybook = new Daybook(bookEntity);
            var accountEntity = new AccountEntity { Id = accountId };
            daybook.Account = new Account(accountEntity);
            _targetDbContext.SaveDaybook(daybook);
            return new ForesightDaybook()
            {
                Entity = daybookEntity,
                ForesightId = Convert.ToInt32(bookEntity.Id),
            };
        }
    }
}
