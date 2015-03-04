using Newtonsoft.Json;
using System.Collections.Generic;

namespace AxosoftAPI.NET.Models
{
    public class PicklistItem : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("picklist_type")]
        public string PicklistType { get; set; }

        [JsonProperty("values")]
        public IEnumerable<PicklistValue> Values { get; set; }
    }
}
