using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// RequestBase that sets the "Action" to the classes name, has a ToJson() implementation and handles Args.
	/// </summary>
	public class RequestBase
	{
		public RequestBase()
		{
			//find all properties that have classes and construct them.
			foreach (PropertyInfo item in (from prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
										   where prop.CanWrite && prop.GetType().IsClass && prop.PropertyType.GetConstructor(Type.EmptyTypes) != null
										   select prop))
			{
				var constructor = item.PropertyType.GetConstructor(Type.EmptyTypes);

				item.SetValue(this, constructor.Invoke(Type.EmptyTypes), null);
			}


			//now set all default values from DefaultValue attribute
			foreach (PropertyInfo item in (from prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
										   where prop.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), true).Length != 0
										   select prop))
			{
				foreach (var attribute in item.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), true))
				{
					item.SetValue(this, ((DefaultValueAttribute)attribute).Value, null);
				}
			}
		}

		/// <summary>
		/// Action of the request (the endpoint).  Populated by default to the type's Name.  Such as 'public class DataScoring' would be Action of 'DataScoring'.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		public virtual string Action { get { return this.GetType().Name; } }

		/// <summary>
		/// Arguments of the request.  This is how to control parameters of the Action.  Can be null for no arguments.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(typeof(object))]
		public virtual dynamic Args { get; set; }

		/// <summary>
		/// Obtains JSON for the given request.  Dates formatted in ISO/UTC.  Formatting is Indented.
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
