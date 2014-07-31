using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Options for a CSV file [API 1.9]
	/// </summary>
	public class CSVOptions
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
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool IncludeMetadata { get; set; }

		/// <summary>
		/// Whether to include column headers.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool IncludeColumnHeaders { get; set; }

		/// <summary>
		/// Whether to include timestamps.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool IncludeTimestamps { get; set; }
	}
}
