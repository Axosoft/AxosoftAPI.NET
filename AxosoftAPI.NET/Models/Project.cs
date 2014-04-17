using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

		[JsonProperty("escalations")]
		public Escalation Escalations { get; set; }

		[JsonProperty("custom_fields")]
		public IDictionary<string, object> CustomFields { get; set; }

		[JsonProperty("workflows")]
		public IEnumerable<Workflow> Workflows { get; set; }

		[JsonProperty("field_templates")]
		public IEnumerable<FieldTemplate> FieldTemplates { get; set; }

		[JsonProperty("customer_portal_templates")]
		public IEnumerable<CustomerPortalTemplate> CustomerPortalTemplates { get; set; }

		[JsonProperty("children")]
		public IEnumerable<Project> Children { get; set; }

		[JsonProperty("releases")]
		public ReleaseAccess Releases { get; set; }
	}
}
