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

		[JsonIgnore]
		public string Content { get; set; }

		[JsonIgnore]
		public Stream Data { get; set; }
	}
}
