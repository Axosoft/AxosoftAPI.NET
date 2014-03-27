using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Workflows : BaseResponseResource<Workflow>, IWorkflows
	{
		public Workflows(IProxy client) : base("workflows", client) { }

		public Workflows(BaseRequest request) : base("workflows", request) { }
	}
}
