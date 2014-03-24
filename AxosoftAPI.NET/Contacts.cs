using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public class Contacts : BaseResponseResource<Contact>, IContacts
	{
		public Contacts(IProxy client) : base("contacts", client) { }

		public Contacts(BaseRequest request) : base("contacts", request) { }

		public Result<Contact> GetInit()
		{
			return Request<Contact>(() =>
				request.Get<Response<Contact>>(string.Format("{0}/init", resource)));
		}
	}
}
