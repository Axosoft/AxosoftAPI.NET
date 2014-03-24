using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET.Models
{
	public class SystemOptions
	{
		[JsonProperty("focus_resources")]
		public FocusResources FocusResources { get; set; }
	}
}
