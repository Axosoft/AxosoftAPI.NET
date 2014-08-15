using System;
using System.Collections.Generic;
using AxosoftAPI.NET.Helpers;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Release : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("release_notes")]
		public string Notes { get; set; }

		[JsonProperty("is_active")]
		public string IsActive { get; set; }

		[JsonProperty("start_date")]
		public DateTime? StartDate { get; set; }

		[JsonProperty("due_date")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("velocity_start_date")]
		public DateTime? VelocityStartDate { get; set; }

		[JsonProperty("parent")]
		public Release Parent { get; set; }

		[JsonProperty("release_type")]
		[JsonConverter(typeof(ReleaseTypeConverter))]
		public ReleaseType ReleaseType { get; set; }

		[JsonProperty("status")]
		[JsonConverter(typeof(StatusConverter))]
		public Status Status { get; set; }

		[JsonProperty("associated_projects")]
		public IEnumerable<Project> AssociatedProjects { get; set; }

		[JsonProperty("children")]
		public IEnumerable<Release> SubReleases { get; set; }
	}
}
