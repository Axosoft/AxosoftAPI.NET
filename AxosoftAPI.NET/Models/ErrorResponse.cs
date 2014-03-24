using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class ErrorResponse
	{
		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("error_description")]
		public string ErrorDescription { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
