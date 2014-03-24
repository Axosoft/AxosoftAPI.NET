using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET.Models
{
	public class FocusResources
	{
		[JsonProperty("features")]
		public Resources Features { get; set; }

		[JsonProperty("defects")]
		public Resources Defects { get; set; }

		[JsonProperty("incidents")]
		public Resources Incidents { get; set; }
	}
}
