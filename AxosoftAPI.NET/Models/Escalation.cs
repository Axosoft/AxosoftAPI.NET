using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Escalation : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_inherited")]
		public bool? IsInherited { get; set; }
	}
}
