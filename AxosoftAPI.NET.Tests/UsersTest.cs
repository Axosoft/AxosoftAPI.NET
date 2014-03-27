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
	public class UsersTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IUsers usersProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			usersProxy = new AxosoftAPI.NET.Users(client.Object);
			usersProxy = new AxosoftAPI.NET.Users(request.Object);
		}

		[TestMethod]
		public void Users_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<User>>>("users", null)).Returns(new Response<IEnumerable<User>>
			{
				Data = new List<User>
				{
					new User
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = usersProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Users_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<User>>>("users", null)).Throws(new Exception());

			// Test Get method
			var result = usersProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Users_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<User>>("users/666", null)).Returns(new Response<User>
			{
				Data = new User
				{
					Id = 666
				}
			});

			// Test Get method
			var result = usersProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Users_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<User>>("users/666", parameters)).Returns(new Response<User>
			{
				Data = new User
				{
					Id = 666
				}
			});

			// Test Get method
			var result = usersProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Users_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<User>>("users/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = usersProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Users_Create()
		{
			var aProject = new User
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<User>>("users", aProject, null)).Returns(new Response<User>
			{
				Data = new User
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = usersProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Users_Create_Exception()
		{
			var aProject = new User
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<User>>("users", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = usersProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Users_Update()
		{
			var aProject = new User
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<User>>("users/1234", aProject, null)).Returns(new Response<User>
			{
				Data = aProject
			});

			// Test Get method
			var result = usersProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Users_Update_Exception()
		{
			var aProject = new User
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<User>>("users/1234", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = usersProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Users_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("users", 1234, null)).Returns(true);

			// Test Get method
			var result = usersProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Users_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("users", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = usersProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
