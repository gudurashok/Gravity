using System;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Raven.Client;

namespace Insight.Domain.Repositories
{
    public class TestInsightRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession _session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (SysConfig.TestDataInserted)
                    return;

                createAccounts();
                createBankDaybooks();
                _session.SaveChanges();
                SysConfig.TestDataInserted = true;
            }
        }

        #endregion

        private void createAccounts()
        {
            _session.Store(new AccountEntity
            {
                Name = "Mangalam Rice, Flour and Pulse Mills",
                ChartOfAccountId = getCustomersChartOfAccountId(),
                IsActive = true
            });

            _session.Store(new AccountEntity
            {
                Name = "Hibernating Rhinos Ltd.",
                ChartOfAccountId = getSuppliersChartOfAccountId(),
                IsActive = true
            });
        }

        private string getCustomersChartOfAccountId()
        {
            var parentId = getChartOfAccountId("20302", null);
            return getChartOfAccountId("20302", parentId);
        }

        private string getSuppliersChartOfAccountId()
        {
            var parentId = getChartOfAccountId("10501", null);
            return getChartOfAccountId("10501", parentId);
        }

        private void createBankDaybooks()
        {
            var parentCoaId = getChartOfAccountParentId("20303");
            var chartOfAccountId = getChartOfAccountId("20303", parentCoaId);
            var d = new DaybookEntity();
            d.Name = "BANK OF BARODA";
            d.Type = DaybookType.Bank;
            d.AccountId = createAccount("BANK OF BARODA", chartOfAccountId);
            _session.Store(d);

            d = new DaybookEntity();
            d.Name = "STATE BANK OF INDIA";
            d.Type = DaybookType.Bank;
            d.AccountId = createAccount("STATE BANK OF INDIA", chartOfAccountId);
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
    }
}
