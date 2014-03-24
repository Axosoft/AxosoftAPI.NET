using Newtonsoft.Json;
using System;

namespace AxosoftAPI.NET.Models
{
	public class BaseModel
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("created_date_time")]
		public DateTime? CreatedDateTime { get; set; }

		[JsonProperty("created_by")]
		public User CreatedBy { get; set; }

		[JsonProperty("last_updated_date_time")]
		public DateTime? LastUpdatedDateTime { get; set; }

		[JsonProperty("last_updated_by")]
		public User LastUpdatedBy { get; set; }
	}
}
