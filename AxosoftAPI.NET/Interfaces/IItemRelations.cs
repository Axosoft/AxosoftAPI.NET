using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IItemRelations : IGetResource<ItemRelation>, ICreateResource<ItemRelation>, IUpdateResource<ItemRelation>, IDeleteResource<ItemRelation>
	{
	}
}
