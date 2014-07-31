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
		/// <para></para>
        /// <para>Restrictions:</para>
        /// <para>NEO or later: 255 characters</para>
        /// <para>Pre-NEO: 16 characters</para>
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string SubjectName { get; set; }

		/// <summary>
		/// Accepted values:
        /// <para>"Male"</para>
        /// <para>"Female"</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Sex { get; set; }

		/// <summary>
		/// Height of the subject.
		/// <para></para>
        /// <para>Notes:</para>
        /// <para>The unit of measure (English/Metric) corresponds with the ActiLife setting.</para>
        /// <para>Restrictions:</para>
        /// <para>0-500 in</para>
        /// <para>or 0-500 cm</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public float Height { get; set; }

		/// <summary>
		/// Weight of the subject.
        /// <para></para>
        /// <para>Notes:</para>
        /// <para>The unit of measure (English/Metric) corresponds with the ActiLife setting.</para>
        /// <para>Restrictions:</para>
        /// <para>0-2000 lbs</para>
        /// <para>or 0-2000 kg</para>
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
        /// <para></para>
        /// <para>Accepted values:</para>
        /// <para>"Asian / Pacific Islander"</para>
        /// <para>"Black / African American"</para>
        /// <para>"White / Caucasian"</para>
        /// <para>"Latino / Hispanic"</para>
        /// <para>"Other"</para>
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
        /// <para></para>
        /// <para>Accepted values:</para>
        /// <para>"Wrist"</para>
        /// <para>"Waist"</para>
        /// <para>"Ankle"</para>
        /// <para>"Upper Arm"</para>
        /// <para>"Thigh"</para>
        /// <para>"Chest"</para>
        /// <para>"Back"</para>
        /// <para>"Other"</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Limb { get; set; }

		/// <summary>
		/// Side that the device was used.
        /// <para></para>
        /// <para>Accepted values:</para>
        /// <para>"Right"</para>
        /// <para>"Left"</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Side { get; set; }

		/// <summary>
		/// Dominance of wear position.
        /// <para></para>
        /// <para>Accepted values:</para>
        /// <para>"Dominant"</para>
        /// <para>"Non-Dominant"</para>
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string Dominance { get; set; }
	}
}
