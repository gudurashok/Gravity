namespace Scalable.Shared.Model
{
    public interface IListItemField
    {
        NumberField Nr { get; set; }
        TextField Name { get; set; }
        TextField Description { get; set; }
        BooleanField IsActive { get; set; }
        BooleanField IsPreferred { get; set; }
    }
}
