using System;

namespace AxosoftAPI.NET.Helpers
{
	public static class ObjectExtensions
	{
		public static string ToNullSafeString(this object value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			var str = value.ToString();

			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}

			return str;
		}
	}
}
