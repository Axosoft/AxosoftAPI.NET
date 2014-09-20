using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Team : BaseModel
	{
		[JsonProperty("path")]
		public string Path { get; set; }

		[JsonProperty("parent")]
		public Team Parent { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("users")]
		public IEnumerable<User> Users { get; set; }
	}
}
