using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class AttachmentMetadata : BaseModel
	{
		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("max_width")]
		public string MaxWidth { get; set; }

		[JsonProperty("max_height")]
		public string MaxHeight { get; set; }
	}
}
