using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class ContextResources
	{
		[JsonProperty("projects")]
		public Resources Projects { get; set; }

		[JsonProperty("releases")]
		public Resources Releases { get; set; }

		[JsonProperty("users")]
		public Resources Users { get; set; }
	}
}
