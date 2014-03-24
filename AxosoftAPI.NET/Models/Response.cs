using Newtonsoft.Json;

namespace AxosoftAPI.NET.Models
{
	public class Response<T>
	{
		[JsonProperty("data")]
		public T Data;

		[JsonProperty("metadata")]
		public Metadata Metadata { get; set; }
	}
}
