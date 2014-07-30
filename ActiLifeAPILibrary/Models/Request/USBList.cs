using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Lists all connected USB devices and continues listing devices as they are plugged in. [API 1.1]
	/// </summary>
	public class USBList : RequestBase
	{
		public USBList()
		{
			Options = new Actions.USBList();
		}

		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.USBList Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
