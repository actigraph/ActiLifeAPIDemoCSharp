using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Describes what data should be included when exporting from raw data to epoch.
    /// </summary>
    public class RawToEpochExportOptions
    {
        /// <summary>
        /// <para>Number of axis to include in AGD. Must be at least 1 Axis.</para>
        ///<para>Accepted values:</para>
        ///<para>1,
        ///2,
        ///3</para>
        /// </summary>
        [JsonProperty("Axis", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(3)]
        public int Axis { get; set; }

        /// <summary>
        /// Whether to include steps in the AGD (if device was recording steps).
        /// </summary>
        [JsonProperty("Steps", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public bool Steps { get; set; }

        /// <summary>
        /// Whether to include LUX in the AGD (if device was recording LUX).
        /// </summary>
        [JsonProperty("Lux", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public bool Lux { get; set; }

        /// <summary>
        /// Whether to include Heart Rate in the AGD (if device was recording Heart Rate).
        /// </summary>
        [JsonProperty("HR", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool HR { get; set; }

        /// <summary>
        /// Whether to include Inclinometer data in the AGD (if device was recording inclinometer).
        /// </summary>
        [JsonProperty("Inclinometer", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public bool Inclinometer { get; set; }

        /// <summary>
        /// <para>Duration of an epoch in seconds.</para>
        ///<para>Accepted values:</para>
        ///<para>1,
        ///2,
        ///3,
        ///5,
        ///10,
        ///15,
        ///30,
        ///60,
        ///120,
        ///150,
        ///180,
        ///240</para>
        /// </summary>
        [JsonProperty("EpochLengthInSeconds", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(60)]
        public int EpochLengthInSeconds { get; set; }
    }
}