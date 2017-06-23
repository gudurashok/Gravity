using Scalable.Win.Picklist;

namespace Mingle.UC.Picklists
{
    public static class PicklistFactory
    {
        private static PartyList partyList;

        public static IPicklist Parties
        {
            get { return partyList ?? (partyList = new PartyList()); }
        }

        public static void ClearPicklistCache()
        {
            partyList = null;
        }
    }
}
