using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Template : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
