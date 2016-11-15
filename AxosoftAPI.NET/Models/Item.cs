using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Item : BaseModel
	{
		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("customer")]
		public Customer Customer { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }

		[JsonProperty("resolution")]
		public string Resolution { get; set; }

		[JsonProperty("replication_procedures")]
		public string ReplicationProcedures { get; set; }

		[JsonProperty("percent_complete")]
		public int? PercentComplete { get; set; }

		[JsonProperty("archived")]
		public bool? Archived { get; set; }

		[JsonProperty("publicly_viewable")]
		public bool? PubliclyViewable { get; set; }

		[JsonProperty("is_completed")]
		public bool? IsCompleted { get; set; }

		[JsonProperty("completion_date")]
		public DateTime? CompletionDate { get; set; }

		[JsonProperty("due_date")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("reported_date")]
		public DateTime? ReportedDate { get; set; }

		[JsonProperty("start_date")]
		public DateTime? StartDate { get; set; }

		[JsonProperty("assigned_to")]
		public Assignee AssignedTo { get; set; }

		[JsonProperty("priority")]
		public Priority Priority { get; set; }

		[JsonProperty("project")]
		public Project Project { get; set; }

		[JsonProperty("release")]
		public Release Release { get; set; }

		[JsonProperty("reported_by")]
		public User ReportedBy { get; set; }

		[JsonProperty("reported_by_customer_contact")]
		public Contact ReportedByCustomerContact { get; set; }

		[JsonProperty("status")]
		public Status Status { get; set; }

		[JsonProperty("severity")]
		public Severity Severity { get; set; }

		[JsonProperty("category")]
		public Category Category { get; set; }

		[JsonProperty("escalation_level")]
		public Escalation EscalationLevel { get; set; }

		[JsonProperty("actual_duration")]
		public DurationUnit ActualDuration { get; set; }

		[JsonProperty("estimated_duration")]
		public DurationUnit EstimatedDuration { get; set; }

		[JsonProperty("remaining_duration")]
		public DurationUnit RemainingDuration { get; set; }

		[JsonProperty("custom_fields")]
		public IDictionary<string, object> CustomFields { get; set; }

		[JsonProperty("parent")]
		public Item Parent { get; set; }

		[JsonProperty("item_type")]
		public string ItemType { get; set; }

		[JsonProperty("build_number")]
		public string BuildNumber { get; set; }

		[JsonProperty("build_number_of_fix")]
		public string BuildNumberOfFix { get; set; }

		[JsonProperty("workflow_step")]
		public WorkflowStep WorkflowStep { get; set; }
	}
}
