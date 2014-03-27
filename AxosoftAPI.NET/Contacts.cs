using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

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
