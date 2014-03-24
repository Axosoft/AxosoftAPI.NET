using AxosoftAPI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET
{
	public interface IWorkflows : IGetAllResource<Workflow>, IGetResource<Workflow>
	{
	}
}
