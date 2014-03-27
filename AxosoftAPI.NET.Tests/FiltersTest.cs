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
	public class FiltersTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IFilters filtersProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			filtersProxy = new AxosoftAPI.NET.Filters(client.Object);
			filtersProxy = new AxosoftAPI.NET.Filters(request.Object);
		}

		[TestMethod]
		public void Filterss_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Filter>>>("filters", null)).Returns(new Response<IEnumerable<Filter>>
			{
				Data = new List<Filter>
				{
					new Filter
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = filtersProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}
	}
}
