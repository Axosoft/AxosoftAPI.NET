using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public interface IAttachments : IGetResource<Attachment>, IUpdateResource<Attachment>, IDeleteResource<Attachment>
	{
		Result<AttachmentMetadata> GetData(int id, IList<KeyValuePair<string, object>> parameters = null);
	}
}
