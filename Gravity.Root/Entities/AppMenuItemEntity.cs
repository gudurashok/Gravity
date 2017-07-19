using System.Drawing;
using System.Windows.Forms;
using Gravity.Root.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Gravity.Root.Entities
{
    public class AppMenuItemEntity
    {
        public string Id { get; set; }
        public int Nr { get; set; }
        public string DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string UIControlName { get; set; }
        public string UIControlPath { get; set; }
        public string UIAssembly { get; set; }
        public Keys ShortcutKeys { get; set; }
        public Font Font { get; set; }
        public bool IsForAdminOnly { get; set; }
        public IList<AppMenuItemEntity> SubItems { get; set; }

        public AppMenuItemEntity()
        {
            SubItems = new List<AppMenuItemEntity>();
        }

        public bool HasSubItems()
        {
            return SubItems.Count > 0;
        }
    }
}
