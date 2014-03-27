using System.Collections.Generic;
using AxosoftAPI.NET.Core;
using AxosoftAPI.NET.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET
{
	public class Projects : BaseResponseResource<Project>, IProjects
	{
		public Projects(IProxy client) : base("projects", client) { }

		public Projects(BaseRequest request) : base("projects", request) { }

		public Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<Attachment>>(() =>
				request.Get<Response<IEnumerable<Attachment>>>(string.Format("{0}/{1}/attachments", resource, id), parameters));
		}

		public Result<IEnumerable<Workflow>> GetWorkflows(int id, IDictionary<string, object> parameters = null)
		{
			return Request<IEnumerable<Workflow>>(() =>
				request.Get<Response<IEnumerable<Workflow>>>(string.Format("{0}/{1}/workflow", resource, id), parameters));
		}

		public Result<Attachment> AddAttachment(int id, object data, IDictionary<string, object> parameters = null)
		{
			return Request<Attachment>(() =>
				request.Post<Response<Attachment>>(string.Format("{0}/{1}/attachments", resource, id), data, parameters));
		}
	}
}
