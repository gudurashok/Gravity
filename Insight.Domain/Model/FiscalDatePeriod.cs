using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;
using Scalable.Shared.Model;

namespace Insight.Domain.Model
{
    public class FiscalDatePeriod
    {
        public FiscalDatePeriodEntity Entity { get; set; }

        public FiscalDatePeriod(FiscalDatePeriodEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} to {2})",
                                Entity.Name,
                                Entity.Financial.From.ToShortDateString(),
                                Entity.Financial.To.ToShortDateString());
        }

        public static FiscalDatePeriod CreateInstanceFrom(DatePeriod period)
        {
            return new FiscalDatePeriod(
                        new FiscalDatePeriodEntity
                           {
                               Name = period.ToYearString(),
                               Financial = period,
                               Assessment = period.AddYears(1),
                           });
        }

        public void Save()
        {
            var repo = new InsightRepository();
            if (repo.GetFiscalDatePeriodByName(Entity.Name) != null)
                throw new ValidationException(Resources.FiscalDatePeriodAlreadyExist);

            repo.Save(Entity);
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public static FiscalDatePeriod New()
        {
            return new FiscalDatePeriod(new FiscalDatePeriodEntity());
        }
    }
}
