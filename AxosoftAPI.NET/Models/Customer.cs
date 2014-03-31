using System.Collections.Generic;
using AxosoftAPI.NET.Helpers;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	[JsonConverter(typeof(CustomerConverter))]
	public class Customer : BaseModel
	{
		[JsonProperty("company_name")]
		public string CompanyName { get; set; }

		[JsonProperty("company_url")]
		public string CompanyUrl { get; set; }

		[JsonProperty("custom_fields")]
		public IDictionary<string, object> CustomFields { get; set; }

		[JsonProperty("contacts")]
		public IEnumerable<Contact> Contacts { get; set; }
	}
}
