using Newtonsoft.Json;
using System;

namespace AxosoftAPI.NET.Models
{
	public class WorkLog : BaseModel
	{
		[JsonProperty("project")]
		public Project Project { get; set; }

		[JsonProperty("release")]
		public Release Release { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }

		[JsonProperty("work_done")]
		public DurationUnit WorkDone { get; set; }

		[JsonProperty("item")]
		public Item Item { get; set; }

		[JsonProperty("work_log_type")]
		public WorkLogType WorklogType { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("date_time")]
		public DateTime? DateTime { get; set; }
	}
}
