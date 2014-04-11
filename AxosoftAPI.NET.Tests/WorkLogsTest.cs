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
	public class WorkLogsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IWorkLogs workLogsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			workLogsProxy = new AxosoftAPI.NET.WorkLogs(client.Object);
			workLogsProxy = new AxosoftAPI.NET.WorkLogs(request.Object);
		}

		[TestMethod]
		public void WorkLogs_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<WorkLog>>>("work_logs", null)).Returns(new Response<IEnumerable<WorkLog>>
			{
				Data = new List<WorkLog>
				{
					new WorkLog
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = workLogsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void WorkLogs_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<WorkLog>>>("work_logs", null)).Throws(new Exception());

			// Test Get method
			var result = workLogsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void WorkLogs_Create()
		{
			var aWorklog = new WorkLog
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<WorkLog>>("work_logs", aWorklog, null)).Returns(new Response<WorkLog>
			{
				Data = new WorkLog
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = workLogsProxy.Create(aWorklog);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void WorkLogs_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("work_logs", 1234, null)).Returns(true);

			// Test Get method
			var result = workLogsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void WorkLogs_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("work_logs", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = workLogsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
