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
	public class CustomersTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private ICustomers customersProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			customersProxy = new AxosoftAPI.NET.Customers(client.Object);
			customersProxy = new AxosoftAPI.NET.Customers(request.Object);
		}

		[TestMethod]
		public void Customers_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Customer>>>("customers", null)).Returns(new Response<IEnumerable<Customer>>
			{
				Data = new List<Customer>
				{
					new Customer
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = customersProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Customers_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Customer>>("customers/666", null)).Returns(new Response<Customer>
			{
				Data = new Customer
				{
					Id = 666
				}
			});

			// Test Get method
			var result = customersProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Customers_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Customer>>("customers/666", parameters)).Returns(new Response<Customer>
			{
				Data = new Customer
				{
					Id = 666
				}
			});

			// Test Get method
			var result = customersProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Customers_GetInit()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<Customer>>("customers/init", null)).Returns(new Response<Customer>
			{
				Data = new Customer
				{
					Id = 999
				}
			});

			// Test Get method
			var result = customersProxy.GetInit();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.Id);
		}

		[TestMethod]
		public void Customers_GetInit_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<Customer>>("customers/init", null)).Throws(new Exception());

			// Test Get method
			var result = customersProxy.GetInit();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Customers_Create()
		{
			var aCustomer = new Customer
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Customer>>("customers", aCustomer, null)).Returns(new Response<Customer>
			{
				Data = new Customer
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = customersProxy.Create(aCustomer);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Customers_Update()
		{
			var aCustomer = new Customer
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Customer>>("customers/1234", aCustomer, null)).Returns(new Response<Customer>
			{
				Data = aCustomer
			});

			// Test Get method
			var result = customersProxy.Update(aCustomer);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Customers_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("customers", 1234, null)).Returns(true);

			// Test Get method
			var result = customersProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
