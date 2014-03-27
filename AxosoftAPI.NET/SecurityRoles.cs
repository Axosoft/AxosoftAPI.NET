using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class SecurityRoles : BaseResponseResource<SecurityRole>, ISecurityRoles
	{
		public SecurityRoles(IProxy client) : base("security_roles", client) { }

		public SecurityRoles(BaseRequest request) : base("security_roles", request) { }
	}
}
