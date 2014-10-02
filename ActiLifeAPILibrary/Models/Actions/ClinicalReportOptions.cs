using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary> List of options for creating a clinical report. </summary>
	public class ClinicalReportOptions
	{
		/// <summary> If set to true, the clinical report will calculate and show wear time validation information. </summary>
		public bool WtvPageOn { get; set; }

		/// <summary> The wear time validation algorithm to use. </summary>
		public WTVAlgorithm WtvAlgorithm { get; set; }

		/// <summary> If set to true, use the custom version of the algorithm. </summary>
		public bool WtvCustom { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show energy expenditure information. </summary>
		public bool EnergyExpenditurePageOn { get; set; }

		/// <summary> The energy expenditure formula to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		public int EnergyExpenditureFormulaIndex { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show MET rate information. </summary>
		public bool MetPageOn { get; set; }

		/// <summary> The MET formula to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		public int MetFormulaIndex { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show cut point information. </summary>
		public bool CutPointPageOn { get; set; }

		/// <summary> The cut point index to use. This helps with binding to a combobox. </summary>
		public int CutPointSetIndex { get; set; }

		/// <summary> The cut point set to use for the clinical report. If one is not set, it will use the default one from the data scoring tab. </summary>
		public CutPointSet CutPointSet { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a dual plot for each calendar day with sleep information. </summary>
		public bool SleepGraphPageOn { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a table of sleep scores. </summary>
		public bool SleepTablePageOn { get; set; }

		/// <summary> Sleep algorithm to use in the clinical report. </summary>
		public string SleepAlgorithm { get; set; }

		/// <summary> If set to true, the clinical report will show a title page. </summary>
		public bool TitlePageOn { get; set; }

		/// <summary> If set to true, the clinical report will calculate and show a box for interpretation on the last page. </summary>
		public bool InterpretationPageOn { get; set; }

		/// <summary> If set to true, the clinical report will use log diary times when calculating energy expenditure and cut points. </summary>
		public bool LogDiaryOn { get; set; }

		/// <summary> The default value for clinical report options if the options are unable to be parsed. </summary>
		[JsonIgnore]
		public static ClinicalReportOptions Default
		{
			get
			{
				return new ClinicalReportOptions
				{
					TitlePageOn = true,
					WtvPageOn = true,
					EnergyExpenditurePageOn = true,
					MetPageOn = true,
					CutPointPageOn = true,
					SleepGraphPageOn = true,
					SleepTablePageOn = true,
					InterpretationPageOn = true,
					LogDiaryOn = false,
					EnergyExpenditureFormulaIndex = 0,
					MetFormulaIndex = 0,
					CutPointSet = FreedsonAdult1998,
					WtvAlgorithm = WTVAlgorithm.Troiano,
					WtvCustom = false,
					SleepAlgorithm = "Sadeh"
				};
			}
		}

		/// <summary> ActiGraph default cut point set. </summary>
		public static CutPointSet FreedsonAdult1998
		{
			get
			{
				CutPointSet freedson = new CutPointSet("Freedson Adult (1998)", false);
				freedson.CutPoints.Add(new CutPoint("Sedentary", 0, 99));
				freedson.CutPoints.Add(new CutPoint("Light", 100, 1951));
				freedson.CutPoints.Add(new CutPoint("Moderate", 1952, 5724));
				freedson.CutPoints.Add(new CutPoint("Vigorous", 5725, 9498));
				freedson.CutPoints.Add(new CutPoint("Very Vigorous", 9499, int.MaxValue));
				freedson.MVPAMinimumCounts = 1952;
				return freedson;
			}
		}
	}

	/// <summary> Denotes the type of WTV Algorithm used. </summary>
	[DefaultValue(Troiano)]
	public enum WTVAlgorithm
	{
		/// <summary>2007 Troiano Algorithm</summary>
		Troiano = 0,

		/// <summary>2011 Choi Algorithm</summary>
		Choi = 1,

		/// <summary>Custom ActiGraph Algorithm</summary>
		Daily = 2
	}

	/// <summary> Cut point set to calculate activity intensity. </summary>
	public class CutPointSet
	{
		/// <summary> The name of the cut point set. </summary>
		public string Name { get; set; }

		/// <summary> The list of cut points to use. </summary>
		public List<CutPoint> CutPoints { get; set; }

		/// <summary> If true, the cut points will use vector magnitude. </summary>
		public bool BasedOnVM { get; set; }

		/// <summary> The minimum count value to be considered MVPA. </summary>
		public int MVPAMinimumCounts { get; set; }

		/// <summary> Create a cut point set; </summary>
		/// <param name="name">The name of the cut point set.</param>
		/// <param name="basedOnVM">Is this cut point set based on vector magnitude?</param>
		public CutPointSet(string name, bool basedOnVM)
		{
			CutPoints = new List<CutPoint>();
			Name = name;
			BasedOnVM = basedOnVM;
			MVPAMinimumCounts = 0;
		}
	}

	/// <summary> A single cut point used in cut point sets. </summary>
	public class CutPoint
	{
		/// <summary> The name of the cut point. </summary>
		public string Name { get; set; }

		/// <summary> Minimum counts for the cut point. </summary>
		public int Min { get; set; }
		
		/// <summary> Maximum counts for cut point. </summary>
		public int Max { get; set; }

		/// <summary>
		/// Create a cut point from a name, min, and max value.
		/// </summary>
		/// <param name="name">Name of the cut point.</param>
		/// <param name="min">Minimum counts for the cut point.</param>
		/// <param name="max">Maximum counts for the cut point.</param>
		public CutPoint(string name, int min, int max)
		{
			Name = name;
			Min = min;
			Max = max;
		}
	}
}
