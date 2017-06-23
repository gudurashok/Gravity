using Insight.Domain.Enums;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public static class PicklistFactory
    {
        private static CompanyList _companyList;
        private static FiscalDatePeriodList _fiscalDatePeriodList;
        private static CompanyPeriodList _companyPeriodList;
        private static ChartOfAccountList _chartOfAccountList;
        private static AccountList _accountList;
        private static AccountList _accountListWithEntry;
        private static DaybookList _daybookList;
        private static ItemList _itemList;
        private static ItemGroupList _itemGroupList;
        private static ItemCategoryList _itemCategoryList;

        public static IPicklist Companies
        {
            get { return _companyList ?? (_companyList = new CompanyList()); }
        }

        public static IPicklist FiscalDatePeriods
        {
            get { return _fiscalDatePeriodList ?? (_fiscalDatePeriodList = new FiscalDatePeriodList()); }
        }

        public static IPicklist CompanyPeriods
        {
            get { return _companyPeriodList ?? (_companyPeriodList = new CompanyPeriodList()); }
        }

        public static IPicklist ChartOfAccounts
        {
            get { return _chartOfAccountList ?? (_chartOfAccountList = new ChartOfAccountList()); }
        }

        public static IPicklist ChartOfAccountsOfType(ChartOfAccountType type)
        {
            return new ChartOfAccountList(false, type);
        }

        public static IPicklist Accounts
        {
            get { return _accountList ?? (_accountList = new AccountList()); }
        }

        public static IPicklist AccountsWithEntry
        {
            get { return _accountListWithEntry ?? (_accountListWithEntry = new AccountList(true)); }
        }

        public static IPicklist Daybooks
        {
            get { return _daybookList ?? (_daybookList = new DaybookList()); }
        }

        public static IPicklist Items
        {
            get { return _itemList ?? (_itemList = new ItemList()); }
        }

        public static IPicklist ItemGroup
        {
            get { return _itemGroupList ?? (_itemGroupList = new ItemGroupList()); }
        }

        public static IPicklist ItemCategory
        {
            get { return _itemCategoryList ?? (_itemCategoryList = new ItemCategoryList()); }
        }

        public static IPicklist DaybooksOfType(DaybookType type)
        {
            return new DaybookList(true, false, type);
        }

        public static void ClearPicklistCache()
        {
            _companyList = null;
            _companyPeriodList = null;
            _chartOfAccountList = null;
            _accountList = null;
            _daybookList = null;
            _itemGroupList = null;
            _itemCategoryList = null;
        }
    }
}
