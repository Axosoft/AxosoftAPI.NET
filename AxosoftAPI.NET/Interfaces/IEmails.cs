using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public interface IEmails : IGetResource<Email>, ICreateResource<Email>, IDeleteResource<Email>
	{
		Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null);
	}
}
