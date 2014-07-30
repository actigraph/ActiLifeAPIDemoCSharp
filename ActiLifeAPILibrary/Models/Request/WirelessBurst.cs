using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Downloads requested number of minutes of data from an ANT device.
    /// Notes:
    /// - Wireless scanning must have been started previously.
    /// - Does NOT delete data from the device
    /// </summary>
    public class WirelessBurst : RequestBase
    {
        public WirelessBurst()
        {
            Options = new Actions.WirelessBurst();
        }

        [JsonIgnore] //will be applied to Args in the base.
        public Actions.WirelessBurst Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}