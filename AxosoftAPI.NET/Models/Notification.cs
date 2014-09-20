using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Notification : BaseModel
	{
		[JsonProperty("user_ids")]
		public IEnumerable<int> UserIds { get; set; }

		[JsonProperty("customer_contact_ids")]
		public IEnumerable<int> CustomerContactIds { get; set; }

		[JsonProperty("custom_emails")]
		public IEnumerable<string> CustomEmails { get; set; }
	}
}
