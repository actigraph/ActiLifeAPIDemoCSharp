using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester.Tests
{
	internal interface IApiTest
	{
		string Name { get; }

		string GetJSON();

		bool IsValidResponse(JObject d);
	}
}
