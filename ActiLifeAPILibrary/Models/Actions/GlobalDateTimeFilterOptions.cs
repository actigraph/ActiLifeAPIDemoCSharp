using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for what to do with global date/time filters in data scoring </summary>
    public class GlobalDateTimeFilterOptions
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("UseGlobalDateTimeFilters")]
        [DefaultValue(true)]
        public bool UseGlobalDateTimeFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("GlobalDateTimeFilters")]
        [DefaultValue(null)]
        public List<ScoringFilter> GlobalDateTimeFilters { get; set; }
    }
}