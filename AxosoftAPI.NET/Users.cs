using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Users : BaseResponseResource<User>, IUsers
	{
		public Users(IProxy client) : base("users", client) { }

		public Users(BaseRequest request) : base("users", request) { }
	}
}
