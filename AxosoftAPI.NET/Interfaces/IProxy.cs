﻿using System;

namespace AxosoftAPI.NET.Interfaces
{
	public interface IProxy
	{
		string Url { get; set; }

		VersionEnum Version { get; }

		string ClientId { get; set; }

		string ClientSecret { get; set; }

		string AccessToken { get; set; }

		bool HasAccessToken { get; }
	}
}
