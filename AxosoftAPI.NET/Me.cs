using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Me : BaseResponseResource<User>, IMe
	{
		public Me(IProxy client) : base("me", client) { }

		public Me(BaseRequest request) : base("me", request) { }

		public Result<User> Get()
		{
			return Request<User>(() =>
				request.Get<Response<User>>(resource));
		}
	}
}
