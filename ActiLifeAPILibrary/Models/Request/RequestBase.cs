using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	public class RequestBase
	{
		/// <summary>
		/// Action of the request (the endpoint).
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		public virtual string Action { get; set; }

		/// <summary>
		/// Arguments of the request.  This is how to control parameters of the Action.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public virtual dynamic Args { get; set; }

		/// <summary>
		/// Obtains JSON for the given request.
		/// </summary>
		/// <returns></returns>
		public virtual string ToJson()
		{
			JsonSerializerSettings dateFormattingSettings = new JsonSerializerSettings
				{
					Formatting = Newtonsoft.Json.Formatting.Indented,
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					DateTimeZoneHandling = DateTimeZoneHandling.Utc,
					Converters = new List<JsonConverter>() { new ActiLifeAPILibrary.Converters.JSONCustomDateConverter() }
				};
			return JsonConvert.SerializeObject(this, dateFormattingSettings);
		}
	}
}
