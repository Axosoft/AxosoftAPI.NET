using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET.Models
{
	public class Contact : BaseModel
	{
		[JsonProperty("customer")]
		public Customer Customer { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("can_login")]
		public bool CanLogin { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("custom_fields")]
		public IDictionary<string, object> CustomFields { get; set; }

		[JsonProperty("security_role")]
		public SecurityRole SecurityRole { get; set; }
	}
}
