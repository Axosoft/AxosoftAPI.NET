using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class SecurityRole : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_admin")]
		public bool IsAdmin { get; set; }
	}
}
