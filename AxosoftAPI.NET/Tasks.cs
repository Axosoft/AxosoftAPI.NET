using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class Tasks : BaseItemResource<Item>, ITasks
	{
		public Tasks(IProxy client) : base("tasks", client) { }

		public Tasks(BaseRequest request) : base("tasks", request) { }
	}
}
