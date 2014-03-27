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
	public class WorkflowsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IWorkflows workflowsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			workflowsProxy = new AxosoftAPI.NET.Workflows(client.Object);
			workflowsProxy = new AxosoftAPI.NET.Workflows(request.Object);
		}

		[TestMethod]
		public void Workflows_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Workflow>>>("workflows", null)).Returns(new Response<IEnumerable<Workflow>>
			{
				Data = new List<Workflow>
				{
					new Workflow
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = workflowsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Workflows_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Workflow>>>("workflows", null)).Throws(new Exception());

			// Test Get method
			var result = workflowsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Workflows_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Workflow>>("workflows/666", null)).Returns(new Response<Workflow>
			{
				Data = new Workflow
				{
					Id = 666
				}
			});

			// Test Get method
			var result = workflowsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Workflows_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Workflow>>("workflows/666", parameters)).Returns(new Response<Workflow>
			{
				Data = new Workflow
				{
					Id = 666
				}
			});

			// Test Get method
			var result = workflowsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Workflows_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Workflow>>("workflows/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = workflowsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}
	}
}
