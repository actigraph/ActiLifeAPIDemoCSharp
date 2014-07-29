﻿using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Options for what data scoring will return. </summary>
    public class ResultOptions
    {
        /// <summary> If enabled, total results will be calculated for each algorithm. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public virtual bool IncludeTotalResults { get; set; }

        /// <summary> If enabled, daily results will be calculated for each algorithm. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public virtual bool IncludeDailyResults { get; set; }

        /// <summary> If enabled, hourly results will be calculated for each algorithm. </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public virtual bool IncludeHourlyResults { get; set; }
    }
}
