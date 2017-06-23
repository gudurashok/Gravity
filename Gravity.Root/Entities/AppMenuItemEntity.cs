using System.Drawing;
using System.Windows.Forms;
using Gravity.Root.Enums;

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
    }
}
