using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Comments : BaseResponseResource<Comment>, IComments
	{
		public Comments(IProxy client) : base("comments", client) { }

		public Comments(BaseRequest request) : base("comments", request) { }
	}
}
