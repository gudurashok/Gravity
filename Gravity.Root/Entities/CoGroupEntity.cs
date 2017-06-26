using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class CoGroupEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "CoGroupNameCannotBeEmpty")]
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string ForesightDatabaseName { get; set; }
        
        public static CoGroupEntity New()
        {
            return new CoGroupEntity { Id = EntityPrefix.CoGroupPrefix };
        }
    }
}
