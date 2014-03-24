using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxosoftAPI.NET.Models
{
	public class Customer : BaseModel
	{
		[JsonProperty("company_name")]
		public string FirstName { get; set; }

		[JsonProperty("company_url")]
		public string LastName { get; set; }

		[JsonProperty("custom_fields")]
		public IDictionary<string, object> CustomFields { get; set; }

		[JsonProperty("contacts")]
		public IEnumerable<Contact> Contacts { get; set; }
	}
}
