using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    public class DataScoring
    {
        /// <summary>
        /// The source file to convert.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string FileInputPath { get; set; }

        /// <summary>
        /// Options for which filters to use when calculating.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public FilterOptions FilterOptions { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate energy expenditure results.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool CalculateEnergyExpenditure { get; set; }

        /// <summary>
        /// Options for calculating energy expenditure results.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public EnergyExpenditureOptions EnergyExpenditureOptions { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate MET results.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool CalculateMETs { get; set; }

        /// <summary>
        /// Options for calculating MET expenditure results.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public METOptions METOptions { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate Cut Point results..
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool CalculateCutPoints { get; set; }

        /// <summary>
        /// Options for calculating cut point results.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public CutPointOptions CutPointOptions { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate Bout results using the default ActiLife bout settings.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool CalculateBouts { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate Sedentary results using the default ActiLife sedentary settings.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool CalculateSedentaryAnalysis { get; set; }

        /// <summary>
        /// If enabled, ActiLife will calculate extra statistics.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IncludeExtraStatistics { get; set; }

        /// <summary>
        /// Options for which results to return.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public ResultOptions ResultOptions { get; set; }
    }
}
