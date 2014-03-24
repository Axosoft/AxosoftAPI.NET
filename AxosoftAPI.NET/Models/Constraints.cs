using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
