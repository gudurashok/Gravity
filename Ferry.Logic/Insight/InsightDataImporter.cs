using Ferry.Logic.Model;
using Foresight.Logic.DataAccess;
using Gravity.Root.Model;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
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
                completeImport();
                _targetDbContext.Commit();
            }
            finally
            {
                _targetDbContext.Dispose();
            }
        }

        private void completeImport()
        {
            _targetDbContext.SetCompanyPeriodIsImported(_companyPeriod, true);
        }

        private void updateCompanyPeriod()
        {
            _targetDbContext.SetCompanyPeriodColumnValue(_companyPeriod);
        }

        private void extract()
        {
            _dataExtractor = new InsightDataExtractor(_companyPeriod, _targetDbContext);
            _dataExtractor.Extract();
        }

        private void importTransactions()
        {
            //importAccountOpeningBalances();
            //importSaleInvoices();
            //importPurchaseInvoices();
            importCashReceipts();
            //importCashPayments();
            //importBankTransactions();
            //importCreditNotes();
            //importDebitNotes();
            //importJournalVoucher();
            //importItemLots();
            //importInventoryIssue();
            //importInventoryReceives();
            //importMiscInventoryIssues();
        }

        private void importCashReceipts()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Cash))
                loadCashReceipts(getCashReceipts(daybook.Entity.Id), daybook);
        }

        private void loadCashReceipts(IEnumerable<CashReceiptEntity> cashReceipts, ForesightDaybook daybook)
        {
            foreach (var cashReceipt in cashReceipts)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == cashReceipt.AccountId)
                                .SingleOrDefault();
                cashReceipt.DaybookId = daybook.ForesightId.ToString();
                cashReceipt.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveCashReceipt(new CashReceipt(cashReceipt));
            }
        }

        private IEnumerable<CashReceiptEntity> getCashReceipts(string daybookId)
        {
            return _dataExtractor.SourceCashReceipts.Where(t => t.DaybookId == daybookId);
        }

        private IEnumerable<ForesightDaybook> getDaybooksOf(DaybookType type)
        {
            return _dataExtractor.TargetDaybooks.Where(d => d.Entity.Type == type);
        }
    }
}
