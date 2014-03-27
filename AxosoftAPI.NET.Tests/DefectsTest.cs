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
	public class DefectsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IDefects defectsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			defectsProxy = new AxosoftAPI.NET.Defects(client.Object);
			defectsProxy = new AxosoftAPI.NET.Defects(request.Object);
		}

		[TestMethod]
		public void Defects_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = defectsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("defects/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
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
			var result = defectsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("defects/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_GetEmails()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("defects/666/emails", null)).Returns(new Response<IEnumerable<Email>>
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
			var result = defectsProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_GetEmails_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("defects/666/emails", null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Item>>("defects/666", null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = defectsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Defects_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("defects/666", parameters)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = defectsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Defects_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("defects/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_Get_ById_Filters_NoParameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", paramFilter7)).Returns(new Response<IEnumerable<Item>>
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", paramFilter9)).Returns(new Response<IEnumerable<Item>>
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
			var result = defectsProxy.Get(filters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_Get_ById_EmptyFilters_NoParameters()
		{
			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = defectsProxy.Get(null);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_Get_ById_Filters_Parameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", parameters)).Returns(new Response<IEnumerable<Item>>
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
			var result = defectsProxy.Get(filters, parametersNoFilter);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Defects_Get_ById_Filters_Exception()
		{
			var paramFilter7 = new Dictionary<string, object>
			{
				{ "filter_id", 7 }
			};

			var filters = new List<int> { 7 };

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("defects", paramFilter7)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Get(filters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_Create()
		{
			var aDefect = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("defects", new ItemRequest { Item = aDefect }, null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = defectsProxy.Create(aDefect);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Defects_Create_Exception()
		{
			var aDefect = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("defects", new ItemRequest { Item = aDefect }, null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Create(aDefect);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_AddAttachment()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("defects/666/attachments", anAttachment, null)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = defectsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Defects_AddAttachment_Exception()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("defects/666/attachments", anAttachment, null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_AddNotification()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("defects/666/notifications", anNotification, null)).Returns(new Response<Notification>
			{
				Data = new Notification
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = defectsProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Defects_AddNotification_Exception()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("defects/666/notifications", anNotification, null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_Update()
		{
			var aDefect = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("defects/1234", new ItemRequest { Item = aDefect }, null)).Returns(new Response<Item>
			{
				Data = aDefect
			});

			// Test Get method
			var result = defectsProxy.Update(aDefect);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Defects_Update_Exception()
		{
			var aDefect = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("defects/1234", new ItemRequest { Item = aDefect }, null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Update(aDefect);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Defects_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("defects", 1234, null)).Returns(true);

			// Test Get method
			var result = defectsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Defects_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("defects", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = defectsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
