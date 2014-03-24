using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class Picklists : BaseResponseResource<PicklistItem>, IPicklists
	{
		public IPicklistResource<Priority> Priority { get; set; }

		public IPicklistResource<Severity> Severity { get; set; }

		public IPicklistResource<Status> Status { get; set; }

		public Picklists(IProxy client) : base("picklists", client)
		{
			Priority = new BasePicklistResource<Priority>("picklists/priority", client);
			Severity = new BasePicklistResource<Severity>("picklists/severity", client);
			Status = new BasePicklistResource<Status>("picklists/status", client);
		}

		public Picklists(BaseRequest request) : base("picklists", request)
		{
			Priority = new BasePicklistResource<Priority>("picklists/priority", request);
			Severity = new BasePicklistResource<Severity>("picklists/severity", request);
			Status = new BasePicklistResource<Status>("picklists/status", request);
		}

		public Result<IEnumerable<PicklistItem>> Get(string type, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<PicklistItem>>(() =>
				request.Get<Response<IEnumerable<PicklistItem>>>(string.Format("{0}/{1}", resource, type), parameters));
		}

		public Result<PicklistItem> Get(string type, int id, IDictionary<string, object> parameters = null)
		{
			return Request<PicklistItem>(() =>
				request.Get<Response<PicklistItem>>(string.Format("{0}/{1}/{2}", resource, type, id), parameters));
		}
	}
}
