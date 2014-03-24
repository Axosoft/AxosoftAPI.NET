using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface ICreateResource<T>
	{
		Result<T> Create(T entity, IDictionary<string, object> parameters = null);
	}
}
