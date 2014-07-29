using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester.Tests
{
	internal class ApiTests
	{

		//public class TestWaitForConsolePrompt : IApiTest
		//{
		//	#region IApiTest Members

		//	public string Name
		//	{
		//		get { return "Waiting To Send Next Command..."; }
		//	}

		//	public dynamic GetJSON() {
		//		Console.WriteLine("Press any key to continue...");
		//		Console.ReadKey();

		//		return null;
		//	}

		//	public bool IsValidResponse(JObject d) { return true; }

		//	#endregion
		//}

		public abstract class TestBase : IApiTest
		{

			public TestBase(dynamic json)
			{
				_json = json;

				if (json != null)
					try { Name = json.Action; }
					catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { }
			}

			#region IApiTest Members

			public string Name
			{
				get;
				protected set;
			}

			private dynamic _json = null;

			public virtual string GetJSON()
			{
				if (_json == null)
					throw new NotImplementedException();

				return JsonConvert.SerializeObject(_json);
			}

			public virtual bool IsValidResponse(JObject d)
			{
				if (d == null) return false;

				if (!GetValueFromJToken<bool>(d, "Success", false)) return false;

				JToken payload;
				if (d.TryGetValue("payload", StringComparison.CurrentCultureIgnoreCase, out payload))
					return IsValidPayload(payload);

				return true;
			}

			protected virtual bool IsValidPayload(JToken payload)
			{
				if (payload == null) return false; return true;
			}

			#endregion IApiTest Members

			public T GetValueFromJToken<T>(Newtonsoft.Json.Linq.JToken j, string key, T defaultValue)
			{
				JToken obj = null;
				if (j is JObject)
					obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
				else
					obj = j[key.ToLower()];

				if (obj == null) throw new ArgumentException("Unable to locate JSON token: \"" + key + "\"");

				T returnObj = default(T);

				if (obj is Newtonsoft.Json.Linq.JArray)
					returnObj = obj.ToObject<T>();
				else
					returnObj = obj.Value<T>();

				//Convert UTC datetimes back to local system time.  API is ISO8601; UTC is used!
				if (returnObj is DateTime)
					returnObj = Cast<T>(Convert.ToDateTime(returnObj).ToLocalTime());

				return returnObj;
			}

			/// <summary>Method used to dynamically cast (through reflection) one type to another type (object to a correct type).</summary>
			public static T Cast<T>(object o)
			{
				return (T)o;
			}
		}

		public class Tests
		{
			public class ActiLifeVersionTest : TestBase
			{
				public ActiLifeVersionTest()
					: base(new { Action = "ActiLifeVersion" }) { }

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class APIVersionTest : TestBase
			{
				public APIVersionTest()
					: base(new { Action = "APIVersion" }) { }

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class ActiLifeRestore : TestBase
			{
				public ActiLifeRestore()
					: base(new { Action = "ActiLifeRestore" }) { }
			}

			public class ActiLifeMinimize : TestBase
			{
				public ActiLifeMinimize()
					: base(new { Action = "ActiLifeMinimize" }) { }
			}

			public class ActiLifeQuit : TestBase
			{
				public ActiLifeQuit()
					: base(new { Action = "ActiLifeQuit" }) { }
			}

			public class ActiLifeNHANESWtv : TestBase
			{
				public ActiLifeNHANESWtv()
					: base("nhaneswtv") { }

				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return JsonConvert.SerializeObject(new
					{
						Action = "nhaneswtv",
						args = new { filename = System.IO.Path.Combine(assemblyDir, "input.gt3x") }
					});
				}

				protected override bool IsValidPayload(JToken payload)
				{
					if (!base.IsValidPayload(payload)) return false;

					dynamic d = this.GetValueFromJToken<dynamic>(payload, "results", null);

					if (d == null || d.NonWearBouts == null) return false;

					return true;
				}
			}

			public class ActiLifeDataScoring : TestBase
			{
				public ActiLifeDataScoring()
					: base("datascoring") { }

				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return JsonConvert.SerializeObject(new
					{
						Action = "datascoring",
						args = new
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd"),
							UseWTVData = true,
							UseLogDiaries = false,
							CalculateEnergyExpenditure = true,
							CalculateMETs = true,
							CalculateCutPoints = true,
							CalculateBouts = true,
							CalculateSedentaryAnalysis = true,
							IncludeExtraStatistics = true,
							IncludeDailyResults = false,
							IncludeHourlyResults = false
						}
					});
				}
			}
		}
	}
}
