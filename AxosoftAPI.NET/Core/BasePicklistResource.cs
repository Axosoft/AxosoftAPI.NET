using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Core
{
	public class BasePicklistResource<T> : BaseResponseResource<T>, IPicklistResource<T> where T : BaseModel, new()
	{
		public BasePicklistResource(string resource, IProxy client) : base(resource, client) { }

		public BasePicklistResource(string resource, BaseRequest request) : base(resource, request) { }
	}
}
