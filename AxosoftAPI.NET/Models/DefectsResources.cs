using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Resources
	{
		[JsonProperty("columns")]
		public IDictionary<string, Column> Columns { get; set; }

		[JsonProperty("labels")]
		public IDictionary<string, string> Labels { get; set; }
	}
}
