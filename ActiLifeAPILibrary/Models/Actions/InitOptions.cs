using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Configures a device when initializing.
	/// </summary>
	public class InitOptions : ActionBase
	{
		/// <summary>
		/// Caller defined (no restrictions on value).
		/// Notes:
		/// Max length of 255 characters for GT3X+ devices or newer.
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string SubjectName { get; set; }

		/// <summary>
		/// Start time for the device to start recording.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public DateTime StartDateTime { get; set; }

		/// <summary>
		/// Stop time for the device to stop recording. Can be omitted to allow the device to continue recording indefinitely.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public DateTime StopDateTime { get; set; }

		/// <summary>
		/// Sample rate to use. Can be Hz value or epoch length in seconds.
		/// Notes:
		/// This depends on ability of device. Older devices are unable to handle multiple samples per second and use an epoch of the seconds.
		/// Accepted Hz values:
		/// 30 (default),
		/// 40,
		/// 50,
		/// 60,
		/// 70,
		/// 80,
		/// 90,
		/// 100
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(30)]
		public int SampleRate { get; set; }

		/// <summary>
		/// Amount of axis to enable while recording. This is device dependant (GT3X+ and newer default to 3).
		/// Accepted values:
		/// 1,2,3
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public int Axis { get; set; }

		/// <summary>
		/// Whether to record steps during recording.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Steps { get; set; }

		/// <summary>
		/// Whether to record inclinometer changes during recording.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Inclinometer { get; set; }

		/// <summary>
		/// Whether to flash the LED while recording data.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool FlashLEDWhileActive { get; set; }

		/// <summary>
		/// Whether to flash the LED while in DELAY mode.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool FlashLEDInDelay { get; set; }

		/// <summary>
		/// Notes: Only available on devices capable of using Polar strap or wireless devices. Must be used with a heart rate strap!
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool HeartRate { get; set; }

		/// <summary>
		/// Whether to record ambient light changes during recording.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool Lux { get; set; }

		/// <summary>
		/// Whether to prevent the device from entering a sleep mode during inactivity.
		/// Notes: This dramatically reduces battery life!
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool DisableSleepMode { get; set; }

		/// <summary>
		/// Enable ANT Wireless capabilities.
		/// Notes: Only available on w-Devices such as wGT3X+ and wActiSleep+.
		/// Ignored by WirelessInitialize action.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool AntWireless { get; set; }

		/// <summary>
		/// Enable Data Summary capabilities (stores daily summary data into expenditure ‘buckets’).
		/// Notes: Only available on w-Devices such as wGT3X+ and wActiSleep+.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool DataSummary { get; set; }

		/// <summary>
		/// Prevent FW upgrading during initialization.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool DoNotUpgradeFW { get; set; }
	}
}
