using System.Collections.Generic;
using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IAttachments : IGetResource<Attachment>, IUpdateResource<Attachment>, IDeleteResource<Attachment>
	{
		Result<AttachmentMetadata> GetData(int id, IList<KeyValuePair<string, object>> parameters = null);
	}
}
