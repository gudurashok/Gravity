using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class ForesightCompanyPeriod
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int PeriodId { get; set; }

        public bool IsNewCompany()
        {
            return CompanyId == 0;
        }
    }

    public class CompanyPeriod
    {
        public CompanyPeriodEntity Entity { get; set; }
        public Company Company { get; set; }
        public FiscalDatePeriod Period { get; set; }
        public ForesightCompanyPeriod Foresight { get; set; }

        public CompanyPeriod(CompanyPeriodEntity entity)
        {
            Entity = entity;
            Foresight = new ForesightCompanyPeriod();
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public void Save()
        {
            var repo = new InsightRepository();
            if (isValid(repo.GetCompanyPeriodBy(Entity)))
                throw new ValidationException(Resources.CompanyPeriodAlreadyExist);

            repo.Save(Entity);
        }

        private bool isValid(CompanyPeriodEntity cp)
        {
            return cp != null && (IsNew() || Entity.Id != cp.Id);
        }

        public static CompanyPeriod New()
        {
            return new CompanyPeriod(new CompanyPeriodEntity());
        }
    }
}
