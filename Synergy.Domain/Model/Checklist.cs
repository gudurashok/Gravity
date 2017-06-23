using System.Collections.Generic;
using System.Text;
using System.Linq;
using Synergy.Domain.Entities;

namespace Synergy.Domain.Model
{
    public class Checklist
    {
        public ChecklistEntity Entity { get; private set; }

        public Checklist(ChecklistEntity entity)
        {
            Entity = entity;
        }

        private Checklist()
        {
            Entity = new ChecklistEntity();
        }

        public static Checklist New()
        {
            return new Checklist();
        }

        public void Concat(IEnumerable<ChecklistItemEntity> items)
        {
            foreach (var item in items)
                CreateNewCheckListItem(item.Name);
        }

        public void CreateNewCheckListItem(string name)
        {
            var item = new ChecklistItemEntity
                        {
                            Nr = getNewChecklistItemNr(),
                            Name = name
                        };

            Entity.Items.Add(item);
        }

        private int getNewChecklistItemNr()
        {
            if (Entity.Items.Count > 0)
                return Entity.Items.Max(c => c.Nr) + 1;

            return 1;
        }

        public override string ToString()
        {
            return Entity.Name;
        }

        public string ToStringWithItems()
        {
            var result = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Entity.Name))
                result.AppendLine(Entity.Name);

            foreach (var item in Entity.Items)
                result.AppendLine(string.Format("{0}.{1}", item.Nr, item.Name));

            return result.ToString();
        }
    }
}
