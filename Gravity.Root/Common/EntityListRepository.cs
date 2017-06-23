using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Controls;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Scalable.Win.FormControls;

namespace Gravity.Root.Common
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
            entities.Add(new EntityItem { Name = "Responsibilities", Caption = "Responsibilities", Editor = getEntityEditor(new UResponsibility()) });
            entities.Add(new EntityItem { Name = "Roles", Caption = "Roles", Editor = getEntityEditor(new URole()) });
            entities.Add(new EntityItem { Name = "UserRoles", Caption = "User Roles", Editor = getEntityEditor(new UUserRole()) });
            return entities;
        }

        private UListView getEntityEditor(UListView editor)
        {
            editor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            editor.BorderStyle = BorderStyle.FixedSingle;
            editor.Initialize();
            return editor;
        }
    }
}
