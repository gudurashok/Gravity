using Scalable.Win.Picklist;

namespace Gravity.Root.Picklists
{
    public static class PicklistFactory
    {
        private static RoleResponsibilityList roleResponsibilityList;
        private static UserList userList;
        private static UserRoleList userRoleList;
        private static UserHeirarchyList userHeirarchyList;
        //private static CoGroupList coGroupList;

        //public static IPicklist CoGroups
        //{
        //    get { return coGroupList ?? (coGroupList = new CoGroupList()); }
        //}

        public static IPicklist Users
        {
            get { return userList ?? (userList = new UserList()); }
        }

        public static IPicklist RoleResponsibilities
        {
            get { return roleResponsibilityList ?? (roleResponsibilityList = new RoleResponsibilityList()); }
        }

        public static IPicklist UserRoles
        {
            get { return userRoleList ?? (userRoleList = new UserRoleList()); }
        }

        public static IPicklist UserHeirarchy
        {
            get { return userHeirarchyList ?? (userHeirarchyList = new UserHeirarchyList()); }
        }

        public static void ClearPickListCache()
        {
            userList = null;
            roleResponsibilityList = null;
            userRoleList = null;
            userHeirarchyList = null;
            //coGroupList = null;
        }
    }
}
