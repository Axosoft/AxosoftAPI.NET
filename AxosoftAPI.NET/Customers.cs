using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
