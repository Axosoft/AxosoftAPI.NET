using Newtonsoft.Json;
using AxosoftAPI.NET.Helpers;
using System;
using System.Collections.Generic;

namespace AxosoftAPI.NET.Models
{
	public class Project : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("is_active")]
		public bool? IsActive { get; set; }

		[JsonProperty("start_date")]
		public DateTime? StartDate { get; set; }

		[JsonProperty("due_date")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("parent")]
		public Project Parent { get; set; }

		[JsonProperty("children")]
		public IEnumerable<Project> Children { get; set; }

		[JsonProperty("releases")]
		public ReleaseAccess Releases { get; set; }
	}
}
