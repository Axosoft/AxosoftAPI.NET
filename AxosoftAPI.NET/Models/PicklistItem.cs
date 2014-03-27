using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class PicklistItem : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("order")]
		public int Order { get; set; }
	}
}
