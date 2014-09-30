using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Get wear time validation results for a single AGD file. [API 1.11]
	/// </summary>
	public class WearTimeValidation : RequestBase
	{
		/// <summary>
		/// Wear time validation options.
		/// </summary>
		[JsonIgnore] //will be applied to Args in the base.
		public Actions.WearTimeValidation Options { get; set; }

		public override string ToJson()
		{
			Args = Options;

			return base.ToJson();
		}
	}
}
