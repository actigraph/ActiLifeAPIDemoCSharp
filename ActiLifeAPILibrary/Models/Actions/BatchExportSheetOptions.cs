using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for what the data scoring export sheets will contain. </summary>
    public class BatchExportSheetOptions
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("AddDefinitionComments")]
        [DefaultValue(false)]
        public bool AddDefinitionComments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("AddDefinitionWorksheet")]
        [DefaultValue(false)]
        public bool AddDefinitionWorksheet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("AddWtv")]
        [DefaultValue(false)]
        public bool AddWtv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowNonWear")]
        [DefaultValue(false)]
        public bool ShowNonWear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowSummary")]
        [DefaultValue(false)]
        public bool ShowSummary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowDaily")]
        [DefaultValue(false)]
        public bool ShowDaily { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowHourly")]
        [DefaultValue(false)]
        public bool ShowHourly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("AddSleepScores")]
        [DefaultValue(false)]
        public bool AddSleepScores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowBoutDetails")]
        [DefaultValue(false)]
        public bool ShowBoutDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ShowSedentaryDetails")]
        [DefaultValue(false)]
        public bool ShowSedentaryDetails { get; set; }
    }
}