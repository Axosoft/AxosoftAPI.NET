using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET.Helpers
{
	public class BaseModelComparer<T> : IEqualityComparer<T> where T : BaseModel
	{
		public bool Equals(T x, T y)
		{
			if (x == y)
			{
				return true;
			}
			
			if (x == null || y == null)
			{
				return false;
			}

			if (!x.Id.HasValue || !y.Id.HasValue)
			{
				return false;
			}

			return x.Id.Value == y.Id.Value;
		}

		public int GetHashCode(T obj)
		{
			return obj != null && obj.Id.HasValue ? obj.Id.Value : 0;
		}
	}
}
