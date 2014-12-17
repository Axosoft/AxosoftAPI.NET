using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Workflow : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("is_active")]
		public string IsActive { get; set; }

		[JsonProperty("workflow_steps")]
		public IEnumerable<WorkflowStep> WorkflowSteps { get; set; }

		[JsonProperty("is_inherited")]
		public bool? IsInherited { get; set; }

		[JsonProperty("item_type")]
		public string ItemType { get; set; }

		[JsonProperty("enforces_workflow_steps")]
		public bool? EnforcesWorkflowSteps { get; set; }

		[JsonProperty("restrict_new_items")]
		public bool? RestrictNewItems { get; set; }

		[JsonProperty("keep_moved_in_same_step")]
		public bool? KeepMovedInSameStep { get; set; }

		[JsonProperty("move_item_workflow_step")]
		public int? MoveItemWorkflowStep { get; set; }

		[JsonProperty("new_item_workflow_step")]
		public int? NewItemWorkflowStep { get; set; }
	}
}
