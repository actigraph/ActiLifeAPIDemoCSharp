using System.ComponentModel;
using ActiLifeAPILibrary.Models.WearTimeValidation;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> Calculate wear time validation results for an agd file. </summary>
	public class WearTimeValidation : ActionBase
	{
		/// <summary>
		/// The source file to convert.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		public string FileInputPath { get; set; }

		/// <summary> Which energy expenditure algorithm to use. </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue("Troiano")]
		public string Algorithm { get; set; }

		/// <summary>
		/// Options for calculating Troiano wear time validation.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
		public TroianoWTVOptions TroianoOptions { get; set; }

		/// <summary>
		/// Options for calculating Choi wear time validation.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ChoiWTVOptions ChoiOptions { get; set; }
	}
}
