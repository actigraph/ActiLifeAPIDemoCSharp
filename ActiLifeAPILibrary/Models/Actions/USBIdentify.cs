using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Options for USBIdentify action.
	/// </summary>
	public class USBIdentify : ActionBase
	{
		/// <summary>
		/// The device serial number to target.
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Serial { get; set; }
	}
}
