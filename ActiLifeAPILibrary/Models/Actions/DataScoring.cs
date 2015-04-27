using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Calculate Data Scoring results for a file. </summary>
    public class DataScoring : DataScoringBase
    {
        /// <summary> The source file to calculate. </summary>
        [JsonProperty(Required = Required.Always)]
        public string FileInputPath { get; set; }

        /// <summary> Options for which results to return. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public DataScoringResultOptions DataScoringResultOptions { get; set; }
    }
}
