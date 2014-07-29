using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for Energy Expenditure Algorithms. </summary>
    public class EnergyExpenditureOptions
    {
        /// <summary> Which energy expenditure algorithm to use. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("FreedsonSingleCombination")]
        public virtual string Algorithm { get; set; }
    }
}
