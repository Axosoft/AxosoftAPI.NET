using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public interface IPicklists
	{
		Result<IEnumerable<PicklistItem>> Get(string type, IDictionary<string, object> parameters = null);

		Result<PicklistItem> Get(string type, int id, IDictionary<string, object> parameters = null);

		IPicklistResource<Priority> Priority { get; }

		IPicklistResource<Severity> Severity { get; }

		IPicklistResource<Status> Status { get; }
	}
}
