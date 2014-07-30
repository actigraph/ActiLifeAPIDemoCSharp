using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Initializes an ANT device (only available on w-Devices such as wGT3X+ and wActiSleep+).
    /// </summary>
    public class WirelessInitialize : RequestBase
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

        /// <summary>
        /// Initialization options are a nested JSON object. These values control what is enabled on the device after initialization.
        /// </summary>
        [JsonIgnore] //will be applied to Args in the base.
        public Actions.InitOptions InitOptions { get; set; }

        /// <summary>
        /// Bio information is a nested JSON object. The values will be injected into the file as metadata.
        /// </summary>
        [JsonIgnore] //will be applied to Args in the base.
        public Actions.BioData BioData { get; set; }

        public override string ToJson()
        {
            Args = new
            {
                AntID,
                TimeoutSeconds,
                AntPIN,
                InitOptions,
                BioData
            };

            return base.ToJson();
        }
    }
}