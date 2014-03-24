using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface IGetResource<T>
	{
		Result<T> Get(int id, IDictionary<string, object> parameters = null);
	}
}
