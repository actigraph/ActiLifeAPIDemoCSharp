using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for MET Algorithms. </summary>
    public class CutPointOptions
    {
        /// <summary> Which cut point algorithm to use. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("FreedsonAdult1998")]
        public virtual string Algorithm { get; set; }
    }
}
