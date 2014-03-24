using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class TimeUnit : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("abbreviation")]
		public string Abbreviation { get; set; }

		[JsonProperty("conversion_factor")]
		public int? ConversionFactor { get; set; }

		[JsonProperty("order")]
		public int? Order { get; set; }
	}
}
