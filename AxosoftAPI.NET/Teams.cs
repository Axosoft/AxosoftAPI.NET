using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Teams : BaseResponseResource<Team>, ITeams
	{
		public Teams(IProxy client) : base("teams", client) { }

		public Teams(BaseRequest request) : base("teams", request) { }
	}
}
