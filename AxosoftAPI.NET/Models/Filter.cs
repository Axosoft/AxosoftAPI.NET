using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Filter : BaseModel
	{
		[JsonProperty("user")]
		public User User { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_public")]
		public bool? IsPublic { get; set; }

		[JsonProperty("item_type")]
		public string ItemType { get; set; }

		[JsonProperty("constraints")]
		public Constraints Constraints { get; set; }
	}
}
