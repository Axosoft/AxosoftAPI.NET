using System.IO;
using System.Net;
using System.Text;
using AxosoftAPI.NET.Models;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Helpers
{
	public static class HttpWebRequestExtensions
	{
		private static JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore
		};

		public static T Get<T, Error>(this HttpWebRequest request) where Error : ErrorResponse
		{
			request.Method = "GET";
			return request.MakeRequest<T, Error>();
		}

		public static T Post<T, Error>(this HttpWebRequest request, object content) where Error : ErrorResponse
		{
			request.Method = "POST";
			request.SetContent(content);

			return request.MakeRequest<T, Error>();
		}

		public static T Delete<T, Error>(this HttpWebRequest request) where Error : ErrorResponse
		{
			request.Method = "DELETE";
			return request.MakeRequest<T, Error>();
		}

		public static T MakeRequest<T, Error>(this HttpWebRequest request) where Error : ErrorResponse
		{
			try
			{
				var response = request.GetResponse();

				if (typeof(T) == typeof(Stream))
				{
					return (T)(object)response.GetResponseStream();
				}
				else
				{
					return response.GetResponseStream().DeserializeToJson<T>();
				}
			}
			catch (WebException e)
			{
				ErrorResponse response = null;

				if (e.Response != null)
				{
					try
					{
						response = e.Response.GetResponseStream().DeserializeToJson<Error>();
					}
					catch
					{
						// No need to handle the exception here. A new exception is thrown below.
					}
				}

				throw new AxosoftAPIException<ErrorResponse>(response, e);
			}
		}

		public static void SetContent(this HttpWebRequest request, object content)
		{
			var requestStream = request.GetRequestStream();

			if (content is Stream)
			{
				request.ContentType = "application/octet-stream";
				(content as Stream).CopyTo(requestStream);
			}
			else
			{
				var encoding = new UTF8Encoding();

				request.ContentType = "application/json";
				request.Headers.Add("Content-Encoding", encoding.HeaderName);

				var serializedContent = JsonConvert.SerializeObject(content, Formatting.None, DefaultJsonSerializerSettings);

				var bytes = encoding.GetBytes(serializedContent);
				requestStream.Write(bytes, 0, bytes.Length);
			}
		}
	}
}
