using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Get data scoring algorithm results for a single AGD file. [API 1.10]
	/// </summary>
	public class DataScoring : RequestBase
	{
		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.DataScoring Options { get; set; }

		public override string ToJson()
		{
			Args = Options;
            IgnoreUtcConverstion = true;
			return base.ToJson();
		}
	}
}
