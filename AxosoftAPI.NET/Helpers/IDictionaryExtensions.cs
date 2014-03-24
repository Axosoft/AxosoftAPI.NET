using System;
using System.Collections.Generic;

namespace AxosoftAPI.NET.Helpers
{
	public static class IDictionaryExtensions
	{
		public static IDictionary<string, object> Concatenate(this IDictionary<string, object> first, string key, object value)
		{
			var result = new Dictionary<string, object>().Concatenate(first);

			result.Add(key, value);
			
			return result;
		}

		public static IDictionary<string, object> Concatenate(this IDictionary<string, object> first, IDictionary<string, object> second)
		{
			if (first != null && second == null)
			{
				return new Dictionary<string, object>().Append(first);
			}

			if (first == null && second != null)
			{
				return new Dictionary<string, object>().Append(second);
			}

			return new Dictionary<string, object>().Append(first).Append(second);
		}

		public static IDictionary<string, object> Append(this IDictionary<string, object> first, IDictionary<string, object> second)
		{
			if (first != null && second != null)
			{
				second.ForEach(x => first.Add(x));
			}

			return first;
		}

		public static void ForEach(this IDictionary<string, object> dictionary, Action<KeyValuePair<string, object>> action)
		{
			if (dictionary != null)
			{
				foreach (var item in dictionary)
				{
					action(item);
				}
			}
		}
	}
}
