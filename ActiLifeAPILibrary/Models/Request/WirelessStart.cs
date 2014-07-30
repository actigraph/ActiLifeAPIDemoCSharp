using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Starts the wireless scan of devices.
    /// Notes:
    /// - Response payload is only set when a device has been detected and will only contain the ANT ID of the device (everything else will be defaulted values). 
    ///   A second response will be sent when the device’s information is known.
    /// </summary>
    public class WirelessStart : RequestBase
    {
        public WirelessStart()
        {
            Options = new Actions.WirelessStart();
        }

        [JsonIgnore] //will be applied to Args in the base.
        public Actions.WirelessStart Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}