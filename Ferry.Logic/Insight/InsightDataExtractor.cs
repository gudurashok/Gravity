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

namespace Ferry.Logic.Insight
{
    internal class InsightDataExtractor
    {
        IForesightDataMethods _insightDataRepository;

        IList<KeyValuePair<string[], DaybookType>> _daybookCodes;

        public IList<ChartOfAccountMapper> ChartOfAccountsMapper;
        public IList<SourceChartOfAccount> SourceChartOfAccounts;
        public IList<SourceAccount> SourceAccounts;
        public IList<SourceDaybook> SourceDaybooks;
        public IList<SourceItemCategory> SourceItemCategories;
        public IList<SourceItemGroup> SourceItemGroups;
        public IList<SourceItem> SourceItems;
        public IList<RowColumn> RowColumns;

        public IList<SourceLineItem> SourceLineItems;
        public IList<SourceLineItemTerm> SourceLineItemTerms;
        public IList<SourceTransaction> SourceTransactions;
        public IList<SourceLineItem> SourceItemLots;
        public IList<SourceInventoryIssue> SourceInventoryIssues;
        public IList<SourceInventoryReceive> SourceInventoryReceives;
        public IList<SourceMiscInventoryIssue> SourceMiscInventoryIssues;

        public IList<ChartOfAccount> ChartOfAccounts;
        public IList<Daybook> Daybooks;
        public IList<AccountEntity> Accounts;
        public IList<Item> Items;
        public IList<ItemCategory> ItemCategories;
        public IList<ItemGroup> ItemGroups;

        public InsightDataExtractor()
        {
            initSourceDataLists();
            _insightDataRepository = new InsightDataRepository();
        }

        private void initSourceDataLists()
        {
            ChartOfAccountsMapper = new List<ChartOfAccountMapper>();
            SourceChartOfAccounts = new List<SourceChartOfAccount>();
            SourceAccounts = new List<SourceAccount>();
            SourceDaybooks = new List<SourceDaybook>();
            SourceItemCategories = new List<SourceItemCategory>();
            SourceItemGroups = new List<SourceItemGroup>();
            SourceItems = new List<SourceItem>();
            RowColumns = new List<RowColumn>();

            SourceLineItems = new List<SourceLineItem>();
            SourceLineItemTerms = new List<SourceLineItemTerm>();
            SourceTransactions = new List<SourceTransaction>();
            SourceInventoryIssues = new List<SourceInventoryIssue>();
            SourceInventoryReceives = new List<SourceInventoryReceive>();
            SourceMiscInventoryIssues = new List<SourceMiscInventoryIssue>();
        }

        public void Extract()
        {
            extractMasters();
            extractTransactions();
            transformMasters();
        }

        private void extractMasters()
        {
            loadChartOfAccountsMapper();
            loadSourceChartOfAccounts();
            loadSourceAccounts();
            //LoadSourceDaybooks();
            //LoadSourceItemCategories();
            //LoadSourceItemGroups();
            //LoadSourceItems();
            //LoadRowColumns();
        }

        private void extractTransactions()
        {
            //LoadSourceLineItems();
            //LoadSourceLineItemTerms();
            //LoadSourceTransactions();
            //LoadItemLots();
            //LoadInventoryIssue();
            //LoadInventoryReceives();
            //LoadMiscInventoryIssues();
        }

        private void transformMasters()
        {
            loadChartOfAccounts();
            //LoadAccounts();
            //LoadDaybooks();
            //LoadItemCategories();
            //LoadItemGroups();
            //LoadItems();
        }

        private void loadChartOfAccountsMapper()
        {
            ChartOfAccountsMapper = ForesightDatabaseFactory
                                    .GetInstance()
                                    .GetChartOfAccountsMapper();
        }

        private void loadSourceChartOfAccounts()
        {
            var chartOfAccounts = _insightDataRepository.GetAllChatOfAccounts();
            foreach (var coa in chartOfAccounts)
            {
                SourceChartOfAccounts.Add(new SourceChartOfAccount
                {
                    Nr = coa.Nr.ToString(),
                    Name = coa.Name
                });
            }
        }

        private void loadSourceAccounts()
        {
            var accounts = _insightDataRepository.GetAllAccounts();
            foreach (var account in accounts)
            {
                SourceAccounts.Add(new SourceAccount
                {
                    ChartOfAccountCode = account.ChartOfAccountId,
                    GroupCode = account.GroupId,
                    Code = account.Id,
                    Name = account.Name,
                    OpeningBalance = getAccountOpeningBalance(),
                    AddressLine1 = account.AddressLine1,
                    AddressLine2 = account.AddressLine2,
                    City = account.City,
                    State = account.State,
                    Pin = account.Pin,
                    IsActive = account.IsActive,
                });
            }
        }

        private decimal getAccountOpeningBalance()
        {
            //var openBalanceType = ForesightUtil.ConvertDbNullToString(reader["OPB_CR_DR"]);
            //if (!string.IsNullOrWhiteSpace(openBalanceType) && openBalanceType == "D")
            //    result.OpeningBalance = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["OP_BAL"])) * -1;
            //else
            //    result.OpeningBalance = Convert.ToDecimal(ForesightUtil.ConvertDbNull(reader["OP_BAL"]));

            return 0;
        }


        //protected abstract void LoadSourceDaybooks();
        //protected virtual void LoadSourceItemCategories() { }
        //protected virtual void LoadSourceItemGroups() { }
        //protected abstract void LoadSourceItems();
        //protected virtual void LoadRowColumns() { }

        //protected abstract void LoadSourceLineItems();
        //protected virtual void LoadSourceLineItemTerms() { }
        //protected abstract void LoadSourceTransactions();
        //protected virtual void LoadItemLots() { }
        //protected virtual void LoadInventoryIssue() { }
        //protected virtual void LoadInventoryReceives() { }
        //protected virtual void LoadMiscInventoryIssues() { }

        #region Transforming Masters Abstract Methods

        private void loadChartOfAccounts()
        {
            ChartOfAccounts = ForesightSession.Dbc.GetChartOfAccounts();
        }

        //protected abstract void LoadAccounts();
        //protected abstract void LoadDaybooks();
        //protected virtual void LoadItemCategories() { }
        //protected virtual void LoadItemGroups() { }
        //protected abstract void LoadItems();

        #endregion

        #region Transforming masters helping methods


        //public ChartOfAccount loadChartOfAccount(string glgCode);
        //public Item LoadItem(Item item);
        //public Item GetItem(string itemCode) { return null; }

        #endregion

        #region Common

        protected void transformDaybookType(SourceDaybook sourceDaybook)
        {
            foreach (var daybookCode in _daybookCodes)
            {
                var codeLen = daybookCode.Key.FirstOrDefault().Length;

                if (isDaybook(daybookCode.Key, codeLen, sourceDaybook.Type) ||
                        isDaybook(daybookCode.Key, codeLen, sourceDaybook.Code))
                {
                    sourceDaybook.Type = ((int)daybookCode.Value).ToString();
                    return;
                }
            }

            if (!char.IsDigit(Convert.ToChar(sourceDaybook.Type)))
                sourceDaybook.Type = ((int)DaybookType.Unknown).ToString();
        }

        private bool isDaybook(IEnumerable<string> daybookKeys, int codeLen, string field)
        {
            return field.Length >= codeLen && daybookKeys.Contains(field.Substring(0, codeLen));
        }

        #endregion
    }
}
