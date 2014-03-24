using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class CustomField : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("record_type")]
		public string RecordType { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("string_size")]
		public long? StringSize { get; set; }

		[JsonProperty("order")]
		public long? Order { get; set; }

		[JsonProperty("is_editable")]
		public bool? IsEditable { get; set; }

		[JsonProperty("is_custom")]
		public bool? IsCustom { get; set; }

		[JsonProperty("is_groupable")]
		public bool? IsGroupable { get; set; }

		[JsonProperty("is_searchable")]
		public bool? IsSearchable { get; set; }
	}
}
