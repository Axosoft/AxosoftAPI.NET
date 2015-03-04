using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
    public class PicklistValue : BaseModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("picklist_id")]
        public int PicklistId { get; set; }
    }
}
