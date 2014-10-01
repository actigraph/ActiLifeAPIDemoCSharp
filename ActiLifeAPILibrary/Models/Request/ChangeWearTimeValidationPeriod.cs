using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
	/// <summary>
	/// Change a wear time validation period from wear to non-wear or vice versa. [API 1.11]
	/// </summary>
	public class ChangeWearTimeValidationPeriod : RequestBase
	{
		/// <summary>
		/// ChangeWearTimeValidationPeriod options.
		/// </summary>
		[JsonIgnore] //will be applied to Args in the base.
		public Actions.ChangeWearTimeValidationPeriod Options { get; set; }

		/// <summary> Export data to JSON. </summary>
		public override string ToJson()
		{
			Args = Options;
			IgnoreUtcConverstion = true;
			return base.ToJson();
		}
	}
}
