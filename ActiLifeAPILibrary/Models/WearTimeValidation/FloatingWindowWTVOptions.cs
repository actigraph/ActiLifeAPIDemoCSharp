namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Basic options for Floating Window WTV such as MinimumLength and Use VM (also includes Optional Screening Parameters).
	/// </summary>
	public abstract class FloatingWindowWTVOptions : BaseWTVOptions
	{
		/// <summary>
		/// The minimum length of a non-wear period
		/// </summary>
		public int MinimumLength { get; set; }

		/// <summary>
		/// If set to true (and the file has 3 axis data), vector magnitude will be used
		/// </summary>
		public bool VM { get; set; }

		#region Optional Screening Paramters

		/// <summary>
		/// If set to true, wear periods must be a certain length to be valid
		/// </summary>
		public bool UseIgnoreShortWearPeriods { get; set; }
		/// <summary>
		/// Wear Periods at or below this value will be ignored and converted to non-wear time
		/// </summary>
		public int ShortWearPeriodsLength { get; set; }
		/// <summary>
		/// The units for the short wear periods (minutes or epochs)
		/// </summary>
		public Units ShortWearPeriodsUnits { get; set; }

		/// <summary>
		/// If set to true, require a minimum amount of wear per day
		/// </summary>
		public bool UseMinimumWearTimePerDay { get; set; }
		/// <summary>
		/// If the amount of wear for a calendar day is below the specified level, the entire day will be converted to non-wear
		/// </summary>
		public int MinimumWearTimePerDayLength { get; set; }
		/// <summary>
		/// The units for the minimum wear time per day (minutes or epochs)
		/// </summary>
		public Units MinimumWearTimePerDayUnits { get; set; }

		/// <summary>
		/// The number of days with valid wear time required to make a data set required
		/// If a dataset doesn't have the specified number of days, the entire file will be set to non-wear
		/// </summary>
		public int MinimumDaysOfValidWearTime { get; set; }

        /// <summary>
        /// The number of weekdays with valid wear time required to make a data set required
        /// If a dataset doesn't have the specified number of weekdays, the entire file will be set to non-wear
        /// </summary>
        public int MinimumWeekDaysOfValidWearTime { get; set; }

        /// <summary>
        /// The number of weekend days with valid wear time required to make a data set required
        /// If a dataset doesn't have the specified number of weekend days, the entire file will be set to non-wear
        /// </summary>
        public int MinimumWeekendDaysOfValidWearTime { get; set; }

		/// <summary>
		/// Controls if sleep periods should be used in this bout setting.
		/// </summary>
		public SleepPeriodWTVOption Sleep { get; set; }

		/// <summary>
		/// If set to true, wear sense (capacitive touch) data will be used to verify wear time validation results.
		/// </summary>
		public bool UseWearSenseData { get; set; }

		#endregion Optional Screening Paramters

		/// <summary> The units of measurement for a period of time. </summary>
		public enum Units
		{
			/// <summary> Period of time is in minutes. </summary>
			Minutes = 0,
			/// <summary> Period of time is in epochs. </summary>
			Epochs
		}

		/// <summary>
		/// Controls if sleep periods are used when performing Wear Time Validation.
		/// </summary>
		public enum SleepPeriodWTVOption
		{
			/// <summary>
			/// This will not use bed times as a factor when calculating Wear Time Validation. They can be wear or non-wear time.
			/// </summary>
			Ignore,
			/// <summary>
			/// This used to be called "Ignore Bed Times." This will now set bed times as wear time automatically.
			/// </summary>
			MarkAsWearTime,
			/// <summary>
			/// This will set bed times as NON-wear time automatically.
			/// </summary>
			MarkAsNonWearTime
		}
	}
}
