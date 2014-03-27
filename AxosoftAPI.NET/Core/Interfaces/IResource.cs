using System;

namespace AxosoftAPI.NET.Core.Interfaces
{
	public interface IResource<T> : IGetAllResource<T>, IGetResource<T>, ICreateResource<T>, IUpdateResource<T>, IDeleteResource<T>
	{
	}
}
