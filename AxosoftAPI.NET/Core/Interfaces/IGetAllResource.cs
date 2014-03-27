using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Core.Interfaces
{
	public interface IGetAllResource<T>
	{
		Result<IEnumerable<T>> Get(IDictionary<string, object> parameters = null);
	}
}
