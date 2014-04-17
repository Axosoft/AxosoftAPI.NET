using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Category : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
