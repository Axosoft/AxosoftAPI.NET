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
	public class MeTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IMe meProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			meProxy = new AxosoftAPI.NET.Me(client.Object);
			meProxy = new AxosoftAPI.NET.Me(request.Object);
		}

		[TestMethod]
		public void Me_Get()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<User>>("me", null)).Returns(new Response<User>
			{
				Data = new User
				{
					Id = 666
				}
			});

			// Test Get method
			var result = meProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Me_Get_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<User>>("me", null)).Throws(new Exception());

			// Test Get method
			var result = meProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}
	}
}
