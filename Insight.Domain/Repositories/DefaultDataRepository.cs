using System;
using System.Linq;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Mingle.Domain.Entities;
using Raven.Client;
using Scalable.Shared.Model;

namespace Insight.Domain.Repositories
{
    public class DefaultDataRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession _session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (SysConfig.DefaultDataInserted)
                    return;

                createAll();
                SysConfig.DefaultDataInserted = true;
            }
        }

        private void createAll()
        {
            createChartOfAccounts();
            createAccounts();
            createDaybooks();
        }

        #endregion

        public void InsertCompanyPeriod(CompanyGroup coGroup)
        {
            if (SysConfig.DefaultDataInserted)
                return;

            _session = Store.OpenSession();

            var cp = new CompanyPeriodEntity();
            cp.CompanyId = createCompany(coGroup);
            cp.PeriodId = createPeriod();
            _session.Store(cp);
            _session.SaveChanges();
        }

        private string createCompany(CompanyGroup coGroup)
        {
            var company = new CompanyEntity();
            company.Name = coGroup.Entity.Name;
            company.PartyId = createParty(coGroup);
            _session.Store(company);
            return company.Id;
        }

        private string createParty(CompanyGroup coGroup)
        {
            var party = _session.Query<PartyEntity>().FirstOrDefault(p => p.Name == coGroup.Entity.Name);
            return party.Id;
        }

        private string createPeriod()
        {
            var period = new FiscalDatePeriodEntity();
            period.Financial = new DatePeriod
            {
                From = new DateTime(DateTime.Today.Year, 4, 1),
                To = new DateTime(DateTime.Today.Year + 1, 3, 31)
            };
            period.Assessment = new DatePeriod
            {
                From = new DateTime(DateTime.Today.Year + 1, 4, 1),
                To = new DateTime(DateTime.Today.Year + 2, 3, 31)
            };
            period.Name = period.Financial.ToYearString();
            _session.Store(period);
            return period.Id;
        }

        #region Chart of Accounts

        private void createChartOfAccounts()
        {
            createChartOfAccountsLiabilities();
            createChartOfAccountsAssets();
            createChartOfAccountsIncomes();
            createChartOfAccountsExpenses();
            _session.SaveChanges();
        }

        private void createChartOfAccountsLiabilities()
        {
            var coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "CAPITAL ACCOUNTS";
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "RESERVES AND SURPLUS";
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "SECURED LOANS";
            coa.Nr = 3;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "UNSECURED LOANS";
            coa.Nr = 4;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "CURRENT LIABILITIES";
            coa.Nr = 5;
            _session.Store(coa);
            var parentId = coa.Id;

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "SUPPLIERS (TRADE CREDITORS)";
            coa.ParentId = parentId;
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "OTHER CREDITORS";
            coa.ParentId = parentId;
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "PROVISIONS";
            coa.ParentId = parentId;
            coa.Nr = 3;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Liability;
            coa.Name = "PROFIT & LOSS";
            coa.Nr = 6;
            _session.Store(coa);
        }

        private void createChartOfAccountsAssets()
        {
            var coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "FIXED ASSETS";
            coa.Nr = 1;
            _session.Store(coa);
            var parentId = coa.Id;

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "LAND & BUILDINGS";
            coa.ParentId = parentId;
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "PLANT & MACHINERY";
            coa.ParentId = parentId;
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "FURNITURE & FIXTURES";
            coa.ParentId = parentId;
            coa.Nr = 3;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "INVESTMENTS";
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "CURRENT ASSETS, LOANS & ADVANCES";
            coa.Nr = 3;
            _session.Store(coa);
            parentId = coa.Id;

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "INVENTORIES";
            coa.ParentId = parentId;
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "CUSTOMERS (TRADE DEBTORS)";
            coa.ParentId = parentId;
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "CASH & BANK BALANCES";
            coa.ParentId = parentId;
            coa.Nr = 3;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "LOANS & ADVANCES";
            coa.ParentId = parentId;
            coa.Nr = 4;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Asset;
            coa.Name = "MISCELLANIOUS EXPENDITURES";
            coa.Nr = 4;
            _session.Store(coa);
        }

        private void createChartOfAccountsIncomes()
        {
            var coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Income;
            coa.Name = "SALE";
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Income;
            coa.Name = "OTHER INCOME";
            coa.Nr = 2;
            _session.Store(coa);
        }

        private void createChartOfAccountsExpenses()
        {
            var coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Expense;
            coa.Name = "OPENING STOCK";
            coa.Nr = 1;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Expense;
            coa.Name = "PURCHASE";
            coa.Nr = 2;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Expense;
            coa.Name = "FACTORY EXPENSES";
            coa.Nr = 3;
            _session.Store(coa);

            coa = new ChartOfAccountEntity();
            coa.Type = ChartOfAccountType.Expense;
            coa.Name = "OTHER EXPENSES";
            coa.Nr = 4;
            _session.Store(coa);
        }

        #endregion

        #region Accounts

        private void createAccounts()
        {
            createDefaultAccounts();
            _session.SaveChanges();
        }

        private void createDefaultAccounts()
        {
            var coaId = getChartOfAccountId("102", null);
            var a = new AccountEntity();
            a.Name = "ADVANCE TAX";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "PROFIT & LOSS A/C";
            a.ChartOfAccountId = coaId; //102
            _session.Store(a);

            coaId = getChartOfAccountId("202", null);
            a = new AccountEntity();
            a.Name = "ELECTRICITY DEPOSITS";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            var parentCoaId = getChartOfAccountParentId("20301");
            a = new AccountEntity();
            a.Name = "CLOSING STOCK B/S";
            a.ChartOfAccountId = getChartOfAccountId("20301", parentCoaId);
            _session.Store(a);

            coaId = getChartOfAccountId("302", null);
            a = new AccountEntity();
            a.Name = "CLOSING STOCK P/L";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "SALES TAX REFFUND";
            a.ChartOfAccountId = coaId; //302
            _session.Store(a);

            coaId = getChartOfAccountId("401", null);
            a = new AccountEntity();
            a.Name = "OPENING STOCK";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            coaId = getChartOfAccountId("403", null);
            a = new AccountEntity();
            a.Name = "ELECTRICITY EXPENSES";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            coaId = getChartOfAccountId("404", null);
            a = new AccountEntity();
            a.Name = "ADVERTISING EXPENSES";
            a.ChartOfAccountId = coaId;
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "BANK COMMISSION EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "BANK INTEREST EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "BONUS EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "COMPUTER EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "BROKERAGE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "DISCOUNT & REBATE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "DEPRECIATION";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "DONATION EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "ELECTRICAL REPAIRING EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "INCOME TAX EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "INSURANCE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "INTEREST FOR UNSECURED LOANS";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "LEGAL EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "LICENCE FEES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "OCTROI EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "OFFICE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "PETROL AND OIL EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "CREDIT NOTES A/C";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "SALES TAX EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "STAFF WELFARE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "SALARY EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "SALES RETURN A/C";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "TELEPHONE AND POST EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "TRANSPORTATION EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "TRAVELING EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);

            a = new AccountEntity();
            a.Name = "VEHICLE EXPENSES";
            a.ChartOfAccountId = coaId; //404
            _session.Store(a);
        }

        string getChartOfAccountParentId(string code)
        {
            return code.Length == 3 ? null : getChartOfAccountId(code, null);
        }

        string getChartOfAccountId(string code, string parentId)
        {
            var type = (ChartOfAccountType)Convert.ToInt32(code.Substring(0, 1));
            var nr = getChartOfAccountNr(code, parentId);
            var result = _session.Query<ChartOfAccountEntity>()
                        .Where(coa => coa.Type == type && coa.Nr == nr && coa.ParentId == parentId)
                        .FirstOrDefault();

            return result != null ? result.Id : null;
        }

        private int getChartOfAccountNr(string code, string parentId)
        {
            return Convert.ToInt32(string.IsNullOrWhiteSpace(parentId) ? code.Substring(1, 2) : code.Substring(3));
        }

        #endregion

        #region Daybooks

        private void createDaybooks()
        {
            createDefaultDaybooks();
            _session.SaveChanges();
        }

        private void createDefaultDaybooks()
        {
            var chartOfAccountId = getChartOfAccountId("301", null);
            var d = new DaybookEntity();
            d.Name = "CASH SALE";
            d.Type = DaybookType.Sale;
            d.AccountId = createAccount("CASH SALE", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "CREDIT SALE";
            d.Type = DaybookType.Sale;
            d.AccountId = createAccount("CREDIT SALE", chartOfAccountId);
            _session.Store(d);

            var parentCoaId = getChartOfAccountParentId("20303");
            chartOfAccountId = getChartOfAccountId("20303", parentCoaId);
            d = new DaybookEntity();
            d.Name = "CASH ON HAND";
            d.Type = DaybookType.Cash;
            d.AccountId = createAccount("CASH ON HAND", chartOfAccountId);
            _session.Store(d);

            chartOfAccountId = getChartOfAccountId("402", null);
            d = new DaybookEntity();
            d.Name = "CASH PURCHASE";
            d.Type = DaybookType.Purchase;
            d.AccountId = createAccount("CASH PURCHASE", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "CREDIT PURCHASE";
            d.Type = DaybookType.Purchase;
            d.AccountId = createAccount("CREDIT PURCHASE", chartOfAccountId);
            _session.Store(d);

            chartOfAccountId = getChartOfAccountId("302", null);
            d = new DaybookEntity();
            d.Name = "DEBIT NOTE";
            d.Type = DaybookType.DebitNote;
            d.AccountId = createAccount("DEBIT NOTE", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "PURCHASE RETURN";
            d.Type = DaybookType.PurchaseReturn;
            d.AccountId = createAccount("PURCHASE RETURN", chartOfAccountId);
            _session.Store(d);

            chartOfAccountId = getChartOfAccountId("404", null);
            d = new DaybookEntity();
            d.Name = "CREDIT NOTE";
            d.Type = DaybookType.CreditNote;
            d.AccountId = createAccount("CREDIT NOTE", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "SALE RETURN";
            d.Type = DaybookType.SaleReturn;
            d.AccountId = createAccount("SALE RETURN", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "JOURNAL VOUCHER";
            d.Type = DaybookType.JournalVoucher;
            _session.Store(d);
        }

        private string createAccount(string name, string chartOfAccountId)
        {
            var a = new AccountEntity();
            a.Name = string.Format("{0} A/C", name);
            a.ChartOfAccountId = chartOfAccountId;
            _session.Store(a);
            return a.Id;
        }

        #endregion
    }
}
