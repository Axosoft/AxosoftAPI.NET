using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AxosoftAPI.NET.Models;

namespace AxosoftAPI.NET.Helpers
{
	[Serializable]
	public class OnTimeException<T> : Exception where T : ErrorResponse
	{
		public OnTimeException(T response, WebException innerException = null)
			: base(GetMessage(response, innerException), innerException)
		{
			// Do nothing else
		}

		// Goes through the error response and inner exception, trying to find a message to use for this exception
		private static string GetMessage(T response, WebException innerException)
		{
			// list of candidates for the message
			var possibleMessages = new List<string>();

			// add candidates from the error response
			if (response != null)
			{
				possibleMessages.Add(response.Message);
				possibleMessages.Add(response.ErrorDescription);
				possibleMessages.Add(response.Error);
			}

			// add candidates from the inner exception
			if (innerException != null)
			{
				possibleMessages.Add(innerException.Message);
			}

			// return the first candidate that's not empty
			return possibleMessages.FirstOrDefault(message => !string.IsNullOrWhiteSpace(message));
		}
	}
}
