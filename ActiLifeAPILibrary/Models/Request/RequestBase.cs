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
