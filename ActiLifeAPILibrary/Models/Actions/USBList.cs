using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Options for the USBList Action
	/// </summary>
	public class USBList
	{
		/// <summary>
		/// Instructs ActiLife to continue notifying when devices are connected. If disabled, ActiLife will send a response for each device connected and NOT continue to notify when new devices are connected.
		/// Notes:
		/// To regain the asynchronous functionality simply issue the USBList action with this turned on.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(false)]
		public bool ContinueReportingAsync { get; set; }
	}
}
