using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class AuthResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
	}
}
