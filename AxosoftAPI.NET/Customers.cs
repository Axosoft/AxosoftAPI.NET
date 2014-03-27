using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Customers : BaseResponseResource<Customer>, ICustomers
	{
		public Customers(IProxy client) : base("customers", client) { }

		public Customers(BaseRequest request) : base("customers", request) { }

		public Result<Customer> GetInit()
		{
			return Request<Customer>(() =>
				request.Get<Response<Customer>>(string.Format("{0}/init", resource)));
		}
	}
}
