using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class WorkLogs : BaseResponseResource<WorkLog>, IWorkLogs
	{
		public WorkLogs(IProxy client) : base("work_logs", client) { }

		public WorkLogs(BaseRequest request) : base("work_logs", request) { }
	}
}
