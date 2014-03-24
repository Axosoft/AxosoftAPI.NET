using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface IDeleteResource<T>
	{
		Result<bool> Delete(int id, IDictionary<string, object> parameters = null);
	}
}
