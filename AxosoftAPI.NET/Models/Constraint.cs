using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Constraint
	{
		[JsonProperty("operator")]
		public string Operator { get; set; }

		[JsonProperty("value")]
		public object Value { get; set; }

		[JsonProperty("field_name")]
		public string FieldName { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
