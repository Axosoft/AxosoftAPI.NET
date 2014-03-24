using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public string ErrorMessage { get; set; }
	}
}
