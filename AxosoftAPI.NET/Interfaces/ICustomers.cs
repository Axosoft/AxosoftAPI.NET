using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public interface ICustomers : IResource<Customer>
	{
		Result<Customer> GetInit();
	}
}
