using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class Releases : BaseResponseResource<Release>, IReleases
	{
		public Releases(IProxy client) : base("releases", client) { }

		public Releases(BaseRequest request) : base("releases", request) { }
	}
}
