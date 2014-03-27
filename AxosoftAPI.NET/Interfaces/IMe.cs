using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IMe
	{
		Result<User> Get();
	}
}
