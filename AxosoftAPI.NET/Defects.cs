using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Defects : BaseItemResource<Item>, IDefects
	{
		public Defects(IProxy client) : base("defects", client) { }

		public Defects(BaseRequest request) : base("defects", request) { }
	}
}
