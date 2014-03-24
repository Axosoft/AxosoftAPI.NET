using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxosoftAPI.NET.Models
{
	public class Column
	{
		[JsonProperty("field_name")]
		public string FieldName { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("group")]
		public string Group { get; set; }

		[JsonProperty("is_groupable")]
		public bool? IsGroupable { get; set; }

		[JsonProperty("is_filterable")]
		public bool? IsFilterable { get; set; }

		[JsonProperty("is_editable")]
		public bool? IsEditable { get; set; }

		[JsonProperty("is_selectable")]
		public bool? IsSelectable { get; set; }

		[JsonProperty("is_multi_editable")]
		public bool? IsMultiEditable { get; set; }

		[JsonProperty("is_sortable")]
		public bool? IsSortable { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("original_label")]
		public string OriginalLabel { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
