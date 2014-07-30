using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Stop receiving data real time from an ANT device.
    /// </summary>
    public class WirelessRealtimeStop : RequestBase
    {
        public WirelessRealtimeStop()
        {
            Options = new Actions.WirelessRealtimeStop();
        }

        [JsonIgnore] //will be applied to Args in the base.
        public Actions.WirelessRealtimeStop Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}