using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> Create a clinical report for an AGD. </summary>
	public class CreateClinicalReport : ActionBase
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
		/// Options for creating a clinical report.
		/// </summary>
		[JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ClinicalReportOptions ClinicalReportOptions { get; set; }
	}
}
