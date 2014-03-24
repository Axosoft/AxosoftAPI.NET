using AxosoftAPI.NET.Helpers;
using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace AxosoftAPI.NET
{
	public class BaseResponseResource<T> : IResource<T> where T : BaseModel, new()
	{
		protected string resource;

		protected BaseRequest request;

		public BaseResponseResource(string resource, IProxy client)
		{
			this.resource = resource;
			this.request = new BaseRequest(client);
		}

		public BaseResponseResource(string resource, BaseRequest request)
		{
			this.resource = resource;
			this.request = request;
		}

		protected virtual Result<R> Request<R>(Func<R> function)
		{
			try
			{
				return new Result<R>
				{
					Data = function()
				};
			}
			catch (Exception ex)
			{
				return request.GetInvalidResponse<R>(ex);
			}
		}

		protected virtual Result<R> Request<R>(Func<Response<R>> function)
		{
			try
			{
				return new Result<R>
				{
					Data = function().Data
				};
			}
			catch (Exception ex)
			{
				return request.GetInvalidResponse<R>(ex);
			}
		}

		public virtual Result<IEnumerable<T>> Get(IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<T>>(() =>
				request.Get<Response<IEnumerable<T>>>(resource, parameters));
		}

		public virtual Result<T> Get(int id, IDictionary<string, object> parameters = null)
		{
			return Request<T>(() =>
				request.Get<Response<T>>(string.Format("{0}/{1}", resource, id), parameters));
		}

		public virtual Result<T> Create(T entity, IDictionary<string, object> parameters = null)
		{
			return Request<T>(() =>
				request.Post<Response<T>>(resource, entity, parameters));
		}

		public virtual Result<T> Update(T entity, IDictionary<string, object> parameters = null)
		{
			return Request<T>(() =>
				request.Post<Response<T>>(string.Format("{0}/{1}", resource, entity.Id), entity, parameters));
		}

		public virtual Result<bool> Delete(int id, IDictionary<string, object> parameters = null)
		{
			return Request<bool>(() =>
				request.Delete(resource, id, parameters) != null);
		}
	}
}
