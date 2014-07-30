﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// <para>Downloads data from a device connected via USB.</para<
	/// <para>Notes:</para>
	/// <para>- If the device does not have activity data the response will be a failure.</para>
	/// <para>- Does NOT delete data from the device.</para>
	/// </summary>
	public class USBDownload : RequestBase
	{
		[JsonIgnore]  //will be applied to Args in the base.
		public Actions.USBDownload Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
