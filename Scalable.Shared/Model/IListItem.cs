namespace Scalable.Shared.Model
{
    public interface IListItem
    {
        string Id { get; set; }
        int Nr { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        bool IsPreferred { get; set; }
    }
}
