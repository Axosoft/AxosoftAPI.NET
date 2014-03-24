using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class Features : BaseItemResource<Item>, IFeatures
	{
		public Features(IProxy client) : base("features", client) { }

		public Features(BaseRequest request) : base("features", request) { }
	}
}
