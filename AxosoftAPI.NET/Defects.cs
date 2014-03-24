using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class Defects : BaseItemResource<Item>, IDefects
	{
		public Defects(IProxy client) : base("defects", client) { }

		public Defects(BaseRequest request) : base("defects", request) { }
	}
}
