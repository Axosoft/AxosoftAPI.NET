using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
