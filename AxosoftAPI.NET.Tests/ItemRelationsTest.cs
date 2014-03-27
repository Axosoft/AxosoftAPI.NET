using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AxosoftAPI.NET;
using AxosoftAPI.NET.Models;
using System.Collections.Generic;
using System.Linq;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Core;

namespace AxosoftAPI.NET.Tests
{
	[TestClass]
	public class ItemRelationsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IItemRelations itemRelationsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			itemRelationsProxy = new AxosoftAPI.NET.ItemRelations(client.Object);
			itemRelationsProxy = new AxosoftAPI.NET.ItemRelations(request.Object);
		}

		[TestMethod]
		public void ItemRelations_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<ItemRelation>>("item_relations/666", null)).Returns(new Response<ItemRelation>
			{
				Data = new ItemRelation
				{
					Id = 666
				}
			});

			// Test Get method
			var result = itemRelationsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void ItemRelations_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<ItemRelation>>("item_relations/666", parameters)).Returns(new Response<ItemRelation>
			{
				Data = new ItemRelation
				{
					Id = 666
				}
			});

			// Test Get method
			var result = itemRelationsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void ItemRelations_Create()
		{
			var anItemRelation = new ItemRelation
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<ItemRelation>>("item_relations", anItemRelation, null)).Returns(new Response<ItemRelation>
			{
				Data = new ItemRelation
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = itemRelationsProxy.Create(anItemRelation);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void ItemRelations_Update()
		{
			var anItemRelation = new ItemRelation
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<ItemRelation>>("item_relations/1234", anItemRelation, null)).Returns(new Response<ItemRelation>
			{
				Data = new ItemRelation
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = itemRelationsProxy.Update(anItemRelation);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void ItemRelations_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("item_relations", 1234, null)).Returns(true);

			// Test Get method
			var result = itemRelationsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
