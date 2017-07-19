using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Raven.Client;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Shared.Model;

namespace Insight.Domain.Repositories
{
    public class InsightRepository : RepositoryBase
    {
        //public IEnumerable<CompanyPeriodEntity> GetAllCompanyPeriods()
        //{
        //    using (var s = Store.OpenSession())
        //        return s.Query<CompanyPeriodEntity>().ToList();
        //}

        public string GetCompanyPeriodIdByNameAndFinPeriod(string companyName, DatePeriod searchPeriod)
        {
            using (var s = Store.OpenSession())
            {
                var company = s.Query<CompanyEntity>()
                                .Where(c => c.Name == companyName)
                                .SingleOrDefault();

                if (company == null)
                    return string.Empty;

                var dp = s.Query<FiscalDatePeriodEntity>()
                                .Where(p => p.Financial.From == searchPeriod.From &&
                                            p.Financial.To == searchPeriod.To)
                                .SingleOrDefault();

                if (dp == null)
                    return string.Empty;

                var period = s.Query<CompanyPeriodEntity>()
                                .Where(cp => cp.CompanyId == company.Id &&
                                        cp.PeriodId == dp.Id)
                                .SingleOrDefault();

                if (period != null)
                    return period.Id;
            }

            return string.Empty;
        }

        public FiscalDatePeriod GetFiscalDatePeriodByPeriodName(DatePeriod period, bool createIfNotExist)
        {
            using (var s = Store.OpenSession())
            {
                var datePeriods = s.Query<FiscalDatePeriodEntity>().ToList();
                var datePeriod = datePeriods
                                .Where(dp => dp.Financial.From == period.From &&
                                        dp.Financial.To == period.To)
                                .FirstOrDefault();

                if (datePeriod == null && createIfNotExist)
                {
                    var fdp = FiscalDatePeriod.CreateInstanceFrom(period);
                    datePeriod = fdp.Entity;
                    Save(datePeriod);
                    return fdp;
                }

                return new FiscalDatePeriod(datePeriod);
            }
        }

        public override string Save(dynamic entity)
        {
            EntityValidator.Validate(entity);

            using (var session = Store.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
                return entity.Id;
            }
        }

