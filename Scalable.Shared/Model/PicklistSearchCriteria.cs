namespace Scalable.Shared.Model
{
    public class PicklistSearchCriteria
    {
        public string SearchText { get; private set; }
        public int Count { get; private set; }
        public bool PopulateFullDetails { get; private set; }

        public PicklistSearchCriteria(string searchText, int count)
            : this(searchText, false, count)
        {
        }

        public PicklistSearchCriteria(bool populateFullDetails, int count)
            : this(string.Empty, populateFullDetails, count)
        {
        }

        private PicklistSearchCriteria(string searchText, bool populateFullDetails, int count)
        {
            SearchText = searchText;
            PopulateFullDetails = populateFullDetails;
            Count = count;
        }
    }
}
