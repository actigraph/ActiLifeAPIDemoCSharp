using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Stop receiving data real time from an ANT device.
    /// </summary>
    public class WirelessRealtimeStop : ActionBase
    {
        /// <summary>
        /// The ANT+ identifier for the targeted device.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AntID { get; set; }
    }
}