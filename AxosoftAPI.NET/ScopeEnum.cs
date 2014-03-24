using System.ComponentModel;

namespace AxosoftAPI.NET
{
	public enum ScopeEnum
	{
		[Description("read")]
		ReadOnly,

		[Description("write")]
		WriteOnly,

		[Description("read write")]
		ReadWrite,
	}
}
