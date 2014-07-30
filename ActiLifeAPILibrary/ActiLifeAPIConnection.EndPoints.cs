using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiLifeAPILibrary.Models.Actions;
using Newtonsoft.Json;

namespace ActiLifeAPILibrary
{
	public partial class ActiLifeAPIConnection
	{
		/// <summary>
		/// Returns the version of ActiLife that is running. [API 1.6]
		/// </summary>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/actilifeversion.md"/>
		async public Task<string> ActiLifeVersion()
		{
			return await SendData(new Models.Request.ActiLifeVersion().ToJson());
		}

		/// <summary>
		/// Returns the version of the API operating in the current responding version of ActiLife. [API 1.4]
		/// </summary>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/apiversion.md"/>
		async public Task<string> APIVersion()
		{
			return await SendData(new Models.Request.APIVersion().ToJson());
		}

		/// <summary>
		/// Minimizes ActiLife to not be seen by the user. [API 1.0]
		/// </summary>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/actilifeminimize.md"/>
		async public Task<string> ActiLifeMinimize()
		{
			return await SendData(new Models.Request.ActiLifeMinimize().ToJson());
		}

		/// <summary>
		/// Restores ActiLife from a minimized state. [API 1.0]
		/// </summary>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/actiliferestore.md"/>
		async public Task<string> ActiLifeRestore()
		{
			return await SendData(new Models.Request.ActiLifeRestore().ToJson());
		}

		/// <summary>
		/// Closes ActiLife.  [API 1.0]
		/// </summary>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		async public Task<string> ActiLifeQuit()
		{
			return await SendData(new Models.Request.ActiLifeQuit().ToJson());
		}

		/// <summary>
		/// Converts a file from one file format and epoch length to another. [API 1.9]
		/// </summary>
		/// <param name="options">ConvertFile options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/convertfile.md"/>
		async public Task<string> ConvertFile(Models.Request.ConvertFile options)
		{
			if (options == null) throw new NullReferenceException("Must set ConvertFile options!");

			return await SendData(options.ToJson());
		}

		/// <summary>
		/// Returns Wear Time Validation information from a .GT3X file or .AGD file. This is specific for NHANES. A more robust WTV API action will be added in the future. [API 1.7]
		/// </summary>
		/// <param name="options">NHANESWTV options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/nhaneswtv.md"/>
        async public Task<string> NHANESWTV(Models.Request.NHANESWTV options)
        {
			if (options == null) throw new NullReferenceException("Must set NHANESWTV options!");

			return await SendData(options.ToJson());
        }

		/// <summary>
		/// Get data scoring algorithm results for a single AGD file. [API 1.10]
		/// </summary>
		/// <param name="options">DataScoring options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/datascoring.md"/>
	    public async Task<string> DataScoring(Models.Request.DataScoring options)
        {
			if (options == null) throw new NullReferenceException("Must set DataScoring options!");

	        return await SendData(options.ToJson());
        }

		/// <summary>
		/// Lists all connected USB devices and continues listing devices as they are plugged in. [API 1.1]
		/// </summary>
		/// <param name="options">USBList options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/usblist.md"/>
		public async Task<string> USBList(Models.Request.USBList options)
		{
			if (options == null) throw new NullReferenceException("Must set USBList options!");

			return await SendData(options.ToJson());
		}

		/// <summary>
		/// <para>Initializes a device connected via USB to prepare for a new activity monitoring session. [API 1.2]</para>
		/// <para> </para>
		/// <para>Notes: Will remove all activity data from the device.</para>
		/// </summary>
		/// <param name="options">USBInitialize options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/usbinitialize.md"/>
		public async Task<string> USBInitialize(Models.Request.USBInitialize options)
		{
			if (options == null) throw new NullReferenceException("Must set USBInitialize options!");

			return await SendData(options.ToJson());
		}

		/// <summary> Identifies a device by flashing the LEDs. [API 1.5] </summary>
		/// <param name="options">USBInitialize options required for this Action.</param>
		/// <returns>Task that will return the JSON result from ActiLife.</returns>
		/// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/usbidentify.md"/>
		public async Task<string> USBIdentify(Models.Request.USBIdentify options)
		{
			if (options == null) throw new NullReferenceException("Must set USBIdentify options!");

			return await SendData(options.ToJson());
		}
		
        /// <summary>
        /// Downloads requested number of minutes of data from an ANT device. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessBurst options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessburst.md"/>
        public async Task<string> WirelessBurst(Models.Request.WirelessBurst options)
        {
            if (options == null) throw new NullReferenceException("Must set WirelessBurst options!");

            return await SendData(options.ToJson());
        }

        /// <summary>
        /// Identifies an ANT device by flashing the LEDs. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessIdentify options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessidentify.md"/>
        public async Task<string> WirelessIdentify(Models.Request.WirelessIdentify options)
        {
            if (options == null) throw new NullReferenceException("Must set WirelessIdentify options!");

            return await SendData(options.ToJson());
        }

        /// <summary>
        /// Start receiving data real time from an ANT device. Wireless scanning must have been started previously. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessRealtimeStart options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessrealtimestart.md"/>
        public async Task<string> WirelessRealtimeStart(Models.Request.WirelessRealtimeStart options)
        {
            if (options == null) throw new NullReferenceException("Must set WirelessRealtimeStart options!");

            return await SendData(options.ToJson());
        }

        /// <summary>
        /// Stop receiving data real time from an ANT device. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessRealtimeStop options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessrealtimestop.md"/>
        public async Task<string> WirelessRealtimeStop(Models.Request.WirelessRealtimeStop options)
        {
            if (options == null) throw new NullReferenceException("Must set WirelessRealtimeStop options!");

            return await SendData(options.ToJson());
        }

        /// <summary>
        /// Start receiving data real time from an ANT device. Wireless scanning must have been started previously. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessRealtimeStart options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessstart.md"/>
        public async Task<string> WirelessStart(Models.Request.WirelessStart options)
        {
            if (options == null) throw new NullReferenceException("Must set WirelessStart options!");

            return await SendData(options.ToJson());
        }

        /// <summary>
        /// Stop receiving data real time from an ANT device. [API 1.0]
        /// </summary>
        /// <param name="options">WirelessRealtimeStop options required for this Action.</param>
        /// <returns>Task that will return the JSON result from ActiLife.</returns>
        /// <see cref="https://github.com/actigraph/ActiLifeAPIDocumentation/blob/master/actions/wirelessstop.md"/>
        public async Task<string> WirelessStop()
        {
            return await SendData(new Models.Request.WirelessStop().ToJson());
        }
	}
}
