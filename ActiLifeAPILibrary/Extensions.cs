using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPILibrary
{
	public static class Extensions
	{
		public static T GetValueFromJToken<T>(this Newtonsoft.Json.Linq.JToken j, string key, T defaultValue)
		{
			JToken obj = null;
			if (j is JObject)
				obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
			else
				obj = j[key.ToLower()];

			if (obj == null) throw new ArgumentException("Unable to locate JSON token: \"" + key + "\"");

			T returnObj = default(T);

			if (obj is Newtonsoft.Json.Linq.JArray)
				returnObj = obj.ToObject<T>();
			else
				returnObj = obj.Value<T>();

			//Convert UTC datetimes back to local system time.  API is ISO8601; UTC is used!
			if (returnObj is DateTime)
				returnObj = Cast<T>(Convert.ToDateTime(returnObj).ToLocalTime());

			return returnObj;
		}

		/// <summary>Method used to dynamically cast (through reflection) one type to another type (object to a correct type).</summary>
		public static T Cast<T>(object o)
		{
			return (T)o;
		}
	}
}
