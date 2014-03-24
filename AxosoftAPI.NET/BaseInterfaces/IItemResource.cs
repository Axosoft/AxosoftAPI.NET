using System.Collections.Generic;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public interface IItemResource<T> : IResource<T>
	{
		Result<IEnumerable<T>> Get(IList<int> filterIds, IDictionary<string, object> parameters = null);

		Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null);

		Result<IEnumerable<Email>> GetEmails(int id, IDictionary<string, object> parameters = null);

		Result<Attachment> AddAttachment(int id, Attachment data, IDictionary<string, object> parameters = null);

		Result<Notification> AddNotification(int id, Notification data, IDictionary<string, object> parameters = null);
	}
}
