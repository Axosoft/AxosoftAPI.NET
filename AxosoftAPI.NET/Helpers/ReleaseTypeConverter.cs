using System;
using AxosoftAPI.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxosoftAPI.NET.Helpers
{
	public class ReleaseTypeConverter : JsonConverter
	{
		public override bool CanWrite
		{
			get
			{
				// This forces Json.NET to use the default Json serializer
				return false;
			}
		}

		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(ReleaseType) ||
					objectType == typeof(int));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			var token = JToken.Load(reader);

			// If of type ReleaseType, then return object
			if (token.Type == JTokenType.Object)
			{
				return token.ToObject<ReleaseType>();
			}
			// If of type integer then create new ReleaseType and assign to Id
			else if (token.Type == JTokenType.Integer)
			{
				return new ReleaseType
				{
					Id = token.ToObject<int>(),
				};
			}

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// No implementation needed since CanWrite is hardcoded to return 'false'
			throw new NotImplementedException();
		}
	}
}
