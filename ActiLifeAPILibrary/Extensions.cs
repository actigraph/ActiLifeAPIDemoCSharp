using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPILibrary
{
	public static class Extensions
	{
		/// <summary>
		/// Obtains a casted object for the given json token. Returns the default value if the token key is not found in the JSON.
		/// </summary>
		/// <typeparam name="T">Type of object to return/cast to.</typeparam>
		/// <param name="j">JToken to get value from.</param>
		/// <param name="key">JSON Key to retrieve value from.</param>
		/// <param name="defaultValue">Default value to return if Key was not found in the JToken.</param>
		/// <returns>Value found in the JToken, otherwise the defaultValue provided.</returns>
		public static T GetValueFromJToken<T>(this Newtonsoft.Json.Linq.JToken j, string key, T defaultValue)
		{
			if (!j.Any())
			{
				//if the JSON doesn't have args but we have a default value, use it!
				return defaultValue;
			}

			JToken obj = null;
			if (j is JObject)
				obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
			else
				obj = j[key.ToLower(System.Globalization.CultureInfo.InvariantCulture)];

			if (obj == null) return defaultValue;

			T returnObj = default(T);

			if (obj is Newtonsoft.Json.Linq.JArray)
				returnObj = obj.ToObject<T>();
			else
				returnObj = obj.Value<T>();

			//HACK: this is a conflict of interest; the DateTime conversion shouldn't be here!
			if (returnObj is DateTime)
				returnObj = Cast<T>(Convert.ToDateTime(returnObj).ToLocalTime());

			return returnObj;
		}

		/// <summary>
		/// Obtains a casted object for the given json token. Throws an exception if the token key is not found in the JSON.
		/// </summary>
		/// <typeparam name="T">Type of object to return/cast to.</typeparam>
		/// <param name="j">JToken to get value from.</param>
		/// <param name="key">JSON Key to retrieve value from.</param>
		/// <returns>Value found in the JToken, otherwise an exception is thrown.</returns>
		public static T GetValueFromJToken<T>(this Newtonsoft.Json.Linq.JToken j, string key)
		{
			if (!j.Any())
				throw new ArgumentException("JSON is empty, cannot satisfy: \"" + key + "\"");

			JToken obj = null;
			if (j is JObject)
				obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
			else
				obj = j[key.ToLower(System.Globalization.CultureInfo.InvariantCulture)];

			if (obj == null) throw new ArgumentException("Unable to locate JSON token: \"" + key + "\"");

			T returnObj = default(T);

			if (obj is Newtonsoft.Json.Linq.JArray)
				returnObj = obj.ToObject<T>();
			else
				returnObj = obj.Value<T>();

			//HACK: this is a conflict of interest; the DateTime conversion shouldn't be here!
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
