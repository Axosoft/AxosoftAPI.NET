using Newtonsoft.Json;
using System;

namespace AxosoftAPI.NET.Models
{
	public class WorkLogType : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
