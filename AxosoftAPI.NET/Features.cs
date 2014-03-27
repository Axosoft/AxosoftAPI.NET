using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Features : BaseItemResource<Item>, IFeatures
	{
		public Features(IProxy client) : base("features", client) { }

		public Features(BaseRequest request) : base("features", request) { }
	}
}
