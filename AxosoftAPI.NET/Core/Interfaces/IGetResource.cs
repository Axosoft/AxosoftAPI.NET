using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Core.Interfaces
{
	public interface IGetResource<T>
	{
		Result<T> Get(int id, IDictionary<string, object> parameters = null);
	}
}
