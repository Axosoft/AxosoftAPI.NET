using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class Users : BaseResponseResource<User>, IUsers
	{
		public Users(IProxy client) : base("users", client) { }

		public Users(BaseRequest request) : base("users", request) { }
	}
}
