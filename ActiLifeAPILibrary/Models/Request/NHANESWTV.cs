using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Returns Wear Time Validation information from a .GT3X file or .AGD file. This is specific for NHANES. A more robust WTV API action will be added in the future. [API 1.7]
	/// </summary>
	public class NHANESWTV :RequestBase
	{
		public NHANESWTV()
		{
			Options = new Actions.NhanesWtv();
		}

		[JsonIgnoreAttribute] //will be applied to Args in the base.
		public Actions.NhanesWtv Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
