using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class ItemRelations : BaseResponseResource<ItemRelation>, IItemRelations
	{
		public ItemRelations(IProxy client) : base("item_relations", client) { }

		public ItemRelations(BaseRequest request) : base("item_relations", request) { }
	}
}
