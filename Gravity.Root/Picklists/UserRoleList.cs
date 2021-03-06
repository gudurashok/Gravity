﻿using Gravity.Root.Repositories;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Gravity.Root.Picklists
{
    public class UserRoleList : PicklistBase
    {
        private readonly bool _onlySelection;

        public UserRoleList(bool onlySelection = true)
            : base("Name")
        {
            _onlySelection = onlySelection;
        }

        protected override string getTitleText()
        {
            return "Select user role";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        protected override UPicklist createControl()
        {
            return base.createControl(_onlySelection);
        }

        protected override IListRepository createRepository()
        {
            return new UserRoles();
        }
    }
}
