using System;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Fields
	{
		[JsonProperty("field")]
		public string Field { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("info")]
		public string Info { get; set; }

		[JsonProperty("cols")]
		public string Cols { get; set; }

		[JsonProperty("editable")]
		public Boolean Editable { get; set; }
	}
}
