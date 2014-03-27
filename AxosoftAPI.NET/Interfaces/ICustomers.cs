using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface ICustomers : IResource<Customer>
	{
		Result<Customer> GetInit();
	}
}
