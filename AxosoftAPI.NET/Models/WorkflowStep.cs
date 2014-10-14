using Newtonsoft.Json;
using System;

namespace AxosoftAPI.NET.Models
{
	public class WorkflowStep : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("order")]
		public int Order { get; set; }
	}
}
