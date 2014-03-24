using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET
{
	public interface IItemRelations : IGetResource<ItemRelation>, ICreateResource<ItemRelation>, IUpdateResource<ItemRelation>, IDeleteResource<ItemRelation>
	{
	}
}
