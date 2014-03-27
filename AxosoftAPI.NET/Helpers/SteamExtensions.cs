using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AxosoftAPI.NET.Helpers
{
	public static class SteamExtensions
	{
		public static T DeserializeToJson<T>(this Stream stream)
		{
			var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
			
			string content = reader.ReadToEnd();
			stream.Close();

			return JsonConvert.DeserializeObject<T>(content);
		}
	}
}
