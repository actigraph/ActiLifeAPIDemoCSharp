using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Starts the wireless scan of devices.
    /// </summary>
    public class WirelessStart : ActionBase
    {
        /// <summary>
        /// Four character ASCII string.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AntPIN { get; set; }
    }
}