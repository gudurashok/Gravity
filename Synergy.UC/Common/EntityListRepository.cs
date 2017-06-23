using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Synergy.UC.Controls;

namespace Synergy.UC.Common
{
    public class EntityListRepository : IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            return getEntities().Cast<dynamic>().ToList();
        }

        private IEnumerable<EntityItem> getEntities()
        {
            var entities = new List<EntityItem>();
            entities.Add(new EntityItem { Name = "TaskType", Caption = "Task Types", Editor = getEntityEditor(new UTaskType()) });
            entities.Add(new EntityItem { Name = "Location", Caption = "Locations", Editor = getEntityEditor(new ULocation()) });
            entities.Add(new EntityItem { Name = "Project", Caption = "Projects", Editor = getEntityEditor(new UProject()) });
            entities.Add(new EntityItem { Name = "Checklist", Caption = "Checklists", Editor = getEntityEditor(new UChecklist()) });
            return entities;
        }

        private iListEditor getEntityEditor(iListEditor editor)
        {
            editor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            editor.BorderStyle = BorderStyle.FixedSingle;
            editor.Initiliaze();
            return editor;
        }
    }
}
