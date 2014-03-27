using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Email : BaseModel
	{
		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("from")]
		public string From { get; set; }

		[JsonProperty("to")]
		public string To { get; set; }

		[JsonProperty("cc")]
		public string CC { get; set; }

		[JsonProperty("bcc")]
		public string BCC { get; set; }

		[JsonProperty("email_type")]
		public string EmailType { get; set; }

		[JsonProperty("item")]
		public Item Item { get; set; }
	}
}
