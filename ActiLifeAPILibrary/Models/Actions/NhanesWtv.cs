using System.ComponentModel;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary>
    /// Wear Time Validation information from a .GT3X file or .AGD file. 
    /// This is specific for NHANES. 
    /// A more robust WTV API action will be added in the future.
    /// </summary>
	public class NhanesWtv : ActionBase
    {
        /// <summary>
        /// The file to process. Supports both AGD and GT3X files.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Filename { get; set; }

        /// <summary>
        /// Minimum length in minutes of a non-wear period. Defaults to 60.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(60)]
        public int MinLength { get; set; }

        /// <summary>
        /// Counts at and below this number be considered inactivity. Defaults to 10.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(10)]
        public int MinCounts { get; set; }

        /// <summary>
        /// Amount of time in minutes allowed above the MinCounts in a non-wear period. Defaults to 2.
        /// </summary>
        [JsonProperty(Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(2)]
        public int DropTime { get; set; }

		public NhanesWtv()
		{

		}

        public NhanesWtv(string filename)
        {
            Filename = filename;
        }

        public NhanesWtv(string filename, int minLength, int minCounts, int dropTime)
        {
            Filename = filename;
            MinLength = minLength;
            MinCounts = minCounts;
            DropTime = dropTime;
        }
    }
}
