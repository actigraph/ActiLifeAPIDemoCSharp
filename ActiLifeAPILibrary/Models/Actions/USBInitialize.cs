using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Options for the USBInitialize action.
	/// </summary>
	public class USBInitialize:ActionBase
	{
		/// <summary>
		/// The device serial number to target.
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Serial { get; set; }

		/// <summary>
		/// Bio information is a nested JSON object. The values will be injected into the file as metadata.
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public Actions.BioData BioData { get; set; }

		/// <summary>
		/// Initialization options are a nested JSON object. These values control what is enabled on the device after initialization.
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public Actions.InitOptions InitOptions { get; set; }
	}
}
