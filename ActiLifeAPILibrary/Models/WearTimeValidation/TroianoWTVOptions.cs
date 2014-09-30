using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Implementation of WTV Options for Troiano (2007)
	/// </summary>
	public class TroianoWTVOptions : FloatingWindowWTVOptions
	{
		public override WTVAlgorithm Algorithm { get { return WTVAlgorithm.Troiano; } }

		/// <summary>
		/// The units for the minimum length (minutes or epochs)
		/// </summary>
		public Units MinimumLengthUnits { get; set; }

		/// <summary>
		/// If true, allow the user to set a count value that is considered non-wear
		/// </summary>
		public bool UseActivityThreshold { get; set; }
		/// <summary>
		/// The count value that is considered non-wear (counts ranging from 0 to this value are non-wear)
		/// </summary>
		public int ActivityThreshold { get; set; }
		/// <summary>
		/// The units for the activity threshold (minutes or epochs)
		/// </summary>
		public Units ActivityThresholdUnits { get; set; }

		/// <summary>
		/// If true, allow the user to set a large count value that is considered non-wear
		/// </summary>
		public bool UseMaxCount { get; set; }
		/// <summary>
		/// The large count value that is considered non-wear (counts ranging from this value to infinity are non-wear)
		/// </summary>
		public int MaxCount { get; set; }
		/// <summary>
		/// The units for the max count (minutes or epochs)
		/// </summary>
		public Units MaxCountUnits { get; set; }

		/// <summary>
		/// The amount of time allowed to be non-zero in a non-wear period
		/// </summary>
		public int SpikeTolerance { get; set; }
		/// <summary>
		/// The units for the spike tolerance (minutes or epochs)
		/// </summary>
		public Units SpikeToleranceUnits { get; set; }

		/// <summary>
		/// If true, allow the user to set a count value that immediately stops the detection of a non-wear period
		/// </summary>
		public bool UseCountsToStopNonWearPeriod { get; set; }
		/// <summary>
		/// The count value that will immediately stop the detection of a non-wear period
		/// </summary>
		public int CountsToStopNonWearPeriod { get; set; }
		/// <summary>
		/// The units for the counts to stop a non-wear period (minutes or epochs)
		/// </summary>
		public Units CountsToStopNonWearPeriodUnits { get; set; }

		/// <summary>
		/// If true, a non-wear period will require consecutive counts above the activity threshold to stop detection
		/// </summary>
		public bool UseConsecutiveEpochs { get; set; }
		
		/// <summary>
		/// The ActiGraph Default Troiano WTV Options
		/// </summary>
		[JsonIgnoreAttribute]
		public static TroianoWTVOptions Default
		{
			get
			{
				return new TroianoWTVOptions
				{
					MinimumLength = 60,
					UseActivityThreshold = false,
					ActivityThreshold = 0,
					ActivityThresholdUnits = Units.Minutes,
					UseMaxCount = false,
					SpikeTolerance = 2,
					SpikeToleranceUnits = Units.Minutes,
					UseCountsToStopNonWearPeriod = true,
					CountsToStopNonWearPeriod = 100,
					CountsToStopNonWearPeriodUnits = Units.Minutes,
					ShortWearPeriodsLength = 0,
					MinimumWearTimePerDayLength = 0,
					MinimumDaysOfValidWearTime = 0,
					UseConsecutiveEpochs = true,
					UseWearSenseData = true
				};
			}
		}
	}
}
