using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IWorkLogs : IGetAllResource<WorkLog>, IDeleteResource<WorkLog>
	{
	}
}
