using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class WorkLogs : BaseResponseResource<WorkLog>, IWorkLogs
	{
		public WorkLogs(IProxy client) : base("work_logs", client) { }

		public WorkLogs(BaseRequest request) : base("work_logs", request) { }
	}
}
