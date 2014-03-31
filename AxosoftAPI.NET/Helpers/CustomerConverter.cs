using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxosoftAPI.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxosoftAPI.NET.Helpers
{
	public class CustomerConverter : JsonConverter
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
			return (objectType == typeof(Customer));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			var jObject = JObject.Load(reader);

			// Create "emtpy" object
			var target = new Customer();

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), target);

			// Find any "custom_" fields
			var customFields = ((IEnumerable<KeyValuePair<string, JToken>>)jObject).Where(x =>
				x.Key.ToLower().StartsWith("custom_") &&
				x.Key.ToLower() != "custom_fields");

			// If we got any
			if (customFields != null && customFields.Any())
			{
				// If we need to initiate the custom fields property
				if (target.CustomFields == null)
				{
					target.CustomFields = new Dictionary<string, object>();
				}

				// Add all custom fields
				foreach (var token in customFields)
				{
					target.CustomFields.Add(token.Key, ((JValue)token.Value).Value);
				}
			}

			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// No implementation needed since CanWrite is hardcoded to return 'false'
			throw new NotImplementedException();
		}
	}
}
