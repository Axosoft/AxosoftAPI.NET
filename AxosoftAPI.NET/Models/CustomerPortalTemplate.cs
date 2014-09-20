using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class CustomerPortalTemplate
	{
		[JsonProperty("view_template")]
		public Template ViewTemplate { get; set; }

		[JsonProperty("add_template")]
		public Template AddTemplate { get; set; }

		[JsonProperty("edit_template")]
		public Template EditTemplate { get; set; }
		
		[JsonProperty("is_inherited")]
		public bool? IsInherited { get; set; }

		[JsonProperty("item_type")]
		public string ItemType { get; set; }
	}
}
