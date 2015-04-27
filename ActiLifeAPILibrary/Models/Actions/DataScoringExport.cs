using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Calculate Data Scoring results for a file. </summary>
    public class DataScoringExport : DataScoringBase
    {
        /// <summary>
        /// The type of export to use.
        /// </summary>
        public enum ExportType
        {
            /// <summary> Export to Excel format with one file and multiple sheets in the file. </summary>
            Excel,
            /// <summary> Export to CSV format with multiple files. </summary>
            Csv
        }

        /// <summary> The source files to calculate and convert. </summary>
        [JsonProperty(Required = Required.Always)]
        public string[] FileInputPaths { get; set; }

        /// <summary> The location to export results. </summary>
        [JsonProperty(Required = Required.Always)]
        public string ExportLocation { get; set; }
        
        /// <summary> The options for what to show in the export sheets. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        public BatchExportSheetOptions BatchExportSheetOptions { get; set; }

        /// <summary> The type of export to use. </summary>
        public ExportType ExportFileType { get; set; }
    }
}