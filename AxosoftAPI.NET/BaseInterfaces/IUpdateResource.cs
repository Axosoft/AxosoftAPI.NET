using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface IUpdateResource<T>
	{
		Result<T> Update(T entity, IDictionary<string, object> parameters = null);
	}
}
