using Gravity.Root.Model;

namespace Gravity.Root.ViewModel
{
    public class UserHeirarchyListItem
    {
        public User User;

        public string Name
        {
            get { return User.Entity.Name; }
        }

        public string Parent
        {
            get { return User.Parent == null || User.Parent.Entity == null ? string.Empty : User.Parent.Entity.Name; }
        }
    }
}
