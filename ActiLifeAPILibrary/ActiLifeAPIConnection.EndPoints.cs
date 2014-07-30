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
	}
}
