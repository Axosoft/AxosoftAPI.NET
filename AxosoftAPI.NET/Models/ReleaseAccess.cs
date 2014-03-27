using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class ReleaseAccess
	{
		[JsonProperty("inherits")]
		public bool Inherits { get; set; }

		[JsonProperty("bound")]
		public IEnumerable<Release> BoundReleases { get; set; }
	}
}
