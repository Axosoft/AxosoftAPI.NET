using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Core.Interfaces
{
	public interface IDeleteResource<T>
	{
		Result<bool> Delete(int id, IDictionary<string, object> parameters = null);
	}
}
