using System;
using System.ComponentModel.DataAnnotations;
using Insight.Domain.Common;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;
using Scalable.Shared.Extensions;

namespace Insight.Domain.Model
{
    public class TransactionHeader
    {
        public TransactionHeaderEntity Entity { get; set; }
        public Daybook Daybook { get; set; }
        public Account Account { get; set; }
        public CompanyPeriod CompanyPeriod { get; set; }

        public virtual void Save()
        {
            validate();

            CompanyPeriod = InsightSession.CompanyPeriod;
            Entity.CompanyPeriodId = CompanyPeriod.Entity.Id;
            Entity.CompanyId = CompanyPeriod.Company.Entity.Id;
            Entity.PeriodId = CompanyPeriod.Period.Entity.Id;
            SetDocumentNr();

            var repo = new InsightRepository();
            repo.Save(Entity);
        }

        private void validate()
        {
            validateAccount();
            validateDate();
            validateAmount();
        }

        private void validateAccount()
        {
            if (string.IsNullOrWhiteSpace(Entity.AccountId) && !IsJV())
                throw new ValidationException(Resources.AccountNameCannotBeEmpty);
        }

        private bool IsJV()
        {
            return (Entity as JournalVoucherEntity) != null;
        }

        private void validateDate()
        {
            if (Entity.Date > DateTime.Today.Date
                    || !Entity.Date.IsBetween(
                            InsightSession.CompanyPeriod.Period.Entity.Financial.From.Date,
                            InsightSession.CompanyPeriod.Period.Entity.Financial.To.Date))
                throw new ValidationException(Resources.InvalidDate);
        }

        private void validateAmount()
        {
            if (Entity.Amount == 0)
                throw new ValidationException(Resources.AmountCannotBeZero);
        }

        protected virtual void SetDocumentNr()
        {
            //Should always be overridden
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }
    }
}
