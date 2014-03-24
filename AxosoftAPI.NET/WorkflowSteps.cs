using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class WorkflowSteps : BaseResponseResource<WorkflowStep>, IWorkflowSteps
	{
		public WorkflowSteps(IProxy client) : base("workflow_steps", client) { }

		public WorkflowSteps(BaseRequest request) : base("workflow_steps", request) { }
	}
}
