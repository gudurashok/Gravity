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

        #region Factory Method

        public static string GetChartOfAccountIds(AccountTypes accountTypes)
        {
            return GetChartOfAccountIds((int)accountTypes);
        }

        public static string GetChartOfAccountIds(int coaId)
        {
            throw new NotImplementedException();

            //TODO: Should be uncommented later.
            //var coPeriods = InsightSession.Dbc.GetCompanyPeriods();
            //if (coPeriods.Count == 0 || coaId == 0)
            //    return " NOT IN ('') ";

            //var sb = new StringBuilder(" IN (");
            //var ids = InsightSession.Dbc.GetChartOfAccountIDsFor(coaId);
            //foreach (var id in ids)
            //    sb.Append(String.Format("'{0}',", id));

            //return sb.Remove(sb.Length - 1, 1).Append(") ").ToString();
        }

        #endregion
    }
}
