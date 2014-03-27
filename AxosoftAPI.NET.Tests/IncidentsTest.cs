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
	public class IncidentsTest
	{
		private Mock<IProxy> client;
		private Mock<BaseRequest> request;
		private IIncidents incidentsProxy;

		[TestInitialize]
		public void Setup()
		{
			client = new Mock<IProxy>();

			request = new Mock<BaseRequest>(new Mock<IProxy>().Object);
			request.CallBase = true;

			// Create proxy instance
			incidentsProxy = new AxosoftAPI.NET.Incidents(client.Object);
			incidentsProxy = new AxosoftAPI.NET.Incidents(request.Object);
		}

		[TestMethod]
		public void Incidents_Get_All()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = incidentsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_Get_All_Exception()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.Get();

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_GetAttachments()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("incidents/666/attachments", null)).Returns(new Response<IEnumerable<Attachment>>
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
			var result = incidentsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_GetAttachments_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Attachment>>>("incidents/666/attachments", null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.GetAttachments(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_GetEmails()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("incidents/666/emails", null)).Returns(new Response<IEnumerable<Email>>
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
			var result = incidentsProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(999, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_GetEmails_Exception()
		{
			// Set test GetData method w/o parameters
			request.Setup(m => m.Get<Response<IEnumerable<Email>>>("incidents/666/emails", null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.GetEmails(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_Get_ById_NoParameters()
		{
			// Set test Get method w/o parameters
			request.Setup(m => m.Get<Response<Item>>("incidents/666", null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = incidentsProxy.Get(666);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_Get_ById_Parameters()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("incidents/666", parameters)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 666
				}
			});

			// Test Get method
			var result = incidentsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_Get_ById_Exception()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "test", null }
			};

			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<Item>>("incidents/666", parameters)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.Get(666, parameters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_Get_ById_Filters_NoParameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", paramFilter7)).Returns(new Response<IEnumerable<Item>>
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", paramFilter9)).Returns(new Response<IEnumerable<Item>>
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
			var result = incidentsProxy.Get(filters);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_Get_ById_EmptyFilters_NoParameters()
		{
			// Set test Get method w/ parameters
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", null)).Returns(new Response<IEnumerable<Item>>
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
			var result = incidentsProxy.Get(null);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_Get_ById_Filters_Parameters()
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
			request.Setup(m => m.Get<Response<IEnumerable<Item>>>("incidents", parameters)).Returns(new Response<IEnumerable<Item>>
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
			var result = incidentsProxy.Get(filters, parametersNoFilter);

			// Verify test
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Data.Count());
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(666, result.Data.ElementAt(0).Id);
		}

		[TestMethod]
		public void Incidents_Create()
		{
			var anIncident = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("incidents", new ItemRequest { Item = anIncident }, null)).Returns(new Response<Item>
			{
				Data = new Item
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = incidentsProxy.Create(anIncident);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_Create_Exception()
		{
			var aFeature = new Item
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("incidents", new ItemRequest { Item = aFeature }, null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.Create(aFeature);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_AddAttachment()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("incidents/666/attachments", anAttachment, null)).Returns(new Response<Attachment>
			{
				Data = new Attachment
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = incidentsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_AddAttachment_Exception()
		{
			var anAttachment = new Attachment
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Attachment>>("incidents/666/attachments", anAttachment, null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.AddAttachment(666, anAttachment);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_AddNotification()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("incidents/666/notifications", anNotification, null)).Returns(new Response<Notification>
			{
				Data = new Notification
				{
					Id = 1234
				}
			});

			// Test Get method
			var result = incidentsProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_AddNotification_Exception()
		{
			var anNotification = new Notification
			{
				Id = 0
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Notification>>("incidents/666/notifications", anNotification, null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.AddNotification(666, anNotification);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_Update()
		{
			var anIncident = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("incidents/1234", new ItemRequest { Item = anIncident }, null)).Returns(new Response<Item>
			{
				Data = anIncident
			});

			// Test Get method
			var result = incidentsProxy.Update(anIncident);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(1234, result.Data.Id);
		}

		[TestMethod]
		public void Incidents_Update_Exception()
		{
			var anIncident = new Item
			{
				Id = 1234
			};

			// Set test Create method w/o parameters
			request.Setup(m => m.Post<Response<Item>>("incidents/1234", new ItemRequest { Item = anIncident }, null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.Update(anIncident);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsNull(result.Data);
		}

		[TestMethod]
		public void Incidents_Delete()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("incidents", 1234, null)).Returns(true);

			// Test Get method
			var result = incidentsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccessful);
			Assert.IsTrue(result.Data);
		}

		[TestMethod]
		public void Incidents_Delete_Exception()
		{
			// Set test Create method w/o parameters
			request.Setup(m => m.Delete("incidents", 1234, null)).Throws(new Exception());

			// Test Get method
			var result = incidentsProxy.Delete(1234);

			// Verify test
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccessful);
			Assert.IsFalse(result.Data);
		}
	}
}
