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
	public class PicklistsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IPicklists picklistProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			picklistProxy = new AxosoftAPI.NET.Picklists(client.Object);
			picklistProxy = new AxosoftAPI.NET.Picklists(request.Object);
		}

		[TestMethod]
		public void Picklists_Get_ByType()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<PicklistItem>>>("picklists/time_units", null)).Returns(new Response<IEnumerable<PicklistItem>>
			{
				Data = new List<PicklistItem>
				{
					new PicklistItem
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = picklistProxy.Get("time_units");

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Picklists_Get_ByType_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<PicklistItem>>>("picklists/time_units", null)).Throws(new Exception());

			// Test Get method
			var result = picklistProxy.Get("time_units");

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Picklists_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<PicklistItem>>("picklists/escalation/666", null)).Returns(new Response<PicklistItem>
			{
				Data = new PicklistItem
				{
					Id = 666
				}
			});

			// Test Get method
			var result = picklistProxy.Get("escalation", 666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Picklists_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<PicklistItem>>("picklists/escalation/666", parameters)).Returns(new Response<PicklistItem>
			{
				Data = new PicklistItem
				{
					Id = 666
				}
			});

			// Test Get method
			var result = picklistProxy.Get("escalation", 666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Picklists_Get_ById_NoParameters_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<PicklistItem>>("picklists/escalation/666", null)).Throws(new Exception());

			// Test Get method
			var result = picklistProxy.Get("escalation", 666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Picklists_Priority_Create()
		{
			var aPriority = new Priority
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Priority>>("picklists/priority", aPriority, null)).Returns(new Response<Priority>
			{
				Data = new Priority
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = picklistProxy.Priority.Create(aPriority);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Picklists_Priority_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("picklists/priority", 1234, null)).Returns(true);

			// Test Get method
			var result = picklistProxy.Priority.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Picklists_Severity_Create()
		{
			var aPriority = new Severity
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Severity>>("picklists/severity", aPriority, null)).Returns(new Response<Severity>
			{
				Data = new Severity
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = picklistProxy.Severity.Create(aPriority);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Picklists_Severity_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("picklists/severity", 1234, null)).Returns(true);

			// Test Get method
			var result = picklistProxy.Severity.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Picklists_Status_Create()
		{
			var aPriority = new Status
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Status>>("picklists/status", aPriority, null)).Returns(new Response<Status>
			{
				Data = new Status
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = picklistProxy.Status.Create(aPriority);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Picklists_Status_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("picklists/status", 1234, null)).Returns(true);

			// Test Get method
			var result = picklistProxy.Status.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
