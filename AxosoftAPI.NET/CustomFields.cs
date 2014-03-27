using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class CustomFields : BaseResponseResource<CustomField>, ICustomFields
	{
		public CustomFields(IProxy client) : base("fields/custom", client) { }

		public CustomFields(BaseRequest request) : base("fields/custom", request) { }
	}
}
