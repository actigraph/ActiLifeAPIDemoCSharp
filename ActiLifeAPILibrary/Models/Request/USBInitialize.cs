using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// <para>Initializes a device connected via USB to prepare for a new activity monitoring session. [API 1.2]</para>
	/// <para> </para>
	/// <para>Notes: Will remove all activity data from the device.</para>
	/// </summary>
	public class USBInitialize : RequestBase
	{
		/// <summary>
		/// The device serial number to target.
		/// </summary>
		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public string Serial { get; set; }

		/// <summary>
		/// Bio information is a nested JSON object. The values will be injected into the file as metadata.
		/// </summary>
		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.BioData BioData { get; set; }

		/// <summary>
		/// Initialization options are a nested JSON object. These values control what is enabled on the device after initialization.
		/// </summary>
		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.InitOptions InitOptions { get; set; }

		public override string ToJson()
		{
			Args = new
			{
				Serial = Serial,
				BioData = BioData,
				InitOptions = InitOptions
			};

			return base.ToJson();
		}
	}
}
