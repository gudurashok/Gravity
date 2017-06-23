using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class BillTerm
    {
        public BillTermEntity Entity { get; set; }
        public Daybook Daybook { get; set; }

        public BillTerm(BillTermEntity entity)
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
            repo.Save(Entity);
        }

        public static BillTerm New()
        {
            return new BillTerm(new BillTermEntity());
        }
    }
}
