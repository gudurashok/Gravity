using Gravity.Root.Entities;

namespace Gravity.Root.Model
{
    public class AppMenuItem
    {
        public AppMenuItemEntity Entity { get; set; }

        public AppMenuItem(AppMenuItemEntity entity)
        {
            Entity = entity;
        }
    }
}
