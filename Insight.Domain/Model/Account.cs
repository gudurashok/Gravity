using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;
using Mingle.Domain.Model;
using Scalable.Shared.Common;
using Insight.Domain.Common;
using Insight.Domain.Enums;

namespace Insight.Domain.Model
{
    public class Account
    {
        public AccountEntity Entity { get; private set; }
        public Account Group { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }
        public Party Party { get; set; }
        public AccountOpeningBalanceEntity OpeningBalance { get; set; }

        public Account(AccountEntity entity)
        {
            Entity = entity;
            OpeningBalance = new AccountOpeningBalanceEntity
            {
                AccountId = entity.Id,
            };
        }

        public decimal GetOpeningBalance()
        {
            if (OpeningBalance == null)
                return 0;

            return OpeningBalance.Amount;
        }

        public string ToStringAddress()
        {
            return string.Format("{0} {1} {2} {3} {4}", Entity.AddressLine1, Entity.AddressLine2,
                                                        Entity.City, Entity.State, Entity.Pin);
        }

        public override string ToString()
        {
            return Entity.Name;
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public bool HasOpeningBalance
        {
            get
            {
                return OpeningBalance.Amount != 0;
            }
        }

        public TxnType OpeningBalanceType
        {
            get
            {
                if (OpeningBalance.Amount == 0) return TxnType.None;
                if (OpeningBalance.Amount > 0) return TxnType.Credit;
                return TxnType.Debit;
            }
        }

        public void Save()
        {
            if (HasOpeningBalance && ChartOfAccount.IsProfitAndLossType)
                throw new ValidationException("Opening Balance cannot be set for balance sheet accounts");

            var repo = new InsightRepository();
            if (IsNew() && repo.GetAccountByName(Entity.Name) != null)
                throw new ValidationException(Resources.AccountAlreadyExist);

            repo.Save(Entity);

            OpeningBalance.AccountId = Entity.Id;
            OpeningBalance.CompanyPeriodId = InsightSession.CompanyPeriod.Entity.Id;
            OpeningBalance.CompanyId = InsightSession.CompanyPeriod.Company.Entity.Id;
            OpeningBalance.PeriodId = InsightSession.CompanyPeriod.Period.Entity.Id;
            repo.Save(OpeningBalance);
        }

        public static Account New()
        {
            return new Account(new AccountEntity());
        }
    }
}
