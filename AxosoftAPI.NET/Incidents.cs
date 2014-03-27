using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Incidents : BaseItemResource<Item>, IIncidents
	{
		public Incidents(IProxy client) : base("incidents", client) { }

		public Incidents(BaseRequest request) : base("incidents", request) { }
	}
}
