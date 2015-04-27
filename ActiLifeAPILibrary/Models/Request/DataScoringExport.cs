using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Get data scoring algorithm results for a single AGD file. [API 1.10]
    /// </summary>
    public class DataScoringExport : RequestBase
    {
        [JsonIgnore] //will be applied to Args in the base.
        public Actions.DataScoringExport Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}