using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Implementation of WTV Options for the ActiGraph Daily Algorithm.
	/// </summary>
	public class DailyWTVOptions : BaseWTVOptions
	{
		public override WTVAlgorithm Algorithm { get { return WTVAlgorithm.Daily; } }

		/// <summary>
		/// Minimum number of wear hours in a day to be considered a valid day
		/// </summary>
		public int MinHours { get; set; }

		/// <summary>
		/// Minimum number of days of wear time to be considered a valid data set
		/// </summary>
		public int MinDays { get; set; }

		/// <summary>
		/// Minimum number of weekdays of wear time to be considered a valid data set
		/// </summary>
		public int MinWeekDays { get; set; }

		/// <summary>
		/// Minimum number of weekend days of wear time to be considered a valid data set
		/// </summary>
		public int MinWeekend { get; set; }

		/// <summary>
		/// If true, the algorithm uses consecutive minutes of zeros to detect non-wear time
		/// </summary>
		public bool UseMinZeros { get; set; }
		/// <summary>
		/// The number of consecutive minutes of zeros in an hour to be considered non-wear
		/// </summary>
		public int MinZeros { get; set; }

		/// <summary>
		/// If true, the algorithm uses the percent of non-zero epochs per hour algorithm to detect non-wear time
		/// </summary>
		public bool UsePercent { get; set; }
		/// <summary>
		/// The percentage of non-zero epochs in a hour to be considered non-wear
		/// </summary>
		public int Percent { get; set; }

		/// <summary>
		/// Counts at or below this number will be considered non-wear
		/// </summary>
		public int IgnoreCountsBelow { get; set; }

		/// <summary>
		/// Counts at or above this number will be considered non-wear
		/// </summary>
		public int IgnoreCountsAbove { get; set; }

		/// <summary>
		/// The ActiGraph Default Daily WTV Options
		/// </summary>
		[JsonIgnore]
		public static DailyWTVOptions Default
		{
			get
			{
				return new DailyWTVOptions
				{
					MinDays = 1,
					MinHours = 8,
					MinWeekDays = 0,
					MinWeekend = 0,
					UsePercent = true,
					UseMinZeros = false,
					Percent = 10,
					MinZeros = 30,
					IgnoreCountsBelow = 0,
					IgnoreCountsAbove = 0
				};
			}
		}
	}
}
