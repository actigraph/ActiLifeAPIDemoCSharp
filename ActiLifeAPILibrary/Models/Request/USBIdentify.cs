using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Identifies a device by flashing the LEDs. [API 1.5]
	/// </summary>
	public class USBIdentify : RequestBase
	{
		[JsonIgnore]  //will be applied to Args in the base.
		public string Serial { get; set; }

		public override string ToJson()
		{
			Args = new { Serial = Serial };

			return base.ToJson();
		}
	}
}
