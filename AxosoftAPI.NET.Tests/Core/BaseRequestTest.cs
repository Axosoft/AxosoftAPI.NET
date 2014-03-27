using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AxosoftAPI.NET;
using AxosoftAPI.NET.Models;
using System.Collections.Generic;
using System.Linq;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Core;

namespace AxosoftAPI.NET.Tests.Core
{
	[TestClass]
	public class BaseRequestTest
	{
		private Mock<IProxy> client;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();
			client.SetupGet(x => x.Url).Returns("test.test.com");
			client.SetupGet(x => x.ClientId).Returns("123456");
			client.SetupGet(x => x.ClientSecret).Returns("456789");
			client.SetupGet(x => x.Version).Returns(VersionEnum.Version3);
		}

		[TestMethod]
		public void BaseRequest_GetInvalidResponse()
		{
			var request = new BaseRequest(client.Object);
			var exception = new Exception("test");

			var result = request.GetInvalidResponse<BaseModel>(exception);

			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.AreEqual(exception.Message, result.ErrorMessage);
		}

		[TestMethod]
		public void BaseRequest_GetVersionUri()
		{
			var request = new BaseRequest(client.Object);

			var result = request.GetVersionedUri();

			Assert.IsNotNull(result);
			Assert.AreEqual("test.test.com/api/v3", result);
		}

		[TestMethod]
		public void BaseRequest_GetVersionedResourceUri()
		{
			var request = new BaseRequest(client.Object);

			var result = request.GetVersionedResourceUri("test");

			Assert.IsNotNull(result);
			Assert.AreEqual("test.test.com/api/v3/test", result);
		}
	}
}
