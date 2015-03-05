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

        [JsonProperty("has_attachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("is_auto_reply")]
        public bool IsAutoReply { get; set; }

        [JsonProperty("is_incoming_message")]
        public bool IsIncomingMessage { get; set; }

        [JsonProperty("is_message_read")]
        public bool IsMessageRead { get; set; }

        [JsonProperty("mail_account_id")]
        public int MailAccountId { get; set; }

        [JsonProperty("sent_date")]
        public System.DateTime? SentDate { get; set; }
	}
}
