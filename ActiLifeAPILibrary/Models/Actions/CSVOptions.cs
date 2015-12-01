using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Options for a CSV file [API 1.9]
	/// </summary>
    public class CSVOptions : RawToEpochExportOptions
	{
		/// <summary>
		/// Includes the following information in the header.
        /// <para>Subject Name, 
        /// Gender, 
        /// Height, 
        /// Weight, 
        /// Date of Birth, 
        /// Age, 
        /// Race, 
        /// Side, 
        /// Dominance</para>
		/// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
		public bool IncludeMetadata { get; set; }

		/// <summary>
		/// Whether to include column headers.
		/// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
		public bool IncludeColumnHeaders { get; set; }

		/// <summary>
		/// Whether to include timestamps.
		/// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
		public bool IncludeTimestamps { get; set; }
	}
}
