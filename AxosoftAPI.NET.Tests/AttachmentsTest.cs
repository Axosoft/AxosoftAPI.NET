using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AxosoftAPI.NET;
using AxosoftAPI.NET.Models;
using System.Collections.Generic;
using System.Linq;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Core;
using System.IO;

namespace AxosoftAPI.NET.Tests
{
	[TestClass]
	public class AttachmentsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IAttachments attachmentsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance (test constructors)
			attachmentsProxy = new AxosoftAPI.NET.Attachments(client.Object);
			attachmentsProxy = new AxosoftAPI.NET.Attachments(request.Object);
		}

		[TestMethod]
		public void Attachments_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Attachment>>("attachments/666", null)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 666
				}
			});

			// Test Get method
			var result = attachmentsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Attachments_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Attachment>>("attachments/666", parameters)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 666
				}
			});

			// Test Get method
			var result = attachmentsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Attachments_GetData()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Stream>("attachments/666/data", null)).Returns(new MemoryStream());

			// Test Get method
			var result = attachmentsProxy.GetData(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsNotNull(result.Data);
		}

		[TestMethod]
		public void Attachments_GetData_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Stream>("attachments/666/data", null)).Throws(new Exception());

			// Test Get method
			var result = attachmentsProxy.GetData(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Attachments_Update()
		{
			var anAttachment = new Attachment
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("attachments/1234", anAttachment, null)).Returns(new Response<Attachment>
			{
				Data = anAttachment
			});

			// Test Get method
			var result = attachmentsProxy.Update(anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Attachments_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("attachments", 1234, null)).Returns(true);

			// Test Get method
			var result = attachmentsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}
	}
}
