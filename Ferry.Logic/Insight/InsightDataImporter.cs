﻿using Ferry.Logic.Model;
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
using Gravity.Root.Common;
using Foresight.Logic.Ledger;

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

                var lb = new LedgerBuilder(_targetDbContext, _companyPeriod);
                lb.BuildDimensionTables();
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
            importAccountOpeningBalances();
            importCashReceipts();
            importCashPayments();
            importBankReceipts();
            importBankPayments();
            importJournalVouchers();
            importCreditNotes();
            importDebitNotes();
            importSaleInvoices();
            importPurchaseInvoices();

            //importItemLots();
            //importInventoryIssue();
            //importInventoryReceives();
            //importMiscInventoryIssues();
        }

        #region Account Opening Balance

        private void importAccountOpeningBalances()
        {
            loadAccountOpeningBalances(_dataExtractor.SourceAccountOpeningBalances);
        }

        private void loadAccountOpeningBalances(IEnumerable<AccountOpeningBalanceEntity> openingBalances)
        {
            foreach (var aob in openingBalances)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == aob.AccountId)
                                .SingleOrDefault();
                aob.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveAccountOpeningBalance(aob);
            }
        }

        #endregion

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
            foreach (var daybook in getDaybooksOf(DaybookType.Bank))
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
            foreach (var daybook in getDaybooksOf(DaybookType.Bank))
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
            foreach (var daybook in getDaybooksOf(DaybookType.JournalVoucher))
                loadJournalVouchers(getJournalVouchers(daybook.Entity.Id), daybook);
        }

        private void loadJournalVouchers(IEnumerable<JournalVoucherEntity> journalVouchers, ForesightDaybook daybook)
        {
            foreach (var jv in journalVouchers)
            {
                jv.DaybookId = daybook.ForesightId.ToString();

                var voucher = createJV(jv, jv.CreditAccountId, (int)TxnType.Credit, jv.NotesCredit);
                _targetDbContext.SaveJournalVoucher(new JournalVoucher(voucher));

                voucher = createJV(jv, jv.DebitAccountId, (int)TxnType.Debit, jv.NotesDebit);
                _targetDbContext.SaveJournalVoucher(new JournalVoucher(voucher));
            }
        }

        private JournalVoucherEntity createJV(JournalVoucherEntity jv,
                                            string accountId, int txnType, string notes)
        {
            var result = jv.Clone();
            var account = _dataExtractor.TargetAccounts
                            .Where(a => a.Entity.Id == accountId)
                            .SingleOrDefault();
            result.AccountId = account.ForesightId.ToString();
            result.TxnType = txnType;
            result.Notes = notes;
            return result;
        }

        private IEnumerable<JournalVoucherEntity> getJournalVouchers(string daybookId)
        {
            return _dataExtractor.SourceJournalVouchers.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Credit Notes

        private void importCreditNotes()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.CreditNote))
                loadCreditNotes(getCreditNotes(daybook.Entity.Id), daybook);
        }

        private void loadCreditNotes(IEnumerable<CreditNoteEntity> creditNotes, ForesightDaybook daybook)
        {
            foreach (var creditNote in creditNotes)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == creditNote.AccountId)
                                .SingleOrDefault();
                creditNote.DaybookId = daybook.ForesightId.ToString();
                creditNote.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveCreditNote(new CreditNote(creditNote));
            }
        }

        private IEnumerable<CreditNoteEntity> getCreditNotes(string daybookId)
        {
            return _dataExtractor.SourceCreditNotes.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Debit Notes

        private void importDebitNotes()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.DebitNote))
                loadDebitNotes(getDebitNotes(daybook.Entity.Id), daybook);
        }

        private void loadDebitNotes(IEnumerable<DebitNoteEntity> debitNotes, ForesightDaybook daybook)
        {
            foreach (var debitNote in debitNotes)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == debitNote.AccountId)
                                .SingleOrDefault();
                debitNote.DaybookId = daybook.ForesightId.ToString();
                debitNote.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveDebitNote(new DebitNote(debitNote));
            }
        }

        private IEnumerable<DebitNoteEntity> getDebitNotes(string daybookId)
        {
            return _dataExtractor.SourceDebitNotes.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Sales Invoices

        private void importSaleInvoices()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Sale))
                loadSaleInvoices(getSaleInvoices(daybook.Entity.Id), daybook);
        }

        private void loadSaleInvoices(IEnumerable<SaleInvoiceEntity> saleInvoices, ForesightDaybook daybook)
        {
            foreach (var saleInvoice in saleInvoices)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == saleInvoice.AccountId)
                                .SingleOrDefault();
                saleInvoice.DaybookId = daybook.ForesightId.ToString();
                saleInvoice.AccountId = account.ForesightId.ToString();
                _targetDbContext.SaveSaleInvoice(new SaleInvoice(saleInvoice));
            }
        }

        private IEnumerable<SaleInvoiceEntity> getSaleInvoices(string daybookId)
        {
            return _dataExtractor.SourceSaleInvoices.Where(t => t.DaybookId == daybookId);
        }

        #endregion

        #region Purchase Invoices

        private void importPurchaseInvoices()
        {
            foreach (var daybook in getDaybooksOf(DaybookType.Purchase))
                loadPurchaseInvoices(getPurchaseInvoices(daybook.Entity.Id), daybook);
        }

        private void loadPurchaseInvoices(IEnumerable<PurchaseInvoiceEntity> purchaseInvoices, ForesightDaybook daybook)
        {
            foreach (var purchaseInvoice in purchaseInvoices)
            {
                var account = _dataExtractor.TargetAccounts
                                .Where(a => a.Entity.Id == purchaseInvoice.AccountId)
                                .SingleOrDefault();
                purchaseInvoice.DaybookId = daybook.ForesightId.ToString();
                purchaseInvoice.AccountId = account.ForesightId.ToString();
                _targetDbContext.SavePurchaseInvoice(new PurchaseInvoice(purchaseInvoice));
            }
        }

        private IEnumerable<PurchaseInvoiceEntity> getPurchaseInvoices(string daybookId)
        {
            return _dataExtractor.SourcePurchaseInvoices.Where(t => t.DaybookId == daybookId);
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
