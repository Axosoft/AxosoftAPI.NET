using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
