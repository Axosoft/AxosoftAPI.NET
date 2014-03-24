using AxosoftAPI.NET.Helpers;
using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace AxosoftAPI.NET
{
	public class BaseRequest
	{
		protected IProxy client;

		public BaseRequest(IProxy client)
		{
			this.client = client;
		}

		public Result<T> GetInvalidResponse<T>(Exception ex)
		{
			// Create default instance
			return new Result<T>
			{
				IsSuccessful = false,
				ErrorMessage = ex.Message
			};
		}

		public virtual string GetVersionedUri()
		{
			return string.Format(@"{0}/api/{1}", client.Url, client.Version.GetDescription());
		}

		public virtual string GetVersionedResourceUri(string resource)
		{
			return string.Format(@"{0}/{1}", GetVersionedUri(), resource);
		}

		public virtual R Get<R>(string resource, IDictionary<string, object> parameters = null)
		{
			var request = BuildRequest(resource, parameters);

			return request.Get<R, ErrorResponse>();
		}

		public virtual R Post<R>(string resource, object content, IDictionary<string, object> parameters = null)
		{
			var request = BuildRequest(resource, parameters);

			return request.Post<R, ErrorResponse>(content);
		}

		public virtual object Delete(string resource, int id, IDictionary<string, object> parameters = null)
		{
			var request = BuildRequest(string.Format("{0}/{1}", resource, id), parameters);

			return request.Delete<object, ErrorResponse>();
		}

		public virtual object Delete(string resource, IDictionary<string, object> parameters = null)
		{
			var request = BuildRequest(string.Format("{0}", resource), parameters);

			return request.Delete<object, ErrorResponse>();
		}

		protected virtual HttpWebRequest BuildRequest(string resource, IDictionary<string, object> parameters = null)
		{
			var inParameters = new Dictionary<string, object>();

			// Create new instance of parameters (if necessary)
			if (parameters != null)
			{
				inParameters.Append(parameters);
			}

			// If Access token available then add to parameters list
			if (!string.IsNullOrWhiteSpace(client.AccessToken))
			{
				inParameters.Add("access_token", client.AccessToken);
			}

			// Build URI
			var uri = new UriBuilder(GetVersionedResourceUri(resource));

			// Add all parameters to URI
			uri.AddParameters(inParameters);

			// Create and return new web request
			return WebRequest.CreateHttp(uri.ToString());
		}
	}
}
