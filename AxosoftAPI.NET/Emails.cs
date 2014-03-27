using System.Collections.Generic;
using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Emails : BaseResponseResource<Email>, IEmails
	{
		public Emails(IProxy client) : base("emails", client) { }

		public Emails(BaseRequest request) : base("emails", request) { }

		public Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<Attachment>>(() =>
				request.Get<Response<IEnumerable<Attachment>>>(string.Format("{0}/{1}/attachments", resource, id), parameters));
		}
	}
}
