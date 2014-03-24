using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class BasePicklistResource<T> : BaseResponseResource<T>, IPicklistResource<T> where T : BaseModel, new()
	{
		public BasePicklistResource(string resource, IProxy client) : base(resource, client) { }

		public BasePicklistResource(string resource, BaseRequest request) : base(resource, request) { }
	}
}
