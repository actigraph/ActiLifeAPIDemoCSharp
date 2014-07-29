using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for MET Algorithms. </summary>
    public class METOptions
    {
        /// <summary> Which MET algorithm to use. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("FreedsonEEAdult")]
        public virtual string Algorithm { get; set; }

        public METOptions()
        {
            Algorithm = "FreedsonEEAdult";
        }
    }
}
