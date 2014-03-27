using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Releases : BaseResponseResource<Release>, IReleases
	{
		public Releases(IProxy client) : base("releases", client) { }

		public Releases(BaseRequest request) : base("releases", request) { }
	}
}