        public void DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyEntity> GetAllCompanies()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyEntity>().ToList();
            }
        }

        public CompanyEntity GetCompanyByName(string name)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyEntity>()
                        .SingleOrDefault(c => c.Name == name.Trim());
            }
        }

        public AccountEntity GetAccountByName(string name)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<AccountEntity>()
                        .SingleOrDefault(c => c.Name == name.Trim());
            }
        }

        public DaybookEntity GetDaybookByName(string name)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<DaybookEntity>()
                        .SingleOrDefault(c => c.Name == name.Trim());
            }
        }

        public CompanyEntity GetCompanyById(string id)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyEntity>()
                        .SingleOrDefault(c => c.Id == id);
            }
        }

        public FiscalDatePeriodEntity GetFiscalDatePeriodByName(string name)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<FiscalDatePeriodEntity>()
                        .SingleOrDefault(c => c.Name == name.Trim());
            }
        }

        public FiscalDatePeriodEntity GetFiscalDatePeriodById(string id)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<FiscalDatePeriodEntity>()
                        .SingleOrDefault(c => c.Id == id);
            }
        }

        public ChartOfAccountEntity GetChartOfAccountByName(string name)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<ChartOfAccountEntity>()
                        .SingleOrDefault(c => c.Name == name.Trim());
            }
        }

        public ChartOfAccountEntity GetChartOfAccountById(string id)
        {
            return Read<ChartOfAccountEntity>(id);
        }

        public CompanyPeriodEntity GetCompanyPeriodBy(CompanyPeriodEntity entity)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<CompanyPeriodEntity>()
                        .SingleOrDefault(c => c.CompanyId == entity.CompanyId &&
                                              c.PeriodId == entity.PeriodId);
            }
        }

        public CompanyPeriod GetCompanyPeriodById(string id)
        {
            using (var s = Store.OpenSession())
            {
                var cp = s.Query<CompanyPeriodEntity>()
                        .SingleOrDefault(c => c.Id == id);

                return new CompanyPeriod(cp)
                {
                    Company = new Company(s.Load<CompanyEntity>(cp.CompanyId)),
                    Period = new FiscalDatePeriod(s.Load<FiscalDatePeriodEntity>(cp.PeriodId))
                };
            }
        }

        public IList<Daybook> GetAllDaybooks()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<DaybookEntity>()
                        .Select(c => new Daybook(c)).ToList();

            }
        }

        public Daybook GetDaybookBy(string id)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Load<DaybookEntity>(id);
                var daybook = new Daybook(result);
                daybook.Account = new Account(s.Load<AccountEntity>(daybook.Entity.AccountId));
                return daybook;
            }
        }

        public IList<BillTerm> GetBillTermsByDaybookId(string p)
        {
            using (var s = Store.OpenSession())
            {
                var res = s.Query<BillTermEntity>()
                        .Where(b => b.DaybookId == p)
                        .ToList()
                        .Select(b => new BillTerm(b))
                        .ToList();

                return res;
            }
        }

        public IList<BillTerm> GetSaleInvoiceBillTerms(IEnumerable<SaleInvoiceTerm> Terms)
        {
            var result = new List<BillTerm>();
            using (var s = Store.OpenSession())
                result.AddRange(Terms.Select(term => new BillTerm(s.Load<BillTermEntity>(term.Entity.TermId))));

            return result;
        }

        public IList<Account> GetAllAccounts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<AccountEntity>()
                        .Select(c => new Account(c)).ToList();
            }
        }

        //TODO: Remove duplication of generating docNr in all these document types...
        public string GetNewCashReceiptDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<CashReceiptEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewCashPaymentDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<CashPaymentEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewBankReceiptDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<BankReceiptEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewBankPaymentDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<BankPaymentEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewJVDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<JournalVoucherEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewCreditNoteDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<CreditNoteEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewDebitNoteDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<DebitNoteEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewSaleInvoiceDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<SaleInvoiceEntity>()
                                .Where(doc => doc.DaybookId == daybookId &&
                                       doc.CompanyPeriodId == companyPeriodId)
                                .OrderByDescending(c => c.DocumentNr)
                                .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public string GetNewPurchaseInvoiceDocNr(string daybookId, string companyPeriodId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<PurchaseInvoiceEntity>()
                              .Where(doc => doc.DaybookId == daybookId &&
                                     doc.CompanyPeriodId == companyPeriodId)
                              .OrderByDescending(c => c.DocumentNr)
                              .FirstOrDefault();
                return result == null ? "1" : (Convert.ToInt64(result.DocumentNr) + 1).ToString();
            }
        }

        public static PurchaseInvoice GetPurchaseInvoiceWithFullDetails(PurchaseInvoiceEntity entity, IDocumentSession s)
        {
            var invoice = (PurchaseInvoice)GetTransHeaderWithFullDetails(new PurchaseInvoice(entity), s);
            invoice.Lines = entity.LineEntities.Select(l => GetPurchaseInvoiceLineItemWithFullDetails(l, s)).ToList();
            invoice.Terms = entity.TermEntities.Select(t => new PurchaseInvoiceTerm(t)).ToList();
            return invoice;
        }

        public static PurchaseInvoiceLine GetPurchaseInvoiceLineItemWithFullDetails(PurchaseInvoiceLineEntity entity, IDocumentSession s)
        {
            var invoiceLine = new PurchaseInvoiceLine(entity);
            invoiceLine.Entity = entity;

            var itemEntity = s.Load<ItemEntity>(entity.ItemId);
            invoiceLine.Item = new Item(itemEntity);

            return invoiceLine;
        }

        public static SaleInvoice GetSaleInvoiceWithFullDetails(SaleInvoiceEntity entity, IDocumentSession s)
        {
            var invoice = (SaleInvoice)GetTransHeaderWithFullDetails(new SaleInvoice(entity), s);
            invoice.Lines = entity.LineEntities.Select(l => GetSaleInvoiceLineItemWithFullDetails(l, s)).ToList();
            invoice.Terms = entity.TermEntities.Select(t => new SaleInvoiceTerm(t)).ToList();
            return invoice;
        }

        public static SaleInvoiceLine GetSaleInvoiceLineItemWithFullDetails(SaleInvoiceLineEntity entity, IDocumentSession s)
        {
            var invoiceLine = new SaleInvoiceLine(entity);
            invoiceLine.Entity = entity;

            var itemEntity = s.Load<ItemEntity>(entity.ItemId);
            invoiceLine.Item = new Item(itemEntity);

            return invoiceLine;
        }

        public static TransactionHeader GetTransHeaderWithFullDetails(TransactionHeader transaction, IDocumentSession s)
        {
            var accountEntity = s.Load<AccountEntity>(transaction.Entity.AccountId);
            transaction.Account = new Account(accountEntity);

            var daybookEntity = s.Load<DaybookEntity>(transaction.Entity.DaybookId);
            transaction.Daybook = new Daybook(daybookEntity);

            return transaction;
        }

        public static JournalVoucher GetJVWithFullDetails(JournalVoucherEntity entity, IDocumentSession s)
        {
            var jv = new JournalVoucher(entity);

            var creditAccount = s.Load<AccountEntity>(entity.CreditAccountId);
            jv.CreditAccount = new Account(creditAccount);

            var debitAccount = s.Load<AccountEntity>(entity.DebitAccountId);
            jv.DebitAccount = new Account(debitAccount);

            var daybookEntity = s.Load<DaybookEntity>(entity.DaybookId);
            jv.Daybook = new Daybook(daybookEntity);

            return jv;
        }

        private static AppMenuItemEntity createTransactionsMenuItem()
        {
            var result = new AppMenuItemEntity();
            result.Nr = 1;
            result.DisplayOrder = "1";
            result.Name = "Transactions";
            result.Caption = "T&ransactions";
            result.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

            var menuItem = new AppMenuItemEntity();
            menuItem.Nr = 1;
            menuItem.DisplayOrder = "1";
            menuItem.Name = "Receipts";
            menuItem.Caption = "&Receipts";
            menuItem.UIControlName = "UReceipts";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.E;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 2;
            menuItem.DisplayOrder = "2";
            menuItem.Name = "Payments";
            menuItem.Caption = "&Payments";
            menuItem.UIControlName = "UPayments";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.Y;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 3;
            menuItem.DisplayOrder = "3";
            menuItem.Name = "JournalVouchers";
            menuItem.Caption = "&Journal Vouchers";
            menuItem.UIControlName = "UJournalVouchers";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.J;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 4;
            menuItem.DisplayOrder = "4";
            menuItem.Name = "CreditNotes";
            menuItem.Caption = "&Credit Notes";
            menuItem.UIControlName = "UCreditNotes";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.R;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 5;
            menuItem.DisplayOrder = "5";
            menuItem.Name = "DebitNotes";
            menuItem.Caption = "&DebitNotes";
            menuItem.UIControlName = "UDebitNotes";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.B;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 6;
            menuItem.DisplayOrder = "6";
            menuItem.Name = "SaleInvoices";
            menuItem.Caption = "&Sales Invoices";
            menuItem.UIControlName = "USaleInvoices";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.L;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 7;
            menuItem.DisplayOrder = "7";
            menuItem.Name = "PurchaseInvoices";
            menuItem.Caption = "P&urchase Invoices";
            menuItem.UIControlName = "UPurchaseInvoices";
            menuItem.UIControlPath = "Insight.UC.Controls";
            menuItem.UIAssembly = "Insight.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.L;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            result.SubItems.Add(menuItem);

            return result;
        }

        private static AppMenuItemEntity createPartiesMenuItem()
        {
            var result = new AppMenuItemEntity();
            result.Nr = 6;
            result.DisplayOrder = "6";
            result.Name = "Parties";
            result.Caption = "&Parties";
            result.UIControlName = "UParties";
            result.UIControlPath = "Mingle.UC.Controls";
            result.UIAssembly = "Mingle.UC.dll";
            result.ShortcutKeys = Keys.Control | Keys.P;
            result.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

            return result;
        }

        private static AppMenuItemEntity createTasksMenuItem()
        {
            var result = new AppMenuItemEntity();
            result.Nr = 5;
            result.DisplayOrder = "5";
            result.Name = "Tasks";
            result.Caption = "&Tasks";
            result.UIControlName = "UTasks";
            result.UIControlPath = "Synergy.UC.Controls";
            result.UIAssembly = "Synergy.UC.dll";
            result.ShortcutKeys = Keys.Control | Keys.T;
            result.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            return result;
        }

        public static IList<AppMenuItemEntity> GetAllAppMenuItems()
        {
            var menuItems = new List<AppMenuItemEntity>();
            menuItems.Add(createTransactionsMenuItem());
            menuItems.Add(createTasksMenuItem());
            menuItems.Add(createPartiesMenuItem());

            if (GravitySession.User.Entity.IsAdmin)
                return menuItems.OrderBy(m => m.DisplayOrder).ToList();

            return menuItems.Where(m => !m.IsForAdminOnly).OrderBy(m => m.DisplayOrder).ToList();
        }
    }
}
