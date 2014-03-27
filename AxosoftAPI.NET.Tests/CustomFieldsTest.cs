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
	public class CustomFieldsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private ICustomFields customFieldsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			customFieldsProxy = new AxosoftAPI.NET.CustomFields(client.Object);
			customFieldsProxy = new AxosoftAPI.NET.CustomFields(request.Object);
		}

		[TestMethod]
		public void CustomFields_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<CustomField>>>("fields/custom", null)).Returns(new Response<IEnumerable<CustomField>>
			{
				Data = new List<CustomField>
				{
					new CustomField
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = customFieldsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}
	}
}
