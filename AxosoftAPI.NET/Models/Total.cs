using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Total
	{
		[JsonProperty("count")]
		public int Count { get; set; }
	}
}
