using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class ReleaseType : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("level")]
		public int Level { get; set; }
	}
}
