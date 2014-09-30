using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Implementation of WTV Options for Choi (2011)
	/// </summary>
	public class ChoiWTVOptions : FloatingWindowWTVOptions
	{
		public override WTVAlgorithm Algorithm { get { return WTVAlgorithm.Choi; } }

		/// <summary>
		/// The small window used to determine if spikes should be considered non-wear
		/// </summary>
		public int SmallWindow { get; set; }

		/// <summary>
		/// The amount of time allowed to be non-zero in a row
		/// </summary>
		public int SpikeTolerance { get; set; }

		/// <summary>
		/// The ActiGraph Default Choi WTV Options
		/// </summary>
		[JsonIgnore]
		public static ChoiWTVOptions Default
		{
			get
			{
				return new ChoiWTVOptions
				{
					MinimumLength = 90,
					SmallWindow = 30,
					SpikeTolerance = 2,
					UseWearSenseData = true
				};
			}
		}
	}
}
