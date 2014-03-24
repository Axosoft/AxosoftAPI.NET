using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class CustomFields : BaseResponseResource<CustomField>, ICustomFields
	{
		public CustomFields(IProxy client) : base("fields/custom", client) { }

		public CustomFields(BaseRequest request) : base("fields/custom", request) { }
	}
}
