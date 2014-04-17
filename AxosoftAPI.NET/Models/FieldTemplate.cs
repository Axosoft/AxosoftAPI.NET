using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class FieldTemplate : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_inherited")]
		public bool? IsInherited { get; set; }

		[JsonProperty("item_type")]
		public string ItemType { get; set; }
	}
}
