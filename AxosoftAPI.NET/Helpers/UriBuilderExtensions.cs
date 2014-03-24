using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxosoftAPI.NET.Helpers
{
	public static class UriBuilderExtensions
	{
		public static UriBuilder AddParameters(this UriBuilder uri, IDictionary<string, object> parameters = null)
		{
			if (parameters != null)
			{
				uri.Query = string.Join("&", parameters.Select(
					p => string.Format(@"{0}={1}", p.Key, HttpUtility.UrlEncode(p.Value.ToNullSafeString()))
				));
			}

			return uri;
		}

		public static UriBuilder AddParameters(this UriBuilder uri, IList<KeyValuePair<string, object>> parameters = null)
		{
			if (parameters != null)
			{
				uri.Query = string.Join("&", parameters.Select(
					p => string.Format(@"{0}={1}", p.Key, HttpUtility.UrlEncode(p.Value.ToNullSafeString()))
				));
			}

			return uri;
		}
	}
}
