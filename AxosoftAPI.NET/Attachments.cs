using System.Collections.Generic;
using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Attachments : BaseResponseResource<Attachment>, IAttachments
	{
		public Attachments(IProxy client) : base("attachments", client) { }

		public Attachments(BaseRequest request) : base("attachments", request) { }

		public Result<AttachmentMetadata> GetData(int id, IList<KeyValuePair<string, object>> parameters = null)
		{
			return Request<AttachmentMetadata>(() =>
				request.Get<Response<AttachmentMetadata>>(string.Format("{0}/{1}/data", resource, id)));
		}
	}
}
