using System;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> Change a wear time validation period from wear to non-wear or vice versa. </summary>
	public class ChangeWearTimeValidationPeriod : ActionBase
	{
		/// <summary>
		/// The source file to convert.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		public string FileInputPath { get; set; }

		/// <summary> The start date/time of the period to change. </summary>
		[JsonProperty(Required = Required.Always)]
		public DateTime StartDateTime { get; set; }

		/// <summary> The stop date/time of the period to change. </summary>
		[JsonProperty(Required = Required.Always)]
		public DateTime StopDateTime { get; set; }

		/// <summary> Whether you want the period to be wear or not. </summary>
		[JsonProperty(Required = Required.Always)]
		public bool IsWearPeriod { get; set; }
	}
}
