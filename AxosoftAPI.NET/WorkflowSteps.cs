using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class WorkflowSteps : BaseResponseResource<WorkflowStep>, IWorkflowSteps
	{
		public WorkflowSteps(IProxy client) : base("workflow_steps", client) { }

		public WorkflowSteps(BaseRequest request) : base("workflow_steps", request) { }
	}
}
