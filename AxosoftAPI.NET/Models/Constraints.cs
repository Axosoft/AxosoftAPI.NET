using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Constraints
	{
		[JsonProperty("constraints")]
		public IEnumerable<Constraint> ConstraintsList { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
