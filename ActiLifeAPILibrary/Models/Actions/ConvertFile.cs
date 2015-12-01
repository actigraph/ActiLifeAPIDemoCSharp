﻿using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// Converts a file from one file format and epoch length to another. [API 1.9]
	/// </summary>
	public class ConvertFile : ActionBase
	{
		/// <summary>
		/// The source file to convert.
		/// <para></para>
        /// <para>Accepted Input Formats:</para>
        /// <para>gt3x</para>
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string FileInputPath { get; set; }

		/// <summary>
		/// The location of the output file to be generated by ActiLife. 
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string FileOutputPath { get; set; }

		/// <summary>
		/// Format to convert FileInputPath to. 
		/// </summary>
		[JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
		public string FileOutputFormat { get; set; }

		/// <summary>
		/// Options for creating a CSV file if CSV is desired output.
		/// </summary>
		public CSVOptions CSVOptions { get; set; }
		
		/// <summary>
		/// Options for creating an AGD file if AGD is desired output.
		/// </summary>
		public AGDOptions AGDOptions { get; set; }

		/// <summary>
		/// If enabled ActiLife will delete any file at the given FileOutputPath before converting. 
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(false)]
		public bool ForceOverwrite { get; set; }
	}
}
