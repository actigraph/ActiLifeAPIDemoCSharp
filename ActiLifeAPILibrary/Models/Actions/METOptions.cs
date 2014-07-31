using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for MET Algorithms. </summary>
	public class METOptions : ActionBase
    {
        /// <summary> Which MET algorithm to use. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("FreedsonEEAdult")]
        public virtual string Algorithm { get; set; }

        /// <summary> Weight of the subject in kilograms. </summary>
        /// <para></para>
        /// <para>Note:</para>
        /// <para>- Only required for FreedsonEEAdult algorithm.</para>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual float Weight { get; set; }

        /// <summary> Age of the subject in kilograms. </summary>
        /// <para></para>
        /// <para>Note:</para>
        /// <para>- Only required for FreedsonChildren algorithm.</para>
        /// <para>- Ages of 6-18 required for FreedsonChildren algorithm</para>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Age { get; set; }
    }
}
