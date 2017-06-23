using System.Collections.Generic;
using Raven.Imports.Newtonsoft.Json;

namespace Mingle.Domain.Entities
{
    public class ReferenceListEntity
    {
        public string Id { get; set; }
        public IList<string> Items { get; set; }

        [JsonIgnore]
        public int ItemsCount { get; set; }
    }
}
