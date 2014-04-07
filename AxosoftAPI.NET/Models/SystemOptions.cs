using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class SystemOptions
	{
		[JsonProperty("focus_resources")]
		public FocusResources FocusResources { get; set; }

		[JsonProperty("context_resources")]
		public ContextResources ContextResources { get; set; }
	}
}
