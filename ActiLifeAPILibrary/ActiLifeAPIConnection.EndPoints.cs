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
		async public Task<string> ActiLifeVersion()
		{
			return await SendData(new Models.Request.ActiLifeVersion().ToJson());
		}

		async public Task<string> ActiLifeAPIVersion()
		{
			return await SendData(new Models.Request.APIVersion().ToJson());
		}

		async public Task<string> ActiLifeMinimize()
		{
			return await SendData(new Models.Request.ActiLifeMinimize().ToJson());
		}

		async public Task<string> ActiLifeRestore()
		{
			return await SendData(new Models.Request.ActiLifeRestore().ToJson());
		}

		async public Task<string> ActiLifeQuit()
		{
			return await SendData(new Models.Request.ActiLifeQuit().ToJson());
		}

        async public Task<string> NHANESWTV(Models.Request.NHANESWTV options)
        {
			if (options == null) throw new NullReferenceException("Must set NHANESWTV options!");

			return await SendData(options.ToJson());
        }

	    public async Task<string> DataScoring(Models.Request.DataScoring options)
        {
			if (options == null) throw new NullReferenceException("Must set DataScoring options!");

	        return await SendData(options.ToJson());
        }
	}
}
