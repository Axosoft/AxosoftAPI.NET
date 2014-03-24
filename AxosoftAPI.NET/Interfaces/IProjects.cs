using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public interface IProjects : IResource<Project>
	{
		Result<IEnumerable<Attachment>> GetAttachments(int id, IDictionary<string, object> parameters = null);

		Result<IEnumerable<Workflow>> GetWorkflows(int id, IDictionary<string, object> parameters = null);

		Result<Attachment> AddAttachment(int id, object data, IDictionary<string, object> parameters = null);
	}
}
