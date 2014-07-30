﻿using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.Request
{
    /// <summary>
    /// Identifies an ANT device by flashing the LEDs.
    /// Notes:
    /// - Wireless scanning must have been started previously.
    /// </summary>
    public class WirelessIdentify : RequestBase
    {
        public WirelessIdentify()
        {
            Options = new Actions.WirelessIdentify();
        }

        [JsonIgnore] //will be applied to Args in the base.
        public Actions.WirelessIdentify Options { get; set; }

        public override string ToJson()
        {
            Args = Options;

            return base.ToJson();
        }
    }
}