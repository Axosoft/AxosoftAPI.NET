using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AxosoftAPI.NET;
using System.Collections.Generic;
using System.Linq;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Tests.Models
{
	[TestClass]
	public class ItemRequestTest
	{
		[TestInitialize]
		public void Setup()
		{
		}

		[TestMethod]
		public void ItemRequest_GetHasCode_ItemNull()
		{
			var itemRequest = new ItemRequest
			{
			};

			var result = itemRequest.GetHashCode();

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ItemRequest_GetHasCode_Item_IdNull()
		{
			var itemRequest = new ItemRequest
			{
				Item = new Item()
			};

			var result = itemRequest.GetHashCode();

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ItemRequest_GetHasCode()
		{
			var valueInt = 99;

			var itemRequest = new ItemRequest
			{
				Item = new Item
				{
					Id = valueInt
				}
			};

			var hashZero = valueInt.GetHashCode();

			var result = itemRequest.GetHashCode();

			Assert.AreEqual(hashZero, result);
		}

		[TestMethod]
		public void ItemRequest_Equals_NullOther()
		{
			var itemRequest = new ItemRequest
			{
				Item = new Item
				{
					Id = 666
				}
			};

			var result = itemRequest.Equals(null);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ItemRequest_Equals_OtherNullItem()
		{
			var itemRequest = new ItemRequest
			{
			};

			var result = itemRequest.Equals(new ItemRequest { });

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ItemRequest_Equals_ItemNull()
		{
			var itemRequest = new ItemRequest
			{
			};

			var result = itemRequest.Equals(new ItemRequest { Item = new Item() });

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ItemRequest_Equals_IdsNull()
		{
			var itemRequest = new ItemRequest
			{
				Item = new Item()
			};

			var result = itemRequest.Equals(new ItemRequest { Item = new Item() });

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ItemRequest_Equals_SameObject()
		{
			var itemRequest = new ItemRequest
			{
				Item = new Item
				{
					Id = 666
				}
			};

			var result = itemRequest.Equals(itemRequest);

			Assert.IsTrue(result);
		}
	}
}
