using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiLifeAPILibrary
{
	public partial class ActiLifeAPIConnection
	{
		async public Task<string> GetActiLifeVersion()
		{
			return await SendData(new ActiLifeAPILibrary.Models.Request.RequestBase { Action = "ActiLifeVersion" }.ToJson());
		}
	}
}
