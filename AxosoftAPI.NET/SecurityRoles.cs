using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class SecurityRoles : BaseResponseResource<SecurityRole>, ISecurityRoles
	{
		public SecurityRoles(IProxy client) : base("security_roles", client) { }

		public SecurityRoles(BaseRequest request) : base("security_roles", request) { }
	}
}
