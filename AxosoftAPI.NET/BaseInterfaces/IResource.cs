using System.Collections.Generic;

namespace AxosoftAPI.NET
{
	public interface IResource<T> : IGetAllResource<T>, IGetResource<T>, ICreateResource<T>, IUpdateResource<T>, IDeleteResource<T>
	{
	}
}
