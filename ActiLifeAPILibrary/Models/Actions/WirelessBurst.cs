﻿using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Downloads requested number of minutes of data from an ANT device.
    /// </summary>
    public class WirelessBurst : ActionBase
    {
        /// <summary>
        /// The ANT+ identifier for the targeted device.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AntID { get; set; }

        /// <summary>
        /// The number of minutes of burst data requested.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Minutes { get; set; }

        /// <summary>
        /// Whether to use metric units (meters) instead of EN-US units (feet, inches).
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool FileUseMetricUnits { get; set; }

        /// <summary>
        /// The format in which the data is to be stored.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string FileFormat { get; set; }

        /// <summary>
        /// The location of the output file to be generated by ActiLife. Max length of 255 characters.
        /// </summary>
        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public string FileOutPutPath { get; set; }

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