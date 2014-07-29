using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	public class RequestBase
	{
		[JsonProperty(Required = Newtonsoft.Json.Required.Always)]
		/// <summary>
		/// Action of the request (the endpoint).
		/// </summary>
		public virtual string Action { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		/// <summary>
		/// Arguments of the request.  This is how to control parameters of the Action.
		/// </summary>
		public virtual string Args { get; set; }

		/// <summary>
		/// Obtains JSON for the given request.
		/// </summary>
		/// <returns></returns>
		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
