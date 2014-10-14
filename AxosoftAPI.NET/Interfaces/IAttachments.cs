using System.Collections.Generic;
using System.IO;
using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IAttachments : IGetResource<Attachment>, IUpdateResource<Attachment>, IDeleteResource<Attachment>
	{
		Result<Stream> GetData(int id, IList<KeyValuePair<string, object>> parameters = null);
	}
}
