using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Picklist;
using System;

namespace Gravity.Root.Picklists
{
    public class CoGroupList : PicklistBase
    {
        public CoGroupList(string searchProperty)
            : base("Name")
        {
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Clear();
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        protected override string getTitleText()
        {
            throw new NotImplementedException();
        }

        protected override IListRepository createRepository()
        {
            throw new NotImplementedException();
        }
    }
}
