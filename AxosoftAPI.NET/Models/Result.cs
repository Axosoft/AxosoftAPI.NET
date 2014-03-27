using System;

namespace AxosoftAPI.NET.Models
{
	public class Result<T>
	{
		public Result()
		{
			IsSuccessful = true;
			ErrorMessage = string.Empty;
		}

		public T Data { get; set; }

		/// <summary>
		/// True if web request was successfull; false otherwise.
		/// </summary>
		public bool IsSuccessful { get; set; }

		/// <summary>
		/// Error message if an error occurred.
		/// </summary>
		public string ErrorMessage { get; set; }
	}
}
