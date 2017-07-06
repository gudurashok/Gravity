using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Foresight.Logic.DataAccess;
using Insight.Domain.Model;

namespace Foresight.Logic.Ledger
{
    public class LedgerBuilder
    {
        protected readonly DataContext targetDbContext;
        protected readonly CompanyPeriod companyPeriod;
        private delegate void ExecuteUpdateDelegate();
        public event UpdatingEventHandler Updating;
        public bool IsCancelled;

        public LedgerBuilder(DataContext targetDbContext, CompanyPeriod companyPeriod)
        {
            this.targetDbContext = targetDbContext;
            this.companyPeriod = companyPeriod;
        }

        #region Build Dimension Tables

        public void BuildDimensionTables()
        {
            targetDbContext.BeginTransaction();
            targetDbContext.DeleteCompanyPeriodLedgerData(companyPeriod);
            OnUpdating(new UpdatingEventArgs("Building dimension tables"));
            executeImport(populateAccountLedger);
            executeImport(populateItemLedger);
            targetDbContext.Commit();
        }

        #endregion

        private void executeImport(ExecuteUpdateDelegate executeUpdateDelegate)
        {
            if (IsCancelled) return;
            executeUpdateDelegate();
        }

        public void CancelUpdation()
        {
            IsCancelled = true;
        }

        #region Build Account Ledger

        private void populateAccountLedger()
        {
            var ledger = new List<AccountMonthlyLedger>();

            var trans = AccountTransTables.GetAllTransactionTables();
            foreach (var tran in trans)
            {
                var ledgerDataReader = targetDbContext.ReadLedgerData(tran, companyPeriod.Foresight.Id);
                populateAccountTransDimension(ledger, ledgerDataReader, tran);
                OnUpdating(new UpdatingEventArgs(string.Format("Building account ledger {0}", tran.TransName)));
                if (IsCancelled) break;
            }

            foreach (var account in ledger)
            {
                targetDbContext.InsertAccountLedger(account);
                OnUpdating(new UpdatingEventArgs(string.Format("Building account ledger {0}", account.AccountId)));
                if (IsCancelled) break;
            }
        }

        private void populateAccountTransDimension(IList<AccountMonthlyLedger> ledger, IDataReader rdr, AccountTransTables tran)
        {
            using (rdr)
            {
                while (rdr.Read())
                {
                    var accountId = rdr["AccountId"].ToString();
                    var month = Convert.ToInt32(rdr["Month"]);
                    var al = ledger.SingleOrDefault(a => a.AccountId == accountId && a.Month == month);
                    if (al == null)
                    {
                        al = new AccountMonthlyLedger
                        {
                            AccountId = accountId,
                            ChartOfAccountId = rdr["ChartOfAccountId"].ToString(),
                            Month = month,
                            CompanyPeriod = companyPeriod,

                        };
                        al.GetType().GetProperty(tran.TransName).SetValue(al, Convert.ToDecimal(rdr["Amount"]), null);
                        ledger.Add(al);
                    }
                    else
                    {
                        var amount = Convert.ToDecimal(al.GetType().GetProperty(tran.TransName).GetValue(al, null));
                        al.GetType().GetProperty(tran.TransName).SetValue(al, amount + Convert.ToDecimal(rdr["Amount"]), null);
                    }
                }
            }
        }

        #endregion

        #region Build Item Ledger

        private void populateItemLedger()
        {
            var items = new List<ItemMonthlyLedger>();
            var trans = ItemTransTables.GetAll();

            foreach (var tran in trans)
            {
                populateItemLedgerDimension(items, tran);
                OnUpdating(new UpdatingEventArgs(string.Format("Building item ledger {0}", tran.TransName)));
                if (IsCancelled) break;
            }

            foreach (var item in items)
            {
                targetDbContext.InsertItemLedger(item);
                OnUpdating(new UpdatingEventArgs(string.Format("Building item ledger {0}", item.ItemId)));
                if (IsCancelled) break;
            }
        }

        private void populateItemLedgerDimension(IList<ItemMonthlyLedger> items, ItemTransTables tran)
        {
            using (var rdr = targetDbContext.ReadItemLedger(tran, companyPeriod.Foresight.Id))
            {
                while (rdr.Read())
                {
                    var itemId = rdr["ItemId"].ToString();
                    var accountId = rdr["AccountId"].ToString();
                    var month = Convert.ToInt32(rdr["Month"]);
                    var il = items.SingleOrDefault(i => i.ItemId == itemId
                                    && i.AccountId == accountId && i.Month == month);
                    if (il == null)
                    {
                        il = new ItemMonthlyLedger
                        {
                            ItemId = itemId,
                            AccountId = accountId,
                            ChartOfAccountId = rdr["chartOfAccountId"].ToString(),
                            Month = month,
                            CompanyPeriod = companyPeriod
                        };
                        il.GetType().GetProperty(tran.TransName).SetValue(il, Convert.ToDecimal(rdr["Amount"]), null);
                        items.Add(il);
                    }
                    else
                    {
                        var amount = Convert.ToDecimal(il.GetType().GetProperty(tran.TransName).GetValue(il, null));
                        il.GetType().GetProperty(tran.TransName).SetValue(il, amount + Convert.ToDecimal(rdr["Amount"]), null);
                    }
                }
            }
        }

        #endregion

        public void OnUpdating(UpdatingEventArgs e)
        {
            Updating?.Invoke(this, e);
        }
    }
}
