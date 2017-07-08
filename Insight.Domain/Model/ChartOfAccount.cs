using System;
using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class ChartOfAccount
    {
        public ChartOfAccountEntity Entity { get; set; }
        public ChartOfAccount Parent { get; set; }

        public ChartOfAccount(ChartOfAccountEntity entity)
        {
            Entity = entity;
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public void Save()
        {
            var repo = new InsightRepository();
            if (IsNew() && repo.GetChartOfAccountByName(Entity.Name) != null)
                throw new ValidationException(Resources.ChartOfAccountAlreadyExist);

            repo.Save(Entity);
        }

        public static ChartOfAccount New()
        {
            return new ChartOfAccount(new ChartOfAccountEntity());
        }
    }
}
