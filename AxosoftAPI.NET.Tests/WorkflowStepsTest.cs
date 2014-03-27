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
	public class WorkflowStepsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IWorkflowSteps workflowStepsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			workflowStepsProxy = new AxosoftAPI.NET.WorkflowSteps(client.Object);
			workflowStepsProxy = new AxosoftAPI.NET.WorkflowSteps(request.Object);
		}

		[TestMethod]
		public void Workflows_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<WorkflowStep>>("workflow_steps/666", null)).Returns(new Response<WorkflowStep>
			{
				Data = new WorkflowStep
				{
					Id = 666
				}
			});

			// Test Get method
			var result = workflowStepsProxy.Get(666);

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
			request.Setup(m => m.Get<Response<WorkflowStep>>("workflow_steps/666", parameters)).Returns(new Response<WorkflowStep>
			{
				Data = new WorkflowStep
				{
					Id = 666
				}
			});

			// Test Get method
			var result = workflowStepsProxy.Get(666, parameters);

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
			request.Setup(m => m.Get<Response<WorkflowStep>>("workflow_steps/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = workflowStepsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}
	}
}
