using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ActiLifeAPILibrary
{
	public class Converters
	{
		/// <summary>
		/// Converts DateTimes to/from UTC when serializing/deserializing...
		/// </summary>
		public class JSONCustomDateConverter : DateTimeConverterBase
		{
			//http://stackoverflow.com/questions/668488/parsing-json-datetime-from-newtonsofts-json-serializer

			public override bool CanConvert(Type objectType)
			{
				return objectType == typeof(DateTime);
			}

			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				//http://stackoverflow.com/questions/8639315/how-to-create-a-json-net-date-to-string-custom-converter

				return DateTime.Parse(reader.Value.ToString()).ToLocalTime();
			}

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				DateTime dt = Convert.ToDateTime(value);
				if (dt != default(DateTime))
					dt = TimeZoneInfo.ConvertTimeToUtc(dt);

				writer.WriteValue(dt);
				writer.Flush();
			}
		}
	}
}
