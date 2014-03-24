using AxosoftAPI.NET.Helpers;
using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class BaseItemResource<T> : BaseResponseResource<T>, IItemResource<T> where T : Item, new()
	{
		public BaseItemResource(string resource, IProxy client) : base(resource, client) { }

		public BaseItemResource(string resource, BaseRequest request) : base(resource, request) { }

		public Result<IEnumerable<T>> Get(IList<int> filterIds, IDictionary<string, object> parameters = null)
		{
			// Get collection of items if any filters present
			if (filterIds != null && filterIds.Any())
			{
				// Get first set of items
				var result = Get(parameters.Concatenate("filter_id", filterIds[0]));

				// If we get an error, we're done
				if (!result.IsSuccessful)
				{
					return request.GetInvalidResponse<IEnumerable<T>>(new Exception(result.ErrorMessage));
				}

				// Get first collection
				var data = result.Data;

				// Get a list of features based on each filter
				foreach (var filterId in filterIds.Skip(1))
				{
					// Get next set of items
					result = Get(parameters.Concatenate("filter_id", filterId));

					// If we get an error, we're done
					if (!result.IsSuccessful)
					{
						return request.GetInvalidResponse<IEnumerable<T>>(new Exception(result.ErrorMessage));
					}

					// Intersect resutls
					data = data.Intersect(result.Data, new BaseModelComparer<T>());
				}

				// Return final collection
				return new Result<IEnumerable<T>>
				{
					Data = data
				};
			}

			// Otherwise return list of features w/o filters
			return Get(parameters);
		}

		public Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<Attachment>>(() =>
				request.Get<Response<IEnumerable<Attachment>>>(string.Format("{0}/{1}/attachments", resource, id), parameters));
		}

		public Result<IEnumerable<Email>> GetEmails(int id, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<Email>>(() =>
				request.Get<Response<IEnumerable<Email>>>(string.Format("{0}/{1}/emails", resource, id), parameters));
		}

		public override Result<T> Create(T entity, IDictionary<string, object> parameters = null)
		{
			return Request<T>(() =>
				request.Post<Response<T>>(resource, new ItemRequest { Item = entity }, parameters));
		}

		public override Result<T> Update(T entity, IDictionary<string, object> parameters = null)
		{
			return Request<T>(() =>
				request.Post<Response<T>>(string.Format("{0}/{1}", resource, entity.Id), new ItemRequest { Item = entity }, parameters));
		}

		public Result<Attachment> AddAttachment(int id, Attachment data, IDictionary<string, object> parameters = null)
		{
			return Request<Attachment>(() =>
				request.Post<Response<Attachment>>(string.Format("{0}/{1}/attachments", resource, id), data, parameters));
		}

		public Result<Notification> AddNotification(int id, Notification data, IDictionary<string, object> parameters = null)
		{
			return Request<Notification>(() =>
				request.Post<Response<Notification>>(string.Format("{0}/{1}/notifications", resource, id), data, parameters));
		}
	}
}
