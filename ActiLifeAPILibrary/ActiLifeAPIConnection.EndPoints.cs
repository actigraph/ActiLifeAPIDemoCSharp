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

	    public async Task<string> GetDataScoringResults(string fileName)
        {
            DataScoring d = new DataScoring
            {
                FileInputPath = fileName,
                CalculateEnergyExpenditure = true,
                ResultOptions = new ResultOptions {IncludeTotalResults = true}
            };

	        return await SendData(new Models.Request.RequestBase {Action = "DataScoring", Args = JsonConvert.SerializeObject(d, Formatting.Indented)}.ToJson());
        }
	}
}
