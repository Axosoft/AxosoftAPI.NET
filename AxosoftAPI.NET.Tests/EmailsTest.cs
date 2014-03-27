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
	public class EmailsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IEmails emailsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			emailsProxy = new AxosoftAPI.NET.Emails(client.Object);
			emailsProxy = new AxosoftAPI.NET.Emails(request.Object);
		}

		[TestMethod]
		public void Emails_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Email>>("emails/666", null)).Returns(new Response<Email>
			{
				Data = new Email
				{
					Id = 666
				}
			});

			// Test Get method
			var result = emailsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Emails_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Email>>("emails/666", parameters)).Returns(new Response<Email>
			{
				Data = new Email
				{
					Id = 666
				}
			});

			// Test Get method
			var result = emailsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Emails_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("emails/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
			{
				Data = new List<Attachment>
				{
					new Attachment
					{
						Id = 999
					}
				}
			});

			// Test Get method
			var result = emailsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Emails_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("emails/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = emailsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Emails_Create()
		{
			var aEmail = new Email
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Email>>("emails", aEmail, null)).Returns(new Response<Email>
			{
				Data = new Email
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = emailsProxy.Create(aEmail);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Emails_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("emails", 1234, null)).Returns(true);

			// Test Get method
			var result = emailsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
