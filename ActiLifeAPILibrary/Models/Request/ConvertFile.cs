using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Converts a file from one file format and epoch length to another. [API 1.9]
	/// </summary>
	public class ConvertFile : RequestBase
	{
		public ConvertFile()
		{
			Options = new Actions.ConvertFile();
		}

		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.ConvertFile Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
