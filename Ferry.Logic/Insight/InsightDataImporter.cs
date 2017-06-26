using Ferry.Logic.Model;
using Foresight.Logic.DataAccess;
using Gravity.Root.Model;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry.Logic.Insight
{
    public class InsightDataImporter
    {
        CompanyGroup _companyGroup;
        CompanyPeriod _companyPeriod;
        InsightDataExtractor _dataExtractor;
        DataContext _targetDbContext;

        public InsightDataImporter(CompanyGroup companyGroup, CompanyPeriod companyPeriod)
        {
            _companyGroup = companyGroup;
            _companyPeriod = companyPeriod;
            createTargetDatabaseContext();
            setForesightCompanyPeriod();
        }

        private void createTargetDatabaseContext()
        {
            _targetDbContext = new DataContext(_companyGroup);
            _targetDbContext.BeginTransaction();
        }

        private void setForesightCompanyPeriod()
        {
            _companyPeriod.Foresight = _targetDbContext
                    .GetForesightCompanyPeriod(_companyPeriod.Entity.ForesighId);
        }

        public void Execute()
        {
            try
            {
                _targetDbContext.DeleteCompanyPeriodData(_companyPeriod, true);
                extract();
                importTransactions();
                updateCompanyPeriod();
                //completeImport();
                _targetDbContext.Commit();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _targetDbContext.Dispose();
            }
        }

        //private void completeImport()
        //{
        //    _targetDbContext.SetCompanyPeriodIsImported(_companyPeriod, true);
        //}

        private void updateCompanyPeriod()
        {
            _targetDbContext.SetCompanyPeriodColumnValue(_companyPeriod);
        }

        private void extract()
        {
            _dataExtractor = new InsightDataExtractor();
            _dataExtractor.Extract();
        }

        private void importTransactions()
        {
            importAccountOpeningBalances();
            //importSaleInvoices();
            //importPurchaseInvoices();
            //importCashTransactions();
            //importBankTransactions();
            //importCreditNotes();
            //importDebitNotes();
            //importJournalVoucher();
            //importItemLots();
            //importInventoryIssue();
            //importInventoryReceives();
            //importMiscInventoryIssues();
        }

        private void importAccountOpeningBalances()
        {
            loadAccountOpeningBalances(getAccountOpeningBalances());
        }

        private IEnumerable<SourceAccount> getAccountOpeningBalances()
        {
            return _dataExtractor.SourceAccounts.Where(a => a.OpeningBalance != 0);
        }

        private void loadAccountOpeningBalances(IEnumerable<SourceAccount> sourceAccounts)
        {
            foreach (var aob in sourceAccounts.Select(getAccountOpeningBalance))
                _targetDbContext.SaveAccountOpeningBalance(aob);
        }

        private AccountOpeningBalance getAccountOpeningBalance(SourceAccount sourceAccount)
        {
            var aob = new AccountOpeningBalance();
            aob.Account = loadAccount(sourceAccount.Code);
            aob.Date = _companyPeriod.Period.Entity.Financial.From;
            aob.Amount = sourceAccount.OpeningBalance;
            return aob;
        }

        private Account loadAccount(string accountCode)
        {
            var account = getAccount(accountCode);

            if (!string.IsNullOrWhiteSpace(account.Id))
                return new Account(account);

            var result = _targetDbContext.GetAccountByNameAndAddress(account);
            if (result == null)
            {
                _targetDbContext.SaveAccount(account);
                return new Account(account);
            }

            return result;
        }

        private AccountEntity getAccount(string accountCode)
        {
            return _dataExtractor.Accounts.SingleOrDefault(a => a.Code == accountCode)
                            ?? createDummyAccount(accountCode);
        }

        private AccountEntity createDummyAccount(string accountCode)
        {
            return new AccountEntity
            {
                Code = accountCode,
                Name = getDummyName(accountCode),
                ChartOfAccountId = loadChartOfAccount("99").Entity.Id
            };
        }

        private string getDummyName(string name)
        {
            return string.Format("{0} not found", name);
        }

        private ChartOfAccount loadChartOfAccount(string glgCode)
        {
            var coaId = _dataExtractor.ChartOfAccountsMapper
                            .Where(c => c.EasyCode == glgCode)
                            .Select(c => c.ChartOfAccountId)
                            .SingleOrDefault();

            var coa = _dataExtractor.ChartOfAccounts
                            .Where(c => c.Entity.Id == coaId ||
                                    c.Entity.Name == getDummyName(glgCode))
                            .SingleOrDefault();
            return coa ?? createChartOfAccount(glgCode);
        }

        private ChartOfAccount createChartOfAccount(string glgCode)
        {
            ChartOfAccount parent = null;

            if (glgCode.Length == 5)
                parent = loadChartOfAccount(glgCode.Substring(0, 3));

            return insertChartOfAccount(glgCode, parent);
        }

        private ChartOfAccount insertChartOfAccount(string glgCode, ChartOfAccount parent)
        {
            var coa = new ChartOfAccount(new ChartOfAccountEntity());
            coa.Entity.Name = getDummyName(glgCode);
            coa.Entity.Nr = _dataExtractor.ChartOfAccounts.Max(c => c.Entity.Nr) + 1;
            coa.Parent = parent;

            _dataExtractor.ChartOfAccounts.Add(coa);
            _targetDbContext.SaveChartOfAccount(coa);

            return coa;
        }
    }
}
