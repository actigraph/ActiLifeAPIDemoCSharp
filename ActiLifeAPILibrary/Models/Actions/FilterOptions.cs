using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> Options for which filters to use for data scoring. </summary>
	public class FilterOptions : ActionBase
	{
		/// <summary> If enabled and the AGD file has them, ActiLife will filter non-wear time from the results. </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(false)]
		public bool UseWTVData { get; set; }

		/// <summary> If enabled and the AGD file has them, ActiLife will use log diary times. </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(false)]
		public bool UseLogDiaries { get; set; }
	}
}
