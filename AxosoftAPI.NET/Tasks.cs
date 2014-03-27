using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Tasks : BaseItemResource<Item>, ITasks
	{
		public Tasks(IProxy client) : base("tasks", client) { }

		public Tasks(BaseRequest request) : base("tasks", request) { }
	}
}
