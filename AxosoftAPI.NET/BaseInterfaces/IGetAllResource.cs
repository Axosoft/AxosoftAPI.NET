using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface IGetAllResource<T>
	{
		Result<IEnumerable<T>> Get(IDictionary<string, object> parameters = null);
	}
}
