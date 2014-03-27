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
	public class ReleasesTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IReleases releasesProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			releasesProxy = new AxosoftAPI.NET.Releases(client.Object);
			releasesProxy = new AxosoftAPI.NET.Releases(request.Object);
		}

		[TestMethod]
		public void Release_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Release>>>("releases", null)).Returns(new Response<IEnumerable<Release>>
			{
				Data = new List<Release>
				{
					new Release
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = releasesProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Release_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Release>>>("releases", null)).Throws(new Exception());

			// Test Get method
			var result = releasesProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Release_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Release>>("releases/666", null)).Returns(new Response<Release>
			{
				Data = new Release
				{
					Id = 666
				}
			});

			// Test Get method
			var result = releasesProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Release_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Release>>("releases/666", parameters)).Returns(new Response<Release>
			{
				Data = new Release
				{
					Id = 666
				}
			});

			// Test Get method
			var result = releasesProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Release_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Release>>("releases/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = releasesProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Release_Create()
		{
			var aProject = new Release
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Release>>("releases", aProject, null)).Returns(new Response<Release>
			{
				Data = new Release
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = releasesProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Release_Create_Exception()
		{
			var aProject = new Release
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Release>>("releases", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = releasesProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Release_Update()
		{
			var aProject = new Release
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Release>>("releases/1234", aProject, null)).Returns(new Response<Release>
			{
				Data = aProject
			});

			// Test Get method
			var result = releasesProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Release_Update_Exception()
		{
			var aProject = new Release
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Release>>("releases/1234", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = releasesProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Release_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("releases", 1234, null)).Returns(true);

			// Test Get method
			var result = releasesProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Release_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("releases", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = releasesProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
