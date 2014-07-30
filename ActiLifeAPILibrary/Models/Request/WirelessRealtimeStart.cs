using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Start receiving data real time from an ANT device. Wireless scanning must have been started previously.
    /// Notes:
    /// - Wireless scanning must have been started previously.
    /// - Real time streaming data will not arrive if the device isn’t being moved; the data should be considered latched. 
    ///   If sleep mode is disabled during initialization then continuous data is to be expected.
    /// </summary>
    public class WirelessRealtimeStart : RequestBase
    {
        public WirelessRealtimeStart()
        {
            Options = new Actions.WirelessRealtimeStart();
        }

        [JsonIgnore] //will be applied to Args in the base.
        public Actions.WirelessRealtimeStart Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}