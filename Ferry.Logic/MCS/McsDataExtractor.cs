﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ferry.Logic.Base;
using Ferry.Logic.Model;
using Ferry.Logic.Sql;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Ferry.Logic.MCS
{
    internal class McsDataExtractor : DataExtractorBase
    {
        private readonly string[] _dayBookCodes = new[] { "BOOK", "BOTH" };
        private readonly DataContext targetDbContext;

        #region Constructor

        public McsDataExtractor(Database sourceDatabase, DataContext targetDbContext)
            : base(sourceDatabase)
        {
            this.targetDbContext = targetDbContext;
            cacheDaybookTypes();
        }

        #endregion

        private void cacheDaybookTypes()
        {
            daybookCodes = new List<KeyValuePair<string[], DaybookType>>();

            var daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "SALE" }, DaybookType.Sale);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "PRCH" }, DaybookType.Purchase);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "CASH" }, DaybookType.Cash);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "N", "C" }, DaybookType.Bank);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "CRNT" }, DaybookType.CreditNote);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "DBNT" }, DaybookType.DebitNote);
            daybookCodes.Add(daybookCode);
            daybookCode = new KeyValuePair<string[], DaybookType>(new[] { "JVAC" }, DaybookType.JournalVoucher);
            daybookCodes.Add(daybookCode);
        }

        #region Overridden Methods

        protected override void LoadSourceChartOfAccounts()
        {
            loadSourceChartOfAccounts(readSourceChartOfAccounts());
        }

        protected override void LoadSourceAccounts()
        {
            loadSourceAccounts(readSourceAccounts());
        }

        protected override void LoadSourceDaybooks()
        {
            loadSourceDaybooks(readSourceDaybooks());
        }

        protected override void LoadSourceItems()
        {
            loadSourceItems(readSourceItems());
        }

        protected override void LoadRowColumns()
        {
            loadRowColumns(readRowColumns());
        }

        protected override void LoadSourceLineItems()
        {
            loadLineItems(readLineItems());
        }

        protected override void LoadSourceTransactions()
        {
            loadTransactions(readTransactions());
        }

        protected override void LoadAccounts()
        {
            Accounts = new List<AccountEntity>();
            loadAccounts(readAccountGroups(), false);
            loadAccounts(readAccounts(), true);
        }

        protected override void LoadDaybooks()
        {
            loadDaybooks();
        }

        protected override void LoadItems()
        {
            loadItems();
        }

        #endregion

        #region Source Chart Of Accounts

        private IDataReader readSourceChartOfAccounts()
        {
            return sourceDatabase.ExecuteReader(GetSelectAllGeneralLedgerGroupsQuery());
        }

        protected virtual string GetSelectAllGeneralLedgerGroupsQuery()
        {
            return McsSqlQueries.SelectAllGeneralLedgerGroups;
        }

        private void loadSourceChartOfAccounts(IDataReader reader)
        {
            while (reader.Read())
                SourceChartOfAccounts.Add(readSourceChartOfAccount(reader));

            reader.Close();
        }

        private SourceChartOfAccount readSourceChartOfAccount(IDataReader reader)
        {
            var scoa = new SourceChartOfAccount();
            scoa.Nr = reader["GR_CD"].ToString();
            scoa.Name = reader["GRHEAD"].ToString();
            return scoa;
        }

        #endregion

        #region Source Accounts

        private IDataReader readSourceAccounts()
        {
            return sourceDatabase.ExecuteReader(McsSqlQueries.SelectAllAccounts);
        }

        private void loadSourceAccounts(IDataReader reader)
        {
            while (reader.Read())
                SourceAccounts.Add(readSourceAccount(reader));

            reader.Close();
        }

        private SourceAccount readSourceAccount(IDataReader reader)
        {
            var account = new SourceAccount();

            account.GroupCode = reader["SB_GR"].ToString();
            account.Code = reader["PRT_CD"].ToString();
            account.Name = reader["PRT_NM"].ToString();
            account.OpeningBalance = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["OPBAL"]));
            account.AddressLine1 = reader["ADD1"] + " " + reader["ADD2"];
            account.AddressLine2 = reader["ADD2A"] + " " + reader["ADD3"];
            account.City = null; // reader["ADD1"].ToString();
            account.State = null; // reader["ADD2"].ToString();
            account.Pin = reader["PIN"].ToString();
            account.ChartOfAccountCode = reader["GR_CD"].ToString();
            //account.IsActive = Convert.ToBoolean(reader["O_K"]);
            return account;
        }

        #endregion

        #region Source Daybooks

        private IEnumerable<SourceAccount> readSourceDaybooks()
        {
            var result = SourceAccounts.Where(a => a.AddressLine1.TrimEnd().Length >= 4 &&
                            _dayBookCodes.Contains(a.AddressLine1.Substring(0, 4))).ToList();
            return result;
        }

        private void loadSourceDaybooks(IEnumerable<SourceAccount> sourceAccounts)
        {
            foreach (var sourceAccount in sourceAccounts)
                SourceDaybooks.Add(readSourceDaybooks(sourceAccount));
        }

        private SourceDaybook readSourceDaybooks(SourceAccount sourceAccount)
        {
            var daybook = new SourceDaybook();
            daybook.Type = sourceAccount.ChartOfAccountCode.Substring(0, 1);
            daybook.Code = sourceAccount.Code;
            daybook.Name = sourceAccount.Name;
            daybook.AccountCode = sourceAccount.Code;
            return daybook;
        }

        #endregion

        #region Source Items

        private IDataReader readSourceItems()
        {
            return sourceDatabase.ExecuteReader(McsSqlQueries.SelectAllItems);
        }

        private void loadSourceItems(IDataReader reader)
        {
            while (reader.Read())
                SourceItems.Add(readSourceItem(reader));

            reader.Close();
        }

        private SourceItem readSourceItem(IDataReader reader)
        {
            var item = new SourceItem();
            item.Code = reader["QC"].ToString();
            item.Name = reader["QN"].ToString();
            return item;
        }

        #endregion

        #region Row Columns

        private IDataReader readRowColumns()
        {
            return sourceDatabase.ExecuteReader(McsSqlQueries.SelectAllRowColumns);
        }

        private void loadRowColumns(IDataReader reader)
        {
            while (reader.Read())
                RowColumns.Add(readRowColumn(reader));

            reader.Close();
        }

        private RowColumn readRowColumn(IDataReader reader)
        {
            var rowColumn = new RowColumn();
            rowColumn.Code = reader["R_O"].ToString();
            rowColumn.DaybookCode = reader["BK_CD"].ToString();
            rowColumn.AccountCode = reader["CD_PRT"].ToString();
            return rowColumn;
        }

        #endregion

        #region Line Items

        private IDataReader readLineItems()
        {
            return sourceDatabase.ExecuteReader(McsSqlQueries.SelectAllLineItems);
        }

        private void loadLineItems(IDataReader reader)
        {
            while (reader.Read())
                SourceLineItems.Add(readSourceLineItem(reader));

            reader.Close();
        }

        private static SourceLineItem readSourceLineItem(IDataReader reader)
        {
            var lineItem = new SourceLineItem();

            lineItem.DaybookCode = reader["BKCD6"].ToString();
            lineItem.AccountCode = reader["PRTCD6"].ToString();
            lineItem.DocumentNr = reader["VNO6"].ToString();
            //ITSR
            lineItem.ItemCode = reader["QC6"].ToString();
            lineItem.Quantity1 = Convert.ToDouble(ForesightUtil.ConvertDbNull(reader["QT1"]));
            lineItem.Quantity2 = Convert.ToDouble(ForesightUtil.ConvertDbNull(reader["QT2"]));
            lineItem.Quantity3 = Convert.ToDouble(ForesightUtil.ConvertDbNull(reader["QT3"]));
            lineItem.Price = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["RATE"]));
            lineItem.LineItemAmount = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["AMNT"]));
            return lineItem;
        }

        #endregion

        #region Source Transactions

        private IDataReader readTransactions()
        {
            return sourceDatabase.ExecuteReader(McsSqlQueries.SelectAllTransactions);
        }

        private void loadTransactions(IDataReader reader)
        {
            while (reader.Read())
                SourceTransactions.Add(readSourceTransaction(reader));

            reader.Close();
        }

        private static SourceTransaction readSourceTransaction(IDataReader reader)
        {
            var transaction = new SourceTransaction();

            transaction.DaybookCode = reader["BK_CD"].ToString();
            transaction.TransactionType = reader["CR_DR"].ToString();
            transaction.AccountCode = reader["PRT_CD"].ToString();
            transaction.TransactionDate = Convert.ToDateTime(ForesightUtil.ConvertDbNull(reader["TR_DATE"]));
            transaction.DocumentNr = reader["VNO"].ToString();
            transaction.RowColumnCode = reader["R_O"].ToString();
            //PRT_BN
            transaction.Amount = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["AMOUNT"]));
            transaction.Notes = reader["REM"].ToString();
            transaction.ChequeNr = reader["CHNO"].ToString();
            transaction.BankBranchName = reader["CHEX"].ToString();
            transaction.ChequeDate = ForesightUtil.ConvertDbNullToString(reader["CHDT"]);

            return transaction;
        }

        #endregion

        #region Account

        private IEnumerable<SourceAccount> readAccounts()
        {
            return SourceAccounts.Where(
                        a => string.IsNullOrWhiteSpace(a.GroupCode) &&
                            a.GroupCode != a.Code);
        }

        private IEnumerable<SourceAccount> readAccountGroups()
        {
            return SourceAccounts.Where(a => a.GroupCode == a.Code);
        }

        private void loadAccounts(IEnumerable<SourceAccount> sourceAccounts, bool checkGroup)
        {
            foreach (var sourceAccount in sourceAccounts)
                Accounts.Add(readAccount(sourceAccount, checkGroup));
        }

        private AccountEntity readAccount(SourceAccount sourceAccount, bool checkGroup)
        {
            var account = new AccountEntity();

            if (checkGroup && !string.IsNullOrWhiteSpace(sourceAccount.GroupCode))
                account.GroupId = loadAccount(getAccount(sourceAccount.GroupCode)).Entity.Id;

            account.Code = sourceAccount.Code;
            account.Name = sourceAccount.Name;
            account.AddressLine1 = sourceAccount.AddressLine1;
            account.AddressLine2 = sourceAccount.AddressLine2;
            account.City = null; // sourceAccount.City;
            account.State = null; // sourceAccount.State;
            account.Pin = sourceAccount.Pin;
            account.ChartOfAccountId = loadChartOfAccount(sourceAccount.ChartOfAccountCode).Entity.Id;
            //account.IsActive = sourceAccount.IsActive;
            return account;
        }

        #endregion

        #region Daybooks

        private void loadDaybooks()
        {
            Daybooks = new List<Daybook>();
            foreach (var sourceDaybook in SourceDaybooks)
                Daybooks.Add(loadDaybook(readDaybook(sourceDaybook)));

        }

        private Daybook readDaybook(SourceDaybook sourceDaybook)
        {
            var book = new Daybook(new DaybookEntity());
            transformDaybookType(sourceDaybook);
            book.Entity.Type = (DaybookType)Convert.ToInt32(sourceDaybook.Type);
            book.Entity.Code = sourceDaybook.Code;
            book.Account = loadAccount(getAccount(sourceDaybook.AccountCode));
            book.Entity.AccountId = book.Account.Entity.Id;
            book.Entity.Name = sourceDaybook.Name;
            return book;
        }

        private bool isDaybookOfType(Daybook daybook, string type)
        {
            return daybook.Entity.Code.StartsWith(type);
        }

        private Daybook loadDaybook(Daybook book)
        {
            var result = targetDbContext.GetDaybookByCode(book.Entity.Code);
            if (result == null)
            {
                targetDbContext.SaveDaybook(book);
                return book;
            }

            return result;
        }

        #endregion

        #region Item

        private void loadItems()
        {
            Items = new List<Item>();
            foreach (var sourceItem in SourceItems)
                Items.Add(readItem(sourceItem));
        }

        private Item readItem(SourceItem sourceItem)
        {
            var item = new Item(new ItemEntity());
            item.Entity.Code = sourceItem.Code;
            item.Entity.Name = sourceItem.Name;
            item.Group = new ItemGroup(new ItemGroupEntity());
            item.Category = new ItemCategory(new ItemCategoryEntity());
            return item;
        }

        internal override Item getItem(string itemCode)
        {
            var item = Items.SingleOrDefault(i => i.Entity.Code == itemCode) ?? createDummyItem(itemCode);
            return item;

            //TODO: Report the possible duplicate items with ValidationException or ImportException
            //var result = _items.Where(i => i.Code == itemCode);
            //if (result.Count() > 1)
            //    Debug.WriteLine("");

            //var item = result.FirstOrDefault() ?? createDummyItem(itemCode);
            //return item;
        }

        private Item createDummyItem(string itemCode)
        {
            var item = new Item(new ItemEntity());

            item.Group = new ItemGroup(new ItemGroupEntity());
            item.Category = new ItemCategory(new ItemCategoryEntity());

            item.Entity.Code = itemCode;
            item.Entity.Name = getDummyName(itemCode);
            return item;
        }

        internal override Item loadItem(Item item)
        {
            if (!string.IsNullOrWhiteSpace(item.Entity.Id))
                return item;

            var result = targetDbContext.GetItemByName(item.Entity.Name);
            if (result == null)
            {
                targetDbContext.SaveItem(item);
                return item;
            }

            return result;
        }

        #endregion

        #region Common

        internal override Account loadAccount(AccountEntity account)
        {
            if (!string.IsNullOrWhiteSpace(account.Id))
                return new Account(account);

            var result = targetDbContext.GetAccountByNameAndAddress(account);
            if (result == null)
            {
                targetDbContext.SaveAccount(account);
                return new Account(account);
            }

            return result;
        }

        internal override AccountEntity getAccount(string accountCode)
        {
            return Accounts.FirstOrDefault(a => a.Code == accountCode) ?? createDummyAccount(accountCode);
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

        internal override ChartOfAccount loadChartOfAccount(string glgCode)
        {
            var coaId = ChartOfAccountsMapper
                            .Where(c => c.McsCode == glgCode || (glgCode.Length > 1 && c.McsCode == glgCode.Substring(0, 1).Trim()))
                            .Select(c => c.ChartOfAccountId)
                            .FirstOrDefault();
            var coa = ChartOfAccounts
                            .Where(c => c.Entity.Id == coaId ||
                                c.Entity.Name == getDummyName(glgCode))
                            .SingleOrDefault();
            if (coa != null)
                return coa;

            return createChartOfAccount(glgCode);
        }

        protected ChartOfAccount createChartOfAccount(string glgCode)
        {
            ChartOfAccount parent = null;

            if (glgCode.Length > 1)
                parent = loadChartOfAccount(glgCode.Substring(0, 1));

            return insertChartOfAccount(glgCode, parent);
        }

        private ChartOfAccount insertChartOfAccount(string glgCode, ChartOfAccount parent)
        {
            var coa = new ChartOfAccount(new ChartOfAccountEntity());
            coa.Entity.Name = getDummyName(glgCode);
            coa.Entity.Nr = ChartOfAccounts.Max(c => c.Entity.Nr) + 1;
            coa.Parent = parent;
            coa.Entity.Sorting = glgCode.Length > 2 ? glgCode.Substring(2) : string.Empty;
            ChartOfAccounts.Add(coa);
            targetDbContext.SaveChartOfAccount(coa);
            return coa;
        }

        #endregion
    }
}
