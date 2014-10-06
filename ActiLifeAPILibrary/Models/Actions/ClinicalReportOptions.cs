using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> List of options for creating a clinical report. </summary>
	public class ClinicalReportOptions
	{
		/// <summary> If set to true, the clinical report will calculate and show wear time validation information. </summary>
		[DefaultValue(true)]
		public bool WtvPageOn { get; set; }

		/// <summary> The wear time validation algorithm to use. </summary>
		[DefaultValue("Troiano")]
		public string WtvAlgorithmName { get; set; }
		
		/// <summary> If set to true, the clinical report will calculate and show energy expenditure information. </summary>
		[DefaultValue(true)]
		public bool EnergyExpenditurePageOn { get; set; }

		/// <summary> The energy expenditure formula to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		[DefaultValue("FreedsonSingleCombination")]
		public string EnergyExpenditureFormulaName { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show MET rate information. </summary>
		[DefaultValue(true)]
		public bool MetPageOn { get; set; }

		/// <summary> The MET formula to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		[DefaultValue("FreedsonEEAdult")]
		public string MetFormulaName { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show cut point information. </summary>
		[DefaultValue(true)]
		public bool CutPointPageOn { get; set; }
		
		/// <summary> The cut point set to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		[DefaultValue("FreedsonAdult1998")]
		public string CutPointSetName { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a dual plot for each calendar day with sleep information. </summary>
		[DefaultValue(true)]
		public bool SleepGraphPageOn { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a table of sleep scores. </summary>
		[DefaultValue(true)]
		public bool SleepTablePageOn { get; set; }

		/// <summary> Sleep algorithm to use in the clinical report. </summary>
		[DefaultValue("Sadeh")]
		public string SleepAlgorithm { get; set; }

		/// <summary> If set to true, the clinical report will show a title page. </summary>
		[DefaultValue(true)]
		public bool TitlePageOn { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a box for interpretation on the last page. </summary>
		[DefaultValue(true)]
		public bool InterpretationPageOn { get; set; }

		/// <summary> If set to true, the clinical report will use log diary times when calculating energy expenditure and cut points. </summary>
		[DefaultValue(false)]
		public bool LogDiaryOn { get; set; }

		/// <summary> The default value for clinical report options if the options are unable to be parsed. </summary>
		[JsonIgnore]
		public static ClinicalReportOptions Default
		{
			get
			{
				return new ClinicalReportOptions
				{
					WtvPageOn = true,
					WtvAlgorithmName = "Troiano",
					EnergyExpenditurePageOn = true,
					EnergyExpenditureFormulaName = "FreedsonSingleCombination",
					MetPageOn = true,
					MetFormulaName = "FreedsonEEAdult",
					CutPointPageOn = true,
					CutPointSetName = "FreedsonAdult1998",
					SleepGraphPageOn = true,
					SleepTablePageOn = true,
					SleepAlgorithm = "Sadeh",
					TitlePageOn = true,
					InterpretationPageOn = true,
					LogDiaryOn = false
				};
			}
		}
	}
}
