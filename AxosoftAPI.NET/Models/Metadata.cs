using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Metadata
	{
		[JsonProperty("total_count")]
		public int? TotalCount { get; set; }

		[JsonProperty("page")]
		public int? Page { get; set; }

		[JsonProperty("page_size")]
		public int? PageSize { get; set; }

		[JsonProperty("minutes_worked")]
		public decimal? MinutesWorked { get; set; }

		[JsonProperty("minutes_remaining")]
		public decimal? MinutesRemaining { get; set; }

		[JsonProperty("percent_complete")]
		public decimal? PercentComplete { get; set; }

		[JsonProperty("total_pages")]
		public int? TotalPages { get; set; }

		[JsonProperty("total_families")]
		public int? TotalFamilies { get; set; }

		[JsonProperty("total_items")]
		public int? TotalItems { get; set; }

		[JsonProperty("use_voting")]
		public bool? UseVoting { get; set; }

		[JsonProperty("time_units")]
		public IEnumerable<TimeUnit> TimeUnits { get; set; }
	}
}
