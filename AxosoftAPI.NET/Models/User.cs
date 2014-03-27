using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class User : BaseModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("git_hub_user_id")]
		public string GitHubUserId { get; set; }

		[JsonProperty("windows_id")]
		public string WindowsId { get; set; }

		[JsonProperty("use_windows_auth")]
		public bool UseWindowsAuth { get; set; }

		[JsonProperty("login_id")]
		public string LoginId { get; set; }

		[JsonProperty("security_roles")]
		public int[] SecurityRoles { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("is_locked")]
		public bool IsLocked { get; set; }
	}

	public class UserSecurityRole : User
	{
		[JsonProperty("security_roles")]
		public new IEnumerable<SecurityRole> SecurityRoles { get; set; }
	}
}
