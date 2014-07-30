using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Identifies and describes the subject wearing a device.
	/// </summary>
	public class BioData : ActionBase
	{
		/// <summary>
		/// Identifier for the subject wearing the monitor.
		/// Restrictions:
		/// NEO or later: 255 characters
		/// Pre-NEO: 16 characters
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string SubjectName { get; set; }

		/// <summary>
		/// Accepted values:
		/// "Male"
		/// "Female"
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Sex { get; set; }

		/// <summary>
		/// Height of the subject.
		/// Notes:
		/// The unit of measure (English/Metric) corresponds with the ActiLife setting.
		/// Restrictions:
		/// 0-500 in
		/// or 0-500 cm
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public float Height { get; set; }

		/// <summary>
		/// Weight of the subject.
		/// Notes:
		/// The unit of measure (English/Metric) corresponds with the ActiLife setting.
		/// Restrictions:
		/// 0-2000 lbs
		/// or 0-2000 kg
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public float Weight { get; set; }

		/// <summary>
		/// Age of the subject.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public int Age { get; set; }

		/// <summary>
		/// Race of the subject.
		/// Accepted values:
		/// "Asian / Pacific Islander"
		/// "Black / African American"
		/// "White / Caucasian"
		/// "Latino / Hispanic"
		/// "Other"
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Race { get; set; }

		/// <summary>
		/// Date of birth of the subject.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Limb the device was used.
		/// Accepted values:
		/// "Wrist"
		/// "Waist"
		/// "Ankle"
		/// "Upper Arm"
		/// "Thigh"
		/// "Chest"
		/// "Back"
		/// "Other"
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Limb { get; set; }

		/// <summary>
		/// Side that the device was used.
		/// Accepted values:
		/// "Right"
		/// "Left"
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Side { get; set; }

		/// <summary>
		/// Dominance of wear position.
		/// Accepted values:    
		/// "Dominant"
		/// "Non-Dominant"
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Dominance { get; set; }
	}
}
