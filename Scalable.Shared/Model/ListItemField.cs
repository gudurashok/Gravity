namespace Scalable.Shared.Model
{
    public class ListItemField : IListItemField
    {
        public NumberField Nr { get; set; }
        public TextField Name { get; set; }
        public TextField Description { get; set; }
        public BooleanField IsActive { get; set; }
        public BooleanField IsPreferred { get; set; }

        public ListItemField()
        {
            Nr = new NumberField { Nr = 1, Name = "Nr", Caption = "Nr.", DefaultValue = 0 };
            Name = new TextField { Nr = 2, Name = "Name", Caption = "Name:", MaxLength = 80, Required = true, };
            Description = new TextField { Nr = 3, Name = "Description", Caption = "Description:" };
            IsActive = new BooleanField { Nr = 4, Name = "IsActive", Caption = "Is Actvie", DefaultValue = true };
            IsPreferred = new BooleanField { Nr = 5, Name = "IsPreferred", Caption = "Is Preferred", DefaultValue = false };
        }
    }
}
