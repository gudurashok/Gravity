namespace Scalable.Shared.Model
{
    public class ListItem : IListItem
    {
        public string Id { get; set; }
        public int Nr { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }
    }
}
