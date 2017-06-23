namespace Insight.Domain.Entities
{
    public class ItemEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CategoryId { get; set; }
        public bool HasBom { get; set; }
        public bool IsActive { get; set; }
    }
}
