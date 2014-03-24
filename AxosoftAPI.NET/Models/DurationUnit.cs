using Newtonsoft.Json;
using AxosoftAPI.NET.Helpers;

namespace AxosoftAPI.NET.Models
{
	public class DurationUnit : BaseModel
	{
		[JsonProperty("abbreviation")]
		public string Abbreviation { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("duration_minutes")]
		public double? DurationMinutes { get; set; }

		[JsonProperty("duration_text")]
		public string DurationText { get; set; }

		[JsonProperty("type")]
		public TimeUnit Type { get; set; }

		[JsonProperty("time_unit")]
		public TimeUnit TimeUnit { get; set; }

		[JsonProperty("aggregate_duration_minutes")]
		public decimal? AggregateDurationMinutes { get; set; }

		[JsonProperty("value")]
		public decimal? Value { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }
	}
}
