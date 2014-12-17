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

		[JsonProperty("enable_wip_limits")]
		public bool EnableWipLimits { get; set; }

		[JsonProperty("wip_items_per_step")]
		public int WipItemsPerStep { get; set; }

		[JsonProperty("enforce_wip_limits")]
		public bool EnforceWipLimits { get; set; }

		[JsonProperty("enable_wip_limits_per_user")]
		public bool EnableWipLimitsPerUser { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("wip_items_per_user")]
		public int WipItemsPerUser { get; set; }
	}
}
