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
	public class ContactsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IContacts contactsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			contactsProxy = new AxosoftAPI.NET.Contacts(client.Object);
			contactsProxy = new AxosoftAPI.NET.Contacts(request.Object);
		}

		[TestMethod]
		public void Contacts_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Contact>>>("contacts", null)).Returns(new Response<IEnumerable<Contact>>
			{
				Data = new List<Contact>
				{
					new Contact
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = contactsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Contacts_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Contact>>("contacts/666", null)).Returns(new Response<Contact>
			{
				Data = new Contact
				{
					Id = 666
				}
			});

			// Test Get method
			var result = contactsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Contacts_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Contact>>("contacts/666", parameters)).Returns(new Response<Contact>
			{
				Data = new Contact
				{
					Id = 666
				}
			});

			// Test Get method
			var result = contactsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Contacts_GetInit()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<Contact>>("contacts/init", null)).Returns(new Response<Contact>
			{
				Data = new Contact
				{
					Id = 999
				}
			});

			// Test Get method
			var result = contactsProxy.GetInit();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.Id);
		}

		[TestMethod]
		public void Contacts_GetInit_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<Contact>>("contacts/init", null)).Throws(new Exception());

			// Test Get method
			var result = contactsProxy.GetInit();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Contacts_Create()
		{
			var aContact = new Contact
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Contact>>("contacts", aContact, null)).Returns(new Response<Contact>
			{
				Data = new Contact
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = contactsProxy.Create(aContact);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Contacts_Update()
		{
			var aContact = new Contact
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Contact>>("contacts/1234", aContact, null)).Returns(new Response<Contact>
			{
				Data = aContact
			});

			// Test Get method
			var result = contactsProxy.Update(aContact);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Contacts_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("contacts", 1234, null)).Returns(true);

			// Test Get method
			var result = contactsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
