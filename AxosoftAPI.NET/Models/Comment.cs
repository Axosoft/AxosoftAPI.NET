using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Comment : BaseModel
	{
		[JsonProperty("detail_type")]
		public string DetailType { get; set; }

		[JsonProperty("can_delete")]
		public bool CanDelete { get; set; }

		[JsonProperty("comment_item_type")]
		public string CommentItemType { get; set; }

		[JsonProperty("comment_item_id")]
		public string CommentItemId { get; set; }

		[JsonProperty("comment_text")]
		public string CommentText { get; set; }

		[JsonProperty("comment_type")]
		public string CommentType { get; set; }

		[JsonProperty("created_by_name")]
		public string CreatedByName { get; set; }

		[JsonProperty("field_id")]
		public int FieldId { get; set; }
	}
}
