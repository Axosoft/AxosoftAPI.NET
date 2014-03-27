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
	public class FeaturesTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IFeatures featuresProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			featuresProxy = new AxosoftAPI.NET.Features(client.Object);
			featuresProxy = new AxosoftAPI.NET.Features(request.Object);
		}

		[TestMethod]
		public void Features_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = featuresProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("features/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
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
			var result = featuresProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("features/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_GetEmails()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("features/666/emails", null)).Returns(new Response<IEnumerable<Email>>
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
			var result = featuresProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_GetEmails_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("features/666/emails", null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Item>>("features/666", null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = featuresProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Features_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("features/666", parameters)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = featuresProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Features_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("features/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_Get_ById_Filters_NoParameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", paramFilter7)).Returns(new Response<IEnumerable<Item>>
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", paramFilter9)).Returns(new Response<IEnumerable<Item>>
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
			var result = featuresProxy.Get(filters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_Get_ById_EmptyFilters_NoParameters()
		{
			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = featuresProxy.Get(null);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_Get_ById_Filters_Parameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("features", parameters)).Returns(new Response<IEnumerable<Item>>
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
			var result = featuresProxy.Get(filters, parametersNoFilter);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1, result.Data.Count());
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Features_Create()
		{
			var aFeature = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("features", new ItemRequest { Item = aFeature }, null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = featuresProxy.Create(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Features_Create_Exception()
		{
			var aFeature = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("features", new ItemRequest { Item = aFeature }, null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.Create(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_AddAttachment()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("features/666/attachments", anAttachment, null)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = featuresProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Features_AddAttachment_Exception()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("features/666/attachments", anAttachment, null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_AddNotification()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("features/666/notifications", anNotification, null)).Returns(new Response<Notification>
			{
				Data = new Notification
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = featuresProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Features_AddNotification_Exception()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("features/666/notifications", anNotification, null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_Update()
		{
			var aFeature = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("features/1234", new ItemRequest { Item = aFeature }, null)).Returns(new Response<Item>
			{
				Data = aFeature
			});

			// Test Get method
			var result = featuresProxy.Update(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Features_Update_Exception()
		{
			var aFeature = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("features/1234", new ItemRequest { Item = aFeature }, null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.Update(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Features_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("features", 1234, null)).Returns(true);

			// Test Get method
			var result = featuresProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Features_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("features", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = featuresProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
