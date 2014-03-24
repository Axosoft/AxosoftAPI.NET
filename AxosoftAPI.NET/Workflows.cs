using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class Workflows : BaseResponseResource<Workflow>, IWorkflows
	{
		public Workflows(IProxy client) : base("workflows", client) { }

		public Workflows(BaseRequest request) : base("workflows", request) { }
	}
}
