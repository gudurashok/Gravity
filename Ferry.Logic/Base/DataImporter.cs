using System;
using System.Collections.Generic;
using System.Linq;
using Ferry.Logic.Common;
using Ferry.Logic.Model;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Ferry.Logic.Base
{
    public class DataImporter
    {
        #region Declarations

        protected readonly Database sourceDatabase;
        protected readonly DataContext targetDbContext;
        protected readonly CompanyPeriod companyPeriod;
        internal DataExtractorBase extractor;
        internal readonly ImportingEventArgsFactory ieaFactory;
        private delegate void ExecuteImportDelegate();
        public event ImportingEventHandler Importing;
        public bool IsCancelled;

        #endregion

        #region Constructor

        public DataImporter(Database sourceDatabase, DataContext targetDbContext, CompanyPeriod companyPeriod)
        {
            this.sourceDatabase = sourceDatabase;
            this.targetDbContext = targetDbContext;
            this.companyPeriod = companyPeriod;
            ieaFactory = new ImportingEventArgsFactory(this);
        }

        #endregion

        #region Progress Indicator

        private void onImporting(ImportingEventArgs e)
        {
            Importing?.Invoke(this, e);
        }

        internal void RaiseImportingEvent(ImportingEventArgs e)
        {
            onImporting(e);
        }

        protected void ReportProgress(ImportingEventArgs e)
        {
            ieaFactory.RaiseImportingEvent(e);
        }

        #endregion

        #region Txn Type

        protected int GetTxnType(string dbCr)
        {
            return dbCr == "C" ? 0 : 1;
        }

        protected string GetTxnTypeFullName(int txnType)
        {
            return txnType == 0 ? "Receipt" : "Payment";
        }

        #endregion

        #region Public Members

        public void Execute()
        {
            extract();
            importTransactions();
            updateCompanyPeriod();
            completeImport();
        }

        public void CancelImport()
        {
            IsCancelled = true;
        }

        #endregion

        #region Composed Main Methods

        private void extract()
        {
            ieaFactory.RaiseImportingEvent("Caching Data");
            extractor = DataExtractorFactory.GetInstance(
                    companyPeriod.Entity.SourceDataProvider, sourceDatabase, targetDbContext);

            extractor.ExtractingHandler += sourceDataExtractor_Caching;
            extractor.Extract();
            extractor.ExtractingHandler -= sourceDataExtractor_Caching;
        }

        private void sourceDataExtractor_Caching(object sender, ExtractingEventArgs e)
        {
            ieaFactory.RaiseImportingEvent(e.CurrentText);
        }

        private void importTransactions()
        {
            ieaFactory.RaiseImportingEvent("Transactions");

            executeImport(importAccountOpeningBalances);
            executeImport(importSaleInvoices);
            executeImport(importPurchaseInvoices);
            executeImport(importCashTransactions);
            executeImport(importBankTransactions);
            executeImport(importCreditNotes);
            executeImport(importDebitNotes);
            executeImport(importJournalVoucher);
            executeImport(importItemLots);
            executeImport(importInventoryIssue);
            executeImport(importInventoryReceives);
            executeImport(importMiscInventoryIssues);
        }

        private void executeImport(ExecuteImportDelegate executeImportMethod)
        {
            if (IsCancelled) return;
            executeImportMethod();
        }

        private void completeImport()
        {
            ieaFactory.RaiseImportingEvent("Completing import");
            targetDbContext.SetCompanyPeriodIsImported(companyPeriod, true);
        }

        private void updateCompanyPeriod()
        {
            ieaFactory.RaiseImportingEvent("Updating company period");
            targetDbContext.SetCompanyPeriodColumnValue(companyPeriod);
        }

        #endregion

        #region Transaction Import Methods

        #region Opening Balances

        private void importAccountOpeningBalances()
        {
            ieaFactory.RaiseImportingEvent("Opening Account Balances");
            loadAccountOpeningBalances(readAccountOpeningBalances());
        }

        private IEnumerable<SourceAccount> readAccountOpeningBalances()
        {
            return extractor.SourceAccounts.Where(a => a.OpeningBalance != 0);
        }

        private void loadAccountOpeningBalances(IEnumerable<SourceAccount> sourceAccounts)
        {
            foreach (var aob in sourceAccounts.Select(getAccountOpeningBalance))
            {
                targetDbContext.SaveAccountOpeningBalance(aob);
                ReportProgress(ieaFactory.ForAccountOpeningBalance(aob.Account.Entity));
                if (IsCancelled) break;
            }
        }

        private AccountOpeningBalance getAccountOpeningBalance(SourceAccount sourceAccount)
        {
            var aob = new AccountOpeningBalance();
            aob.Account = extractor.loadAccount(extractor.getAccount(sourceAccount.Code));
            aob.Date = companyPeriod.Period.Entity.Financial.From;
            aob.Amount = sourceAccount.OpeningBalance;
            return aob;
        }

        #endregion

        #region Sales Invoice

        private void importSaleInvoices()
        {
            ieaFactory.RaiseImportingEvent("Sales");
            foreach (var daybook in readDaybooksByType(DaybookType.Sale))
                loadSaleInvoices(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadSaleInvoices(IEnumerable<SourceTransaction> sourceTransactions,
                                        Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                var invoice = getSaleInvoice(sourceTransaction, daybook);
                if (isShippingInfoExist(sourceTransaction))
                    invoice.HeaderEx = getSaleInvoiceHeaderEx(sourceTransaction);

                invoice.Lines = loadSaleInvoiceLines(readInvoiceLines(sourceTransaction));
                invoice.Terms = loadSaleInvoiceBillTerms(readInvoiceBillTerms(sourceTransaction));

                targetDbContext.SaveSaleInvoice(invoice);
                ReportProgress(ieaFactory.ForSaleInvoice(invoice.Daybook.Entity.Code, invoice.Entity.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private SaleInvoice getSaleInvoice(SourceTransaction sourceTransaction,
                                                       Daybook daybook)
        {
            var saleInvoice = SaleInvoice.New();
            fillTransactionHeader(sourceTransaction, daybook, saleInvoice.Entity);

            saleInvoice.Daybook = daybook;
            saleInvoice.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            var sale = (SaleInvoiceHeaderEntity)saleInvoice.Entity;
            sale.BrokerageAmount = 0; // sourceTransaction.BrokerageAmount;
            sale.Through = sourceTransaction.Through;
            sale.VehicleId = string.Empty;
            sale.Transport = sourceTransaction.Transport;
            sale.ReferenceDocNr = sourceTransaction.ReferenceDocNr;
            sale.OrderId = string.Empty;
            sale.DiscountPct = sourceTransaction.DiscountPct;
            sale.SaleTaxColumnId = string.Empty;
            return saleInvoice;
        }

        private bool isShippingInfoExist(SourceTransaction sourceTransaction)
        {
            if (string.IsNullOrWhiteSpace(sourceTransaction.ShipToName)) return true;
            if (string.IsNullOrWhiteSpace(sourceTransaction.ShipToAddressLine1)) return true;
            if (string.IsNullOrWhiteSpace(sourceTransaction.ShipToAddressLine2)) return true;
            if (string.IsNullOrWhiteSpace(sourceTransaction.ShipToCity)) return true;

            return false;
        }

        private SaleInvoiceHeaderEx getSaleInvoiceHeaderEx(SourceTransaction sourceTransaction)
        {
            var headerEx = SaleInvoiceHeaderEx.New();
            headerEx.Entity.ShipToName = sourceTransaction.ShipToName;
            headerEx.Entity.ShipToAddressLine1 = sourceTransaction.ShipToAddressLine1;
            headerEx.Entity.ShipToAddressLine2 = sourceTransaction.ShipToAddressLine2;
            headerEx.Entity.ShipToCity = sourceTransaction.ShipToCity;
            return headerEx;
        }

        private IList<SaleInvoiceLine> loadSaleInvoiceLines(IEnumerable<SourceLineItem> sourceLineItems)
        {
            return sourceLineItems.Select(getSaleInvoiceLineItem).ToList();
        }

        private SaleInvoiceLine getSaleInvoiceLineItem(SourceLineItem sourceLineItem)
        {
            var line = SaleInvoiceLine.New();
            line.Entity.LineNr = sourceLineItem.LineNr;
            line.Item = extractor.loadItem(extractor.Items.SingleOrDefault(i => i.Entity.Code == sourceLineItem.ItemCode));
            line.Entity.ItemDescription = sourceLineItem.ItemName;
            line.Entity.Quantity1 = Convert.ToDouble(ForesightUtil.ConvertDbNull(sourceLineItem.Quantity1));
            line.Entity.Packing = Convert.ToDouble(ForesightUtil.ConvertDbNull(sourceLineItem.Packing));
            line.Entity.Quantity2 = Convert.ToDouble(ForesightUtil.ConvertDbNull(sourceLineItem.Quantity2));
            ((SaleInvoiceLineEntity)line.Entity).Price = Convert.ToDecimal(ForesightUtil.ConvertDbNull(sourceLineItem.Price));
            line.Entity.DiscountPct = Convert.ToDouble(ForesightUtil.ConvertDbNull(sourceLineItem.DiscountPct));
            line.Entity.Amount = Convert.ToDecimal(ForesightUtil.ConvertDbNull(sourceLineItem.LineItemAmount));
            return line;
        }

        private IList<SaleInvoiceTerm> loadSaleInvoiceBillTerms(IEnumerable<SourceLineItemTerm> sourceLineItemTerms)
        {
            var terms = new List<SaleInvoiceTerm>();
            foreach (var sourceLineItemTerm in sourceLineItemTerms)
            {
                var term = SaleInvoiceTerm.New();
                readInvoiceTerm(sourceLineItemTerm, term);
                terms.Add(term);
            }
            return terms;
        }

        #endregion

        #region Purchase Invoice

        private void importPurchaseInvoices()
        {
            ieaFactory.RaiseImportingEvent("Purchase Invoices");
            foreach (var daybook in readDaybooksByType(DaybookType.Purchase))
                loadPurchaseInvoices(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadPurchaseInvoices(IEnumerable<SourceTransaction> sourceTransactions,
                                          Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                var invoice = getPurchaseInvoice(sourceTransaction, daybook);
                invoice.Lines = loadPurchaseInvoiceLines(readInvoiceLines(sourceTransaction));
                invoice.Terms = loadPurchaseInvoiceBillTerms(readInvoiceBillTerms(sourceTransaction));

                targetDbContext.SavePurchaseInvoice(invoice);
                ReportProgress(ieaFactory.ForPurchaseInvoice(invoice.Daybook.Entity.Code, invoice.Entity.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private PurchaseInvoice getPurchaseInvoice(SourceTransaction sourceTransaction,
                                                               Daybook daybook)
        {
            var purchaseInvoice = PurchaseInvoice.New();
            fillTransactionHeader(sourceTransaction, daybook, purchaseInvoice.Entity);

            purchaseInvoice.Daybook = daybook;
            purchaseInvoice.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            var purchase = (PurchaseInvoiceHeaderEntity)purchaseInvoice.Entity;
            purchase.BrokerageAmount = 0; // sourceTransaction.BrokerageAmount;
            purchase.Through = sourceTransaction.Through;
            purchase.Transport = sourceTransaction.Transport;
            purchase.ReferenceDocNr = sourceTransaction.ReferenceDocNr;
            purchase.OrderId = string.Empty;
            purchase.DiscountPct = sourceTransaction.DiscountPct;
            purchase.SaleTaxColumnId = string.Empty;
            return purchaseInvoice;
        }

        private IList<PurchaseInvoiceLine> loadPurchaseInvoiceLines(IEnumerable<SourceLineItem> sourceLineItems)
        {
            return sourceLineItems.Select(getPurchaseInvoiceLineItem).ToList();
        }

        private PurchaseInvoiceLine getPurchaseInvoiceLineItem(SourceLineItem sourceLineItem)
        {
            var line = PurchaseInvoiceLine.New();
            line.Item = extractor.loadItem(extractor.Items.SingleOrDefault(i => i.Entity.Code == sourceLineItem.ItemCode));
            line.Entity.LineNr = sourceLineItem.LineNr;
            line.Entity.ItemDescription = sourceLineItem.ItemName;
            line.Entity.Quantity1 = sourceLineItem.Quantity1;
            line.Entity.Packing = sourceLineItem.Packing;
            line.Entity.Quantity2 = sourceLineItem.Quantity2;
            ((PurchaseInvoiceLineEntity)line.Entity).Cost = sourceLineItem.Price;
            line.Entity.DiscountPct = sourceLineItem.DiscountPct;
            line.Entity.Amount = sourceLineItem.LineItemAmount;
            return line;
        }

        private IList<PurchaseInvoiceTerm> loadPurchaseInvoiceBillTerms(
            IEnumerable<SourceLineItemTerm> sourceLineItemTerms)
        {
            var terms = new List<PurchaseInvoiceTerm>();
            foreach (var sourceLineItemTerm in sourceLineItemTerms)
            {
                var term = PurchaseInvoiceTerm.New();
                readInvoiceTerm(sourceLineItemTerm, term);
                terms.Add(term);
            }

            return terms;
        }

        #endregion

        #region Sale and Purchase invoice common

        private IEnumerable<SourceLineItemTerm> readInvoiceBillTerms(SourceTransaction sourceTransaction)
        {
            return extractor.SourceLineItemTerms.Where(it => it.DocumentNr == sourceTransaction.DocumentNr);
        }

        private void readInvoiceTerm(SourceLineItemTerm sourceLineItemTerm, InvoiceTerm term)
        {
            term.Entity.TermId = sourceLineItemTerm.TermId;
            term.Entity.Description = sourceLineItemTerm.Description;
            term.Entity.Percentage = sourceLineItemTerm.Percentage;
            term.Entity.Amount = sourceLineItemTerm.Amount;
            term.Account = extractor.loadAccount(extractor.getAccount(sourceLineItemTerm.AccountCode));
        }

        private IEnumerable<SourceLineItem> readInvoiceLines(SourceTransaction sourceTransaction)
        {
            return extractor.SourceLineItems.Where(li => li.AccountCode == sourceTransaction.AccountCode &&
                                                    li.DaybookCode == sourceTransaction.DaybookCode &&
                                                    li.DocumentNr == sourceTransaction.DocumentNr);
        }

        #endregion

        #region Cash

        private void importCashTransactions()
        {
            ieaFactory.RaiseImportingEvent("Cash");

            foreach (var daybook in readDaybooksByType(DaybookType.Cash))
                loadCashTransactions(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadCashTransactions(IEnumerable<SourceTransaction> sourceTransactions,
                                          Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                insertCashTransaction(sourceTransaction, daybook);
                ReportProgress(ieaFactory.ForCashTransaction(daybook.Entity.Code,
                                        GetTxnTypeFullName(Convert.ToInt32(sourceTransaction.TransactionType)),
                                                    sourceTransaction.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private void insertCashTransaction(SourceTransaction sourceTransaction, Daybook daybook)
        {
            if (sourceTransaction.TransactionType == "0")
                targetDbContext.SaveCashReceipt(getCashReceipt(sourceTransaction, daybook));
            else
                targetDbContext.SaveCashPayment(getCashPayment(sourceTransaction, daybook));
        }

        private CashReceipt getCashReceipt(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var receipt = new CashReceipt(new CashReceiptEntity());
            fillTransactionHeader(sourceTransaction, daybook, receipt.Entity);

            receipt.Daybook = daybook;
            receipt.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            return receipt;
        }

        private CashPayment getCashPayment(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var payment = new CashPayment(new CashPaymentEntity());
            fillTransactionHeader(sourceTransaction, daybook, payment.Entity);

            payment.Daybook = daybook;
            payment.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            return payment;
        }

        #endregion

        #region Bank

        private void importBankTransactions()
        {
            ieaFactory.RaiseImportingEvent("Bank");

            foreach (var daybook in readDaybooksByType(DaybookType.Bank))
                loadBankTransactions(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadBankTransactions(IEnumerable<SourceTransaction> sourceTransactions,
                                          Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                insertBankTransaction(sourceTransaction, daybook);
                ReportProgress(ieaFactory.ForBankTransaction(daybook.Entity.Code,
                                    GetTxnTypeFullName(GetTxnType(sourceTransaction.TransactionType)),
                                                                    sourceTransaction.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private void insertBankTransaction(SourceTransaction sourceTransaction, Daybook daybook)
        {
            if (sourceTransaction.TransactionType == "C")
                targetDbContext.SaveBankReceipt(getBankReceipt(sourceTransaction, daybook));
            else
                targetDbContext.SaveBankPayment(getBankPayment(sourceTransaction, daybook));
        }

        private BankReceipt getBankReceipt(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var receipt = new BankReceipt(new BankReceiptEntity());
            fillTransactionHeader(sourceTransaction, daybook, receipt.Entity);

            receipt.Daybook = daybook;
            receipt.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            ((BankReceiptEntity)receipt.Entity).ChequeNr = sourceTransaction.ChequeNr;
            ((BankReceiptEntity)receipt.Entity).BankBranchName = sourceTransaction.BankBranchName;
            ((BankReceiptEntity)receipt.Entity).IsRealised = isChequeRealised(sourceTransaction.ChequeDate);
            return receipt;
        }

        private BankPayment getBankPayment(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var payment = new BankPayment(new BankPaymentEntity());
            fillTransactionHeader(sourceTransaction, daybook, payment.Entity);

            payment.Daybook = daybook;
            payment.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            ((BankPaymentEntity)payment.Entity).ChequeNr = sourceTransaction.ChequeNr;
            ((BankPaymentEntity)payment.Entity).IsRealised = isChequeRealised(sourceTransaction.ChequeDate);
            return payment;
        }

        private bool isChequeRealised(string passed)
        {
            return !string.IsNullOrWhiteSpace(passed);
        }

        #endregion

        #region Credit Note

        private void importCreditNotes()
        {
            ieaFactory.RaiseImportingEvent("Credit Notes");

            foreach (var daybook in readDaybooksByType(DaybookType.CreditNote))
                loadCreditNotes(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadCreditNotes(IEnumerable<SourceTransaction> sourceTransactions,
                                     Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                var note = new CreditNote();
                note.Header = getCreditNoteHeader(sourceTransaction, daybook);
                note.Lines = getLineItems(sourceTransaction).Select(getCreditNoteLineItem).ToList();

                targetDbContext.SaveCreditNote(note);
                ReportProgress(ieaFactory.ForCreditNote(note.Header.Daybook.Entity.Code, note.Header.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private CreditNoteHeader getCreditNoteHeader(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var note = new CreditNoteHeader();
            fillTransactionHeader(sourceTransaction, daybook, note);
            note.Daybook = daybook;
            note.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            return note;
        }

        private CreditNoteLine getCreditNoteLineItem(SourceLineItem sourceLineItem)
        {
            var line = new CreditNoteLine();
            line.LineNr = 0; // Convert.ToInt32(sourceData["ITSR"]);
            line.Item = extractor.loadItem(extractor.getItem(sourceLineItem.ItemCode));
            line.Quantity1 = sourceLineItem.Quantity1;
            line.Quantity2 = sourceLineItem.Quantity2;
            line.Quantity3 = sourceLineItem.Quantity3;
            line.Cost = sourceLineItem.Price;
            line.Amount = sourceLineItem.LineItemAmount;
            return line;
        }

        #endregion

        #region Debit Note

        private void importDebitNotes()
        {
            ieaFactory.RaiseImportingEvent("Debit Notes");

            foreach (var daybook in readDaybooksByType(DaybookType.DebitNote))
                loadDebitNotes(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadDebitNotes(IEnumerable<SourceTransaction> sourceTransactions,
                                    Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                var note = new DebitNote();
                note.Header = getDebitNoteHeader(sourceTransaction, daybook);
                note.Lines = getLineItems(sourceTransaction).Select(getDebitNoteLineItem).ToList();

                targetDbContext.SaveDebitNote(note);
                ReportProgress(ieaFactory.ForDebitNote(note.Header.Daybook.Entity.Code, note.Header.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private DebitNoteHeader getDebitNoteHeader(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var note = new DebitNoteHeader();
            fillTransactionHeader(sourceTransaction, daybook, note);
            note.Daybook = daybook;
            note.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            return note;
        }

        private DebitNoteLine getDebitNoteLineItem(SourceLineItem sourceLineItem)
        {
            var line = new DebitNoteLine();
            line.LineNr = 0; // Convert.ToInt32(sourceData["ITSR"]);
            line.Item = extractor.loadItem(extractor.getItem(sourceLineItem.ItemCode));
            line.Quantity1 = sourceLineItem.Quantity1;
            line.Quantity2 = sourceLineItem.Quantity2;
            line.Quantity3 = sourceLineItem.Quantity3;
            line.Price = sourceLineItem.Price;
            line.Amount = sourceLineItem.LineItemAmount;
            return line;
        }

        #endregion

        #region Journal Voucher

        private void importJournalVoucher()
        {
            ieaFactory.RaiseImportingEvent("Journal Vouchers");
            foreach (var daybook in readDaybooksByType(DaybookType.JournalVoucher))
                loadJournalVoucher(readTransactionsByDaybook(daybook), daybook);
        }

        private void loadJournalVoucher(IEnumerable<SourceTransaction> sourceTransactions,
                                        Daybook daybook)
        {
            foreach (var sourceTransaction in sourceTransactions)
            {
                var jv = getJournalVoucher(sourceTransaction, daybook);
                targetDbContext.SaveJournalVoucher(jv);
                ReportProgress(ieaFactory.ForJournalVoucher(daybook.Entity.Code, jv.Entity.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private JournalVoucher getJournalVoucher(SourceTransaction sourceTransaction, Daybook daybook)
        {
            var jv = JournalVoucher.New();
            fillTransactionHeader(sourceTransaction, daybook, jv.Entity);
            jv.Daybook = daybook;
            jv.Account = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode));
            ((JournalVoucherEntity)jv.Entity).TxnType = GetTxnType(sourceTransaction.TransactionType);
            return jv;
        }

        #endregion

        #region Item Lots

        private IEnumerable<SourceLineItem> readPurchaseLineItemsAsItemLots()
        {
            return extractor.SourceLineItems.Where(il => il.DocumentNr.StartsWith("P"));
        }

        private void importItemLots()
        {
            ieaFactory.RaiseImportingEvent("Item Lots");
            foreach (var lot in readPurchaseLineItemsAsItemLots().Select(getItemLot))
            {
                targetDbContext.SaveItemLot(lot);
                ReportProgress(ieaFactory.ForItemLot(lot.LotNr));
                if (IsCancelled) break;
            }
        }

        private ItemLot getItemLot(SourceLineItem sourceLineItem)
        {
            var lot = new ItemLot();
            lot.LotNr = sourceLineItem.DocumentNr;
            lot.Date = sourceLineItem.Date;
            lot.Account = extractor.loadAccount(extractor.getAccount(sourceLineItem.AccountCode));
            lot.LineNr = sourceLineItem.LineNr;
            lot.Item = extractor.loadItem(extractor.Items.SingleOrDefault(i => i.Entity.Code == sourceLineItem.ItemCode));
            lot.Quantity1 = sourceLineItem.Quantity1;
            lot.Packing = sourceLineItem.Packing;
            lot.Quantity2 = sourceLineItem.Quantity2;
            return lot;
        }

        #endregion

        #region Inventory Issue

        private void importInventoryIssue()
        {
            ieaFactory.RaiseImportingEvent("Inventory Issues");
            foreach (var daybook in readDaybooksByType(DaybookType.InventoryIssue))
                loadInventoryIssue(readInventoryIssue(daybook), daybook);
        }

        private IEnumerable<SourceInventoryIssue> readInventoryIssue(Daybook daybook)
        {
            return extractor.SourceInventoryIssues.Where(si => si.DaybookCode == daybook.Entity.Code);
        }

        private void loadInventoryIssue(IEnumerable<SourceInventoryIssue> sourceInventoryIssues,
                                        Daybook daybook)
        {
            foreach (var sourceInventoryIssue in sourceInventoryIssues)
            {
                var issue = getInventoryIssue(sourceInventoryIssue, daybook);
                targetDbContext.SaveInventoryIssue(issue);
                ReportProgress(ieaFactory.ForItemLot(issue.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private InventoryIssue getInventoryIssue(SourceInventoryIssue sourceInventoryIssue,
                                                 Daybook daybook)
        {
            var issue = new InventoryIssue();
            issue.Daybook = daybook;
            issue.DocumentNr = sourceInventoryIssue.DocumentNr;
            issue.Date = sourceInventoryIssue.Date;
            issue.LotId = (getItemLotByLotNrLineNr(sourceInventoryIssue)).Id;
            issue.Account = extractor.loadAccount(extractor.getAccount(sourceInventoryIssue.AccountCode));
            issue.Quantity1 = sourceInventoryIssue.Quantity1;
            issue.Quantity2 = sourceInventoryIssue.Quantity2;
            return issue;
        }

        private ItemLot getItemLotByLotNrLineNr(SourceInventoryIssue sourceInventoryIssue)
        {
            return targetDbContext.GetItemLotByLotNrLineNr(sourceInventoryIssue.LotNr,
                                                           sourceInventoryIssue.LineNr);
        }

        #endregion

        #region Inventory Receive

        private void importInventoryReceives()
        {
            ieaFactory.RaiseImportingEvent("Inventory Receives");
            foreach (var receive in extractor.SourceInventoryReceives.Select(getInventoryReceive))
            {
                targetDbContext.SaveInventoryReceive(receive);
                ReportProgress(ieaFactory.ForInventoryIssue(receive.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private InventoryReceive getInventoryReceive(SourceInventoryReceive sourceInventoryReceive)
        {
            var receive = new InventoryReceive();
            receive.DocumentNr = sourceInventoryReceive.DocumentNr;
            receive.Date = sourceInventoryReceive.Date;
            receive.Issue = getInventoryIssueByDocNr(sourceInventoryReceive.IssueDocNr);
            receive.LineNr = sourceInventoryReceive.LineNr;
            receive.Item = extractor.loadItem(extractor.Items.SingleOrDefault(i => i.Entity.Code == sourceInventoryReceive.ItemCode));
            receive.Quantity1 = sourceInventoryReceive.Quantity1;
            receive.Packing = sourceInventoryReceive.Packing;
            receive.Quantity2 = sourceInventoryReceive.Quantity2;
            return receive;
        }

        private InventoryIssue getInventoryIssueByDocNr(string issueDocNr)
        {
            return targetDbContext.GetInventoryIssueByDocNr(issueDocNr);
        }

        #endregion

        #region Misc Inventory Issue

        private void importMiscInventoryIssues()
        {
            ieaFactory.RaiseImportingEvent("Misc. Inventory Issues");
            foreach (var daybook in readDaybooksByType(DaybookType.MiscInventoryIssue))
                loadMiscInventoryIssue(readMiscInventoryIssue(daybook), daybook);
        }

        private IEnumerable<SourceMiscInventoryIssue> readMiscInventoryIssue(Daybook daybook)
        {
            return extractor.SourceMiscInventoryIssues.Where(mi => mi.DaybookCode == daybook.Entity.Code);
        }

        private void loadMiscInventoryIssue(IEnumerable<SourceMiscInventoryIssue> sourceMiscInventoryIssues,
                                            Daybook daybook)
        {
            foreach (var sourceMiscInventoryIssue in sourceMiscInventoryIssues)
            {
                var issue = getMiscInventoryIssue(sourceMiscInventoryIssue, daybook);
                targetDbContext.SaveMiscMaterialIssue(issue);
                ReportProgress(ieaFactory.ForMiscInventoryIssue(issue.Daybook.Entity.Code, issue.DocumentNr));
                if (IsCancelled) break;
            }
        }

        private MiscMaterialIssue getMiscInventoryIssue(SourceMiscInventoryIssue sourceMiscInventoryIssue,
                                                        Daybook daybook)
        {
            var issue = new MiscMaterialIssue();
            issue.Daybook = daybook;
            issue.DocumentNr = sourceMiscInventoryIssue.DocumentNr;
            issue.Date = sourceMiscInventoryIssue.Date;
            issue.LineNr = sourceMiscInventoryIssue.LineNr;
            issue.Item = extractor.loadItem(extractor.Items.SingleOrDefault(i => i.Entity.Code == sourceMiscInventoryIssue.ItemCode));
            issue.Quantity1 = sourceMiscInventoryIssue.Quantity1;
            issue.Quantity2 = sourceMiscInventoryIssue.Quantity2;
            return issue;
        }

        #endregion

        #region Common

        private IEnumerable<Daybook> readDaybooksByType(DaybookType type)
        {
            return extractor.Daybooks.Where(d => d.Entity.Type == type);
        }

        private IEnumerable<SourceTransaction> readTransactionsByDaybook(Daybook daybook)
        {
            return extractor.SourceTransactions.Where(trans => trans.DaybookCode == daybook.Entity.Code);
        }

        private void fillTransactionHeader(SourceTransaction sourceTransaction,
                                           Daybook daybook, TransactionHeaderEntity t)
        {
            t.DaybookId = daybook.Entity.Id;
            t.DocumentNr = sourceTransaction.DocumentNr;
            t.Date = sourceTransaction.TransactionDate;
            t.AccountId = extractor.loadAccount(extractor.getAccount(sourceTransaction.AccountCode)).Entity.Id;
            t.BrokerId = string.Empty;
            t.Amount = sourceTransaction.Amount;
            t.IsAdjusted = sourceTransaction.IsAdjusted;
            t.Notes = sourceTransaction.Notes;
        }

        private IEnumerable<SourceLineItem> getLineItems(SourceTransaction sourceTransaction)
        {
            return extractor.SourceLineItems.Where(l => l.DaybookCode == sourceTransaction.DaybookCode &&
                                        l.AccountCode == sourceTransaction.AccountCode &&
                                        l.DocumentNr == sourceTransaction.DocumentNr).ToList();
        }

        #endregion

        #endregion
    }
}