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
	public class ProjectsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IProjects projectsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			projectsProxy = new AxosoftAPI.NET.Projects(client.Object);
			projectsProxy = new AxosoftAPI.NET.Projects(request.Object);
		}

		[TestMethod]
		public void Projects_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Project>>>("projects", null)).Returns(new Response<IEnumerable<Project>>
			{
				Data = new List<Project>
				{
					new Project
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = projectsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Projects_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Project>>>("projects", null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("projects/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
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
			var result = projectsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Projects_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("projects/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_GetWorkflows()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Workflow>>>("projects/666/workflow", null)).Returns(new Response<IEnumerable<Workflow>>
			{
				Data = new List<Workflow>
				{
					new Workflow
					{
						Id = 999
					}
				}
			});

			// Test Get method
			var result = projectsProxy.GetWorkflows(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Projects_GetWorkflows_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Workflow>>>("projects/666/workflow", null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.GetWorkflows(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Project>>("projects/666", null)).Returns(new Response<Project>
			{
				Data = new Project
				{
					Id = 666
				}
			});

			// Test Get method
			var result = projectsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Projects_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Project>>("projects/666", parameters)).Returns(new Response<Project>
			{
				Data = new Project
				{
					Id = 666
				}
			});

			// Test Get method
			var result = projectsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Projects_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Project>>("projects/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_Create()
		{
			var aProject = new Project
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Project>>("projects", aProject, null)).Returns(new Response<Project>
			{
				Data = new Project
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = projectsProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Projects_Create_Exception()
		{
			var aProject = new Project
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Project>>("projects", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.Create(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_AddAttachment()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("projects/666/attachments", anAttachment, null)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = projectsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Projects_AddAttachment_Exception()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("projects/666/attachments", anAttachment, null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_Update()
		{
			var aProject = new Project
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Project>>("projects/1234", aProject, null)).Returns(new Response<Project>
			{
				Data = aProject
			});

			// Test Get method
			var result = projectsProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Projects_Update_Exception()
		{
			var aProject = new Project
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Project>>("projects/1234", aProject, null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.Update(aProject);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Projects_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("projects", 1234, null)).Returns(true);

			// Test Get method
			var result = projectsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Projects_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("projects", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = projectsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
