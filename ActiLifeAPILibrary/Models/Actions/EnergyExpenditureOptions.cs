using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for Energy Expenditure Algorithms. </summary>
	public class EnergyExpenditureOptions : ActionBase
    {
        /// <summary> Which energy expenditure algorithm to use. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("FreedsonSingleCombination")]
        public string Algorithm { get; set; }

        /// <summary> Weight of the subject in kilograms. </summary>
        /// <para></para>
        /// <para>Note:</para>
        /// <para>- If one isn't passed in, it will use the weight stored on the AGD file.</para>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual float Weight { get; set; }
    }
}
