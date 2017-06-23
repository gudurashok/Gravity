using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class Daybook
    {
        public DaybookEntity Entity { get; private set; }
        public Account Account { get; set; }

        public Daybook(DaybookEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return Entity.Name;
        }

        public void Save()
        {
            var repo = new InsightRepository();
            if (IsNew() && repo.GetDaybookByName(Entity.Name) != null)
                throw new ValidationException(Resources.DaybookAlreadyExist);

            repo.Save(Entity);
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public static Daybook New()
        {
            return new Daybook(new DaybookEntity());
        }

        public IList<BillTerm> GetBillTerms()
        {
            var repo = new InsightRepository();
            return repo.GetBillTermsByDaybookId(Entity.Id);

        }
    }
}
