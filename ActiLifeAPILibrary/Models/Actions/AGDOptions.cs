using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Describes what data should be included in the downloaded AGD file.
	/// </summary>
	public class AGDOptions : ActionBase
	{
		/// <summary>
		/// Number of axis to include in AGD. Must be at least 1 Axis to create an AGD!
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public int Axis { get; set; }

		/// <summary>
		/// Whether to include steps in the AGD (if device was recording steps).
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Steps { get; set; }

		/// <summary>
		/// Whether to include LUX in the AGD (if device was recording LUX).
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Lux { get; set; }

		/// <summary>
		/// Whether to include Heart Rate in the AGD (if device was recording Heart Rate).
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool HR { get; set; }

		/// <summary>
		/// Whether to include Inclinometer data in the AGD (if device was recording inclinometer).
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Inclinometer { get; set; }

		/// <summary>
		/// <para>Duration of an epoch in seconds.</para>
		///<para>Accepted values:</para>
		///<para>1,
		///2,
		///3,
		///5,
		///10,
		///15,
		///30,
		///60,
		///120,
		///150,
		///180,
		///240</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public int EpochLengthInSeconds { get; set; }
	}
}
