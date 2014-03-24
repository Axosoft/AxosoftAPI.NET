using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public class ItemRelations : BaseResponseResource<ItemRelation>, IItemRelations
	{
		public ItemRelations(IProxy client) : base("item_relations", client) { }

		public ItemRelations(BaseRequest request) : base("item_relations", request) { }
	}
}
