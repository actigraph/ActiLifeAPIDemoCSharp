using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Create a clinical report for a single file. [API 1.11]
	/// </summary>
	public class CreateClinicalReport : RequestBase
	{
		/// <summary>
		/// Wear time validation options.
		/// </summary>
		[JsonIgnore] //will be applied to Args in the base.
		public Actions.CreateClinicalReport Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
