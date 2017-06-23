using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mingle.UC.Controls;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Mingle.UC.Common
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
            entities.Add(new EntityItem { Name = "BasicInfo", Caption = "Basic Info", Editor = getEntityEditor(new UPartyBasic()) });
            entities.Add(new EntityItem { Name = "Addresses", Caption = "Addresses", Editor = getEntityEditor(new UPartyAddresses()) });
            entities.Add(new EntityItem { Name = "ContactsAndProfessions", Caption = "Contacts & Professions", Editor = getEntityEditor(new UPartyContactsAndProfessions()) });
            entities.Add(new EntityItem { Name = "EmailsAndIMs", Caption = "Emails & IMs", Editor = getEntityEditor(new UEmailsAndIMs()) });
            entities.Add(new EntityItem { Name = "WebsitesAndDates", Caption = "Websites & Dates", Editor = getEntityEditor(new UWebsitesAndDates()) });
            entities.Add(new EntityItem { Name = "PhotoAndCustomAttributes", Caption = "Photo & Custom", Editor = getEntityEditor(new UPhotoAndCustom()) });
            entities.Add(new EntityItem { Name = "Other", Caption = "Other", Editor = getEntityEditor(new UPartyOther()) });
            return entities;
        }

        private IParty getEntityEditor(IParty editor)
        {
            editor.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            editor.Control.BorderStyle = BorderStyle.FixedSingle;
            editor.Initialize();
            return editor;
        }
    }
}
