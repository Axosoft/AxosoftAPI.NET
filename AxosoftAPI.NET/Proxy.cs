using System.Collections.Generic;
using System.Net;
using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Helpers;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Proxy : IProxy
	{
		#region Private Properties

		private string url;

		private BaseRequest baseRequest;

		#endregion

		#region Public Properties

		public string Url
		{
			get
			{
				return url;
			}

			set
			{
				if (value != null && value.EndsWith("/"))
				{
					value = value.Remove(value.Length - 1, 1);
				}

				url = value;
			}
		}

		public VersionEnum Version { get; private set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string AccessToken { get; set; }

		public bool HasAccessToken
		{
			get
			{
				return !string.IsNullOrWhiteSpace(AccessToken);
			}
		}

		#endregion

		#region Public Web Request Properties

		public IAttachments Attachments { get; set; }

		public IContacts Contacts { get; set; }

		public ICustomers Customers { get; set; }

		public IEmails Emails { get; set; }

		public ICustomFields CustomFields { get; set; }

		public IFilters Filters { get; set; }

		public IDefects Defects { get; set; }

		public IFeatures Features { get; set; }

		public ITasks Tasks { get; set; }

		public IIncidents Incidents { get; set; }

		public IItemRelations ItemRelations { get; set; }

		public IMe Me { get; set; }

		public IPicklists Picklists { get; set; }

		public IProjects Projects { get; set; }

		public IReleases Releases { get; set; }

		public ISecurityRoles SecurityRoles { get; set; }

		public ITeams Teams { get; set; }

		public IUsers Users { get; set; }

		public IWorkLogs WorkLogs { get; set; }

		public IWorkflowSteps WorkflowSteps { get; set; }

		public IWorkflows Workflows { get; set; }

		#endregion

		#region Constructors

		public Proxy()
		{
			// Set base request
			baseRequest = new BaseRequest(this);

			// API Version 4
			Version = VersionEnum.Version4;

			// Initiate all Axosoft API proxy properties
			Attachments = new Attachments(this);
			Contacts = new Contacts(this);
			Customers = new Customers(this);
			Emails = new Emails(this);
			CustomFields = new CustomFields(this);
			Filters = new Filters(this);
			Defects = new Defects(this);
			Features = new Features(this);
			Tasks = new Tasks(this);
			Incidents = new Incidents(this);
			ItemRelations = new ItemRelations(this);
			Me = new Me(this);
			Picklists = new Picklists(this);
			Projects = new Projects(this);
			Releases = new Releases(this);
			SecurityRoles = new SecurityRoles(this);
			Teams = new Teams(this);
			Users = new Users(this);
			WorkLogs = new WorkLogs(this);
			WorkflowSteps = new WorkflowSteps(this);
			Workflows = new Workflows(this);
		}

		#endregion

		#region Private Methods

		private string ObtainAccessToken(IDictionary<string, object> parameters)
		{
			// Append parameters & id/secret keys
			var tokenParam = new Dictionary<string, object>()
								.Append(parameters)
								.Append(new Dictionary<string, object>
								{
									{ "client_id", ClientId },
									{ "client_secret", ClientSecret }
								});

			try
			{
				// Get token
				var authResponse = baseRequest.Get<AuthResponse>("oauth2/token", tokenParam);

				// Store and return access token
				return (AccessToken = authResponse.AccessToken);
			}
			catch
			{
				//TODO: what do we do with the exception?

				return null;
			}
		}

		#endregion

		#region Public Methods

		public string ObtainAccessTokenFromAuthorizationCode(string code, string redirectUri, ScopeEnum scope)
		{
			// Make request based on token
			return ObtainAccessToken(new Dictionary<string, object>
			{
				{ "grant_type", "authorization_code" },
				{ "code", code },
				{ "redirect_uri", redirectUri },
				{ "scope", scope.GetDescription() }
			});
		}

		public string ObtainAccessTokenFromUsernamePassword(string username, string password, ScopeEnum scope)
		{
			// Make request based on username/password
			return ObtainAccessToken(new Dictionary<string, object>
			{
				{ "grant_type", "password" },
				{ "username", username },
				{ "password", password },
				{ "scope", scope.GetDescription() }
			});
		}

		#endregion

		#region Generic API calls

		public HttpWebRequest BuildRequest(string resource, IDictionary<string, object> parameters = null)
		{
			return baseRequest.BuildRequest(resource, parameters);
		}

		public T Get<T>(string resource, IDictionary<string, object> parameters = null)
		{
			return baseRequest.Get<T>(resource, parameters);
		}

		public T Post<T>(string resource, object content, IDictionary<string, object> parameters = null)
		{
			return baseRequest.Post<T>(resource, content, parameters);
		}

		public bool Delete(string resource, int id, IDictionary<string, object> parameters = null)
		{
			return (baseRequest.Delete(resource, id, parameters) != null);
		}

		#endregion
	}
}
