using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Assignee
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
