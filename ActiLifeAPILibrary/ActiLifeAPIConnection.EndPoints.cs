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
		async public Task<string> GetActiLifeVersion()
		{
			return await SendData(new Models.Request.RequestBase { Action = "ActiLifeVersion" }.ToJson());
		}

        async public Task<string> GetAPIVersion()
        {
            return await SendData(new Models.Request.RequestBase { Action = "APIVersion" }.ToJson());
        }

        async public Task<string> MinimizeActiLife()
        {
            return await SendData(new Models.Request.RequestBase { Action = "ActiLifeMinimize" }.ToJson());
        }

        async public Task<string> RestoreActiLife()
        {
            return await SendData(new Models.Request.RequestBase { Action = "ActiLifeRestore" }.ToJson());
        }

        async public Task<string> QuitActiLife()
        {
            return await SendData(new Models.Request.RequestBase { Action = "ActiLifeQuit" }.ToJson());
        }

        async public Task<string> NhanesWearTimeValidation(string fileName)
        {
            return await SendData(new Models.Request.RequestBase { Action = "NHANESWTV", Args = new NhanesWtv(fileName)}.ToJson());
        }

	    public async Task<string> GetDataScoringResults(string fileName)
        {
            DataScoring d = new DataScoring
            {
                FileInputPath = fileName,
                FilterOptions = new FilterOptions(),
                CalculateEnergyExpenditure = true,
                EnergyExpenditureOptions = new EnergyExpenditureOptions(),
                CalculateMETs = false,
                METOptions = new METOptions(),
                CalculateCutPoints = false,
                CutPointOptions = new CutPointOptions(),
                CalculateBouts = false,
                CalculateSedentaryAnalysis = false,
                IncludeExtraStatistics = false,
                ResultOptions = new ResultOptions()
            };

	        return await SendData(new Models.Request.RequestBase {Action = "DataScoring", Args = d }.ToJson());
        }
	}
}
