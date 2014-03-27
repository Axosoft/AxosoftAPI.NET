using System;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IProxy
	{
		string Url { get; set; }

		VersionEnum Version { get; set; }

		string ClientId { get; set; }

		string ClientSecret { get; set; }

		string AccessToken { get; set; }
	}
}
