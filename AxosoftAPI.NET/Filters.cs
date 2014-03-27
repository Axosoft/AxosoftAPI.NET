using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Filters : BaseResponseResource<Filter>, IFilters
	{
		public Filters(IProxy client) : base("filters", client) { }

		public Filters(BaseRequest request) : base("filters", request) { }
	}
}
