using System;
using System.ComponentModel;
using System.Linq;

namespace AxosoftAPI.NET.Helpers
{
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
			var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

			if (attrs != null && attrs.Any())
			{
				var attr = attrs.FirstOrDefault();

				return ((DescriptionAttribute)attrs.FirstOrDefault()).Description;
			}

			return value.ToString();
		}
	}
}
