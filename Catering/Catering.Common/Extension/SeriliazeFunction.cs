using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Catering.Common.Extension
{
    public static class SeriliazeFunction
    {
		public static JsonSerializerOptions GetJsonSerializerOptions()
		{
			var options = new JsonSerializerOptions()
			{
				IgnoreNullValues = true,
				IgnoreReadOnlyProperties = true,
				WriteIndented = true,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
			};

			options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

			return options;
		}

		public static string SerializeToJson(object obj)
		{
			var options = GetJsonSerializerOptions();
			var serializeObj = JsonSerializer.SerializeToUtf8Bytes(obj, options);
			return Encoding.UTF8.GetString(serializeObj);
		}


		public static T DeserializeFromJson<T>(string jsonObject)
		{
			if (string.IsNullOrWhiteSpace(jsonObject))
				return default;

			var options = GetJsonSerializerOptions();
			var serializeObj = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(jsonObject));
			return JsonSerializer.Deserialize<T>(serializeObj, options);
		}
	}
}
