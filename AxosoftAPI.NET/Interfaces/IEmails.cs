using System.Collections.Generic;
using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IEmails : IGetResource<Email>, ICreateResource<Email>, IDeleteResource<Email>
	{
		Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null);
	}
}
