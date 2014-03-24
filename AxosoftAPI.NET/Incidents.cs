using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class Incidents : BaseItemResource<Item>, IIncidents
	{
		public Incidents(IProxy client) : base("incidents", client) { }

		public Incidents(BaseRequest request) : base("incidents", request) { }
	}
}
