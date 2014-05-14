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
	public class TasksTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private ITasks tasksProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			tasksProxy = new AxosoftAPI.NET.Tasks(client.Object);
			tasksProxy = new AxosoftAPI.NET.Tasks(request.Object);
		}

		[TestMethod]
		public void Tasks_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", null)).Returns(new Response<IEnumerable<Item>>
			{
				Data = new List<Item>
				{
					new Item
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = tasksProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("tasks/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
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
			var result = tasksProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("tasks/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_GetEmails()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("tasks/666/emails", null)).Returns(new Response<IEnumerable<Email>>
			{
				Data = new List<Email>
				{
					new Email
					{
						Id = 999
					}
				}
			});

			// Test Get method
			var result = tasksProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_GetEmails_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("tasks/666/emails", null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Item>>("tasks/666", null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = tasksProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("tasks/666", parameters)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = tasksProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_Get_ById_Filters_NoParameters()
		{
			var paramFilter7 = new Dictionary<string, object>
			{
				{ "filter_id", 7 }
			};

			var paramFilter9 = new Dictionary<string, object>
			{
				{ "filter_id", 9 }
			};

			var filters = new List<int> { 7, 9 };

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", paramFilter7)).Returns(new Response<IEnumerable<Item>>
			{
				Data = new List<Item>
				{
					new Item
					{
						Id = 666
					},
					new Item
					{
						Id = 667
					}
				}
			});

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", paramFilter9)).Returns(new Response<IEnumerable<Item>>
			{
				Data = new List<Item>
				{
					new Item
					{
						Id = 666
					},
					new Item
					{
						Id = 669
					}
				}
			});

			// Test Get method
			var result = tasksProxy.Get(filters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_Get_ById_EmptyFilters_NoParameters()
		{
			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", null)).Returns(new Response<IEnumerable<Item>>
			{
				Data = new List<Item>
				{
					new Item
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = tasksProxy.Get(null);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_Get_ById_Filters_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null },
				{ "filter_id", 7 }
			};

			var parametersNoFilter = new Dictionary<string, object>
			{
				{ "test", null },
			};

			var filters = new List<int> { 7 };

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("tasks", parameters)).Returns(new Response<IEnumerable<Item>>
			{
				Data = new List<Item>
				{
					new Item
					{
						Id = 666
					}
				}
			});

			// Test Get method
			var result = tasksProxy.Get(filters, parametersNoFilter);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Tasks_Create()
		{
			var aTask = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("tasks", new ItemRequest { Item = aTask }, null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = tasksProxy.Create(aTask);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_Create_Exception()
		{
			var aFeature = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("tasks", new ItemRequest { Item = aFeature }, null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.Create(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_AddAttachment()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			var parameters = new Dictionary<string, object>
			{
				{ "file_name", anAttachment.FileName },
				{ "description", anAttachment.Description },
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("tasks/666/attachments", anAttachment.Data, parameters)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = tasksProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_AddAttachment_Exception()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("tasks/666/attachments", anAttachment, null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_AddNotification()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("tasks/666/notifications", anNotification, null)).Returns(new Response<Notification>
			{
				Data = new Notification
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = tasksProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_AddNotification_Exception()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("tasks/666/notifications", anNotification, null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_Update()
		{
			var aTask = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("tasks/1234", new ItemRequest { Item = aTask }, null)).Returns(new Response<Item>
			{
				Data = aTask
			});

			// Test Get method
			var result = tasksProxy.Update(aTask);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Tasks_Update_Exception()
		{
			var aTask = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("tasks/1234", new ItemRequest { Item = aTask }, null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.Update(aTask);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Tasks_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("tasks", 1234, null)).Returns(true);

			// Test Get method
			var result = tasksProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Tasks_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("tasks", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = tasksProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
