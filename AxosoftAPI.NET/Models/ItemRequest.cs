using System;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class ItemRequest : IEquatable<ItemRequest>
	{
		[JsonProperty("item")]
		public Item Item;

		public override int GetHashCode()
		{
			return Item == null || !Item.Id.HasValue ? 0 : Item.Id.GetHashCode();
		}

		public override bool Equals(object other)
		{
			return this.Equals(other as ItemRequest);
		}

		public bool Equals(ItemRequest other)
		{
			return (other != null &&
					other.Item != null &&
					this.Item != null &&
					other.Item.Id.HasValue &&
					this.Item.Id.HasValue &&
					this.Item.Id.Value == other.Item.Id.Value);
		}
	}
}
