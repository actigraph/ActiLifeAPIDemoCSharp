using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Identifies an ANT device by flashing the LEDs.
    /// </summary>
    public class WirelessIdentify : ActionBase
    {
        /// <summary>
        /// The ANT+ identifier for the targeted device.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AntID { get; set; }

        /// <summary>
        /// The timeout in seconds before ActiLife returns a failure because of timeout.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public int TimeoutSeconds { get; set; }

        /// <summary>
        /// Four character ASCII string.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AntPIN { get; set; }
    }
}