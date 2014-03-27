using System.Collections.Generic;
using AxosoftAPI.NET.Core.Interfaces;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IProjects : IResource<Project>
	{
		Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null);

		Result<IEnumerable<Workflow>> GetWorkflows(int id, IDictionary<string, object> parameters = null);

		Result<Attachment> AddAttachment(int id, object data, IDictionary<string, object> parameters = null);
	}
}
