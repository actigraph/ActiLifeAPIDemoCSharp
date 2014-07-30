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
		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.USBInitialize Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
