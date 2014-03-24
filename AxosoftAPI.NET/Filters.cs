using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class Filters : BaseResponseResource<Filter>, IFilters
	{
		public Filters(IProxy client) : base("filters", client) { }

		public Filters(BaseRequest request) : base("filters", request) { }
	}
}
