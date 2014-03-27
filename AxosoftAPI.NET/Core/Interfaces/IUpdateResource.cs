using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Core.Interfaces
{
	public interface IUpdateResource<T>
	{
		Result<T> Update(T entity, IDictionary<string, object> parameters = null);
	}
}
