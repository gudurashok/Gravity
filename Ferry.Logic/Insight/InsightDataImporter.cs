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
            importCashPayments();
            importBankReceipts();
            importBankPayments();
            importJournalVouchers();

            //importCreditNotes();
            //importDebitNotes();
            //importItemLots();
            //importInventoryIssue();
            //importInventoryReceives();
            //importMiscInventoryIssues();
        }

        #region Cash Receipts

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

        #endregion

        #region Cash Payments

        private void importCashPayments()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Cash))
                loadCashPayments(getCashPayments(daybook.Entity.Id), daybook);
        }

        private void loadCashPayments(IEnumerable<CashPaymentEntity> cashPayments, ForesightDaybook daybook)
        {
            foreach (var cashPayment in cashPayments)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == cashPayment.AccountId)
                                .SingleOrDefault();
                cashPayment.DaybookId = daybook.ForesightId.ToString();
                cashPayment.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveCashPayment(new CashPayment(cashPayment));
            }
        }

        private IEnumerable<CashPaymentEntity> getCashPayments(string daybookId)
        {
            return _dataExtractor.SourceCashPayments.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Bank Receipts

        private void importBankReceipts()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Cash))
                loadBankReceipts(getBankReceipts(daybook.Entity.Id), daybook);
        }

        private void loadBankReceipts(IEnumerable<BankReceiptEntity> bankReceipts, ForesightDaybook daybook)
        {
            foreach (var bankReceipt in bankReceipts)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == bankReceipt.AccountId)
                                .SingleOrDefault();
                bankReceipt.DaybookId = daybook.ForesightId.ToString();
                bankReceipt.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveBankReceipt(new BankReceipt(bankReceipt));
            }
        }

        private IEnumerable<BankReceiptEntity> getBankReceipts(string daybookId)
        {
            return _dataExtractor.SourceBankReceipts.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Bank Payments

        private void importBankPayments()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Cash))
                loadBankPayments(getBankPayments(daybook.Entity.Id), daybook);
        }

        private void loadBankPayments(IEnumerable<BankPaymentEntity> bankPayments, ForesightDaybook daybook)
        {
            foreach (var bankPayment in bankPayments)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == bankPayment.AccountId)
                                .SingleOrDefault();
                bankPayment.DaybookId = daybook.ForesightId.ToString();
                bankPayment.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveBankPayment(new BankPayment(bankPayment));
            }
        }

        private IEnumerable<BankPaymentEntity> getBankPayments(string daybookId)
        {
            return _dataExtractor.SourceBankPayments.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Journal Vouchers

        private void importJournalVouchers()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Cash))
                loadJournalVouchers(getJournalVouchers(daybook.Entity.Id), daybook);
        }

        private void loadJournalVouchers(IEnumerable<JournalVoucherEntity> journalVouchers, ForesightDaybook daybook)
        {
            foreach (var jv in journalVouchers)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == jv.AccountId)
                                .SingleOrDefault();
                jv.DaybookId = daybook.ForesightId.ToString();
                jv.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveJournalVoucher(new JournalVoucher(jv));
            }
        }

        private IEnumerable<JournalVoucherEntity> getJournalVouchers(string daybookId)
        {
            return _dataExtractor.SourceJournalVouchers.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Common

        private IEnumerable<ForesightDaybook> getDaybooksOf(DaybookType type)
        {
            return _dataExtractor.TargetDaybooks.Where(d => d.Entity.Type == type);
        }

        #endregion
    }
}
