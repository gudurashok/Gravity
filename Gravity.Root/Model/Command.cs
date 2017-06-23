using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gravity.Root.Enums;

namespace Gravity.Root.Model
{
    public class Command
    {
        public string Id { get; set; }
        public int Nr { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UIControlName { get; set; }
        public bool IsActive { get; set; }
        public AppCommandType Type { get; set; }
        public IList<CommandProp> Properties { get; set; }

        public Command()
        {
            Properties = new List<CommandProp>();
        }

        public string GetPropertyValue(string propertyName)
        {
            var result = Properties.First(p => p.PropName == propertyName);

            if (result == null)
                throw new ValidationException(
                    string.Format("Command property '{0}' not found for command {1}", propertyName, Name));

            return result.PropValue;
        }
    }
}
