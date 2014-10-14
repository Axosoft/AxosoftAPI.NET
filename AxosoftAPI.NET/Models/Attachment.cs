using System.IO;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Attachment : BaseModel
	{
		[JsonProperty("file_name")]
		public string FileName { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("attach_date")]
		public string AttachDate { get; set; }

		[JsonProperty("source_id")]
		public int SourceId { get; set; }

		[JsonProperty("source_type")]
		public int SourceType { get; set; }

		[JsonProperty("data_hash")]
		public string DataHash { get; set; }

		[JsonIgnore]
		public string Content { get; set; }

		[JsonIgnore]
		public Stream Data { get; set; }
	}
}
